using CSGenio;
using CSGenio.business;
using CSGenio.core.messaging;
using CSGenio.messaging;
using CSGenio.persistence;
using CSGenio.framework;
using NUnit.Framework;

namespace WebTest;

[TestFixture]
public class TestMessaging
{
    MessagingService m_messaging;
    MessageCaptureProcessor m_messageCapture;
    AckCaptureProcessor m_ackCapture;
    User m_user;

    MessagingXml m_originalConfig = new MessagingXml();

    [SetUp]
    public void Setup()
    {
        var meta = MessageMetadataFactory.GeneratedMetadata();

        //modify the metadata to capture the processing for the test
        m_messageCapture = new MessageCaptureProcessor();
        meta.Subscribers[0].Processor = m_messageCapture;
        m_ackCapture = new AckCaptureProcessor();
        meta.Publishers[0].Ack = m_ackCapture;

        //inject the necessary configuration for these tests (avoids need for a active msmq config in dev)
        m_originalConfig.Enabled = Configuration.Messaging.Enabled;
        m_originalConfig.EnabledPublications = Configuration.Messaging.EnabledPublications;
        m_originalConfig.EnabledSubscriptions = Configuration.Messaging.EnabledSubscriptions;

        Configuration.Messaging.Enabled = true;
        Configuration.Messaging.EnabledPublications = ["GQT.INVENTORY"];
        Configuration.Messaging.EnabledSubscriptions = ["GQT.INVENTORY"];


        //start the service with the testing initialization
        m_messaging = new MessagingService();
        m_messaging.Start(meta, "MemoryMq", true);

        //test user
        m_user = new User("test", "", "");
        m_user.AddModuleRole("GQT", Role.ADMINISTRATION);
        m_user.CurrentModule = "GQT";
        
        CSGenio.core.di.GenioDI.Messaging = m_messaging;
        GenioDIDefault.UseDatabase();
    }

    [TearDown]
    public void TearDown()
    {
        m_messaging?.Close();

        //restore the config
        Configuration.Messaging.Enabled = m_originalConfig.Enabled;
        Configuration.Messaging.EnabledPublications = m_originalConfig.EnabledPublications;
        Configuration.Messaging.EnabledSubscriptions = m_originalConfig.EnabledSubscriptions;
    }

    /// <summary>
    /// Saving a table that belongs to a message publish sends the message to the broker.
    /// A journaled message also sends back a ack message to the publisher.
    /// </summary>
    [Test]
    public void MessageCreation()
    {
        var sp = PersistentSupport.getPersistentSupport("0");
        sp.openTransaction();
        CSGenioAasset asset = new CSGenioAasset(m_user);
        asset.ValName = "xpto";
        asset.ValAssetnum = 999;
        asset.ValPhoto = [0x12, 0x13, 0x14];
        asset.insert(sp);
        var codasset = asset.ValCodasset;
        sp.closeTransaction();

        //assert we received a row update event
        m_messageCapture.WaitForMessages(1000);
        Assert.That(m_messageCapture.ReceivedDataset, Is.Not.Null);
        var rows = m_messageCapture.ReceivedDataset.Tables["asset"].Updated;
        Assert.That(rows.Count, Is.EqualTo(1));
        Assert.That(rows[codasset], Is.AssignableTo(typeof(CSGenioAasset)));
        var asset2 = (CSGenioAasset)rows[codasset];
        Assert.That(asset2.ValName, Is.EqualTo("xpto"));
        Assert.That(asset2.ValAssetnum, Is.EqualTo(999));
        Assert.That(asset2.ValPhoto, Is.EqualTo(asset.ValPhoto).AsCollection);

        //assert that the processor sent back an ack
        m_ackCapture.WaitForMessages(1000);
        Assert.That(m_ackCapture.ReceivedAck, Is.Not.Null);

        //teardown
        m_messageCapture.ReceivedDataset = null;
        m_ackCapture.ReceivedAck = null;
        sp.openTransaction();
        asset.delete(sp);
        sp.closeTransaction();

        //assert we received a row delete event
        m_messageCapture.WaitForMessages(1000);
        Assert.That(m_messageCapture.ReceivedDataset, Is.Not.Null);
        var dels = m_messageCapture.ReceivedDataset.Tables["asset"].Deleted;
        Assert.That(dels.Count, Is.EqualTo(1));
        Assert.That(dels[0], Is.EqualTo(codasset));
    }

    /// <summary>
    /// When the parent of a record is in pseudo-new state the child records are not sent
    /// until the parent is correctly saved. At that time all the children are sent in bulk.
    /// </summary>
    [Test]
    public void CascadeInsertChildren()
    {
        //pseudo new
        var sp = PersistentSupport.getPersistentSupport("0");
        sp.openTransaction();
        CSGenioAasset asset = new CSGenioAasset(m_user);
        asset.insertPseud(sp);
        var codasset = asset.ValCodasset;
        sp.closeTransaction();

        //no messages should have been sent here
        Assert.That(m_messageCapture.ReceivedDataset, Is.Null);

        //add children (simulating what happens in a table list UI)
        var asspaCodList = new List<string>();
        sp.openTransaction();
        CSGenioAasspa asspa = new CSGenioAasspa(m_user);
        asspa.ValCodasset = codasset;
        asspa.ValDate = new DateTime(2024, 8, 31);
        asspa.ValDatatype = ArrayDatatype.E_D_3;
        asspa.inserir_WS(sp);
        asspaCodList.Add(asspa.ValCodasspa);

        asspa = new CSGenioAasspa(m_user);
        asspa.ValCodasset = codasset;
        asspa.ValText = "myname";
        asspa.ValDatatype = ArrayDatatype.E_T_1;
        asspa.inserir_WS(sp);
        asspaCodList.Add(asspa.ValCodasspa);
        sp.closeTransaction();        

        //no messages should have been sent here
        Assert.That(m_messageCapture.ReceivedDataset, Is.Null);

        //save the parent
        sp.openTransaction();
        asset = CSGenioAasset.search(sp, codasset, m_user);
        asset.ValName = "xpto";
        asset.ValAssetnum = 999;
        asset.update(sp);
        sp.closeTransaction();

        //we receives a message with parent and children in bulk
        m_messageCapture.WaitForMessages(1000);
        Assert.That(m_messageCapture.ReceivedDataset, Is.Not.Null);

        var rows = m_messageCapture.ReceivedDataset.Tables["asset"].Updated;
        Assert.That(rows.Count, Is.EqualTo(1));
        Assert.That(rows[codasset], Is.AssignableTo(typeof(CSGenioAasset)));
        var asset1 = (CSGenioAasset)rows[codasset];
        Assert.That(asset1.ValName, Is.EqualTo("xpto"));
        Assert.That(asset1.ValAssetnum, Is.EqualTo(999));

        var rows2 = m_messageCapture.ReceivedDataset.Tables["asspa"].Updated;
        Assert.That(rows2.Count, Is.EqualTo(2));
        foreach (var row in rows2)
        {
            Assert.That(row.Value, Is.AssignableTo(typeof(CSGenioAasspa)));
            var asspa2 = row.Value as CSGenioAasspa;
            Assert.That(asspa2.ValCodasset, Is.EqualTo(codasset));
        }

        //teardown
        sp.openTransaction();
        foreach (var cod in asspaCodList)
        {
            asspa = CSGenioAasspa.search(sp, cod, m_user);
            asspa.delete(sp);
        }
        asset.delete(sp);
        sp.closeTransaction();
    }

    /// <summary>
    /// Message tables marked as annex are not sent on their own.
    /// They are only send as a detail of a operation of another message table.
    /// </summary>
    [Test]    
    public void AnexTable()
    {
        //insert anex table
        var sp = PersistentSupport.getPersistentSupport("0");
        sp.openTransaction();
        CSGenioAkinde kinde = new CSGenioAkinde(m_user);
        kinde.ValDesignat = "mykind";        
        kinde.insert(sp);
        var codkinde = kinde.ValCodkinde;
        sp.closeTransaction();

        //we should not receive any message at this point
        Assert.That(m_messageCapture.ReceivedDataset, Is.Null);

        //modify a table related to the anex
        sp.openTransaction();
        CSGenioAasset asset = new CSGenioAasset(m_user);
        asset.ValName = "xpto";
        asset.ValCodkinde = codkinde;
        asset.insert(sp);
        var codasset = asset.ValCodasset;
        sp.closeTransaction();

        //we should receive the anex in the same message as the related table
        m_messageCapture.WaitForMessages(1000);
        Assert.That(m_messageCapture.ReceivedDataset, Is.Not.Null);

        var rows = m_messageCapture.ReceivedDataset.Tables["asset"].Updated;
        Assert.That(rows.Count, Is.EqualTo(1));
        Assert.That(rows[codasset], Is.AssignableTo(typeof(CSGenioAasset)));
        var asset1 = (CSGenioAasset)rows[codasset];
        Assert.That(asset1.ValName, Is.EqualTo("xpto"));
        Assert.That(asset1.ValCodkinde, Is.EqualTo(codkinde));

        rows = m_messageCapture.ReceivedDataset.Tables["kinde"].Updated;
        Assert.That(rows.Count, Is.EqualTo(1));
        Assert.That(rows[codkinde], Is.AssignableTo(typeof(CSGenioAkinde)));
        var kinde1 = (CSGenioAkinde)rows[codkinde];
        Assert.That(kinde1.ValDesignat, Is.EqualTo("mykind"));

        //teardown
        sp.openTransaction();
        asset.delete(sp);
        kinde.delete(sp);
        sp.closeTransaction();
    }

    /// <summary>
    /// Publication tables with a set condition filter out rows to be sent
    /// </summary>
    [Test]
    public void ConditionalSend()
    {
        var sp = PersistentSupport.getPersistentSupport("0");

        //save two rows, one that fails the condition and one the doesn't
        sp.openTransaction();
        CSGenioAasset asset = new CSGenioAasset(m_user);
        asset.ValName = ""; //this fails the condition
        asset.insert(sp);
        var codasset1 = asset.ValCodasset;
        asset = new CSGenioAasset(m_user);
        asset.ValName = "xpto"; //this succeeds the condition
        asset.insert(sp);
        var codasset2 = asset.ValCodasset;
        sp.closeTransaction();

        //we should receive a message containing only one of the rows
        m_messageCapture.WaitForMessages(1000);
        Assert.That(m_messageCapture.ReceivedDataset, Is.Not.Null);

        var rows = m_messageCapture.ReceivedDataset.Tables["asset"].Updated;
        Assert.That(rows.Count, Is.EqualTo(1));
        Assert.That(rows.First().Key, Is.EqualTo(codasset2));

        //teardown
        sp.openTransaction();
        asset.delete(sp);
        asset = CSGenioAasset.search(sp, codasset1, m_user);
        asset.delete(sp);
        sp.closeTransaction();
    }
}

