using CSGenio.persistence;
using NUnit.Framework;
using System;
using CSGenio.framework;
using System.Diagnostics;

namespace DbAdmin.IntegrationTest
{
    public class CreateDatabase
    {
        


        [SetUp]
        public void Setup()
        {
            PersistenceFactoryExtension.Use();
        }

        

        [Test]
        public void AccessToServer()
        {
            PersistentSupport sp = PersistentSupport.getPersistentSupport(Configuration.DefaultYear);
            var connection = sp.GetConnectionToServer();
            connection.Open();
            Assert.IsTrue(connection.State == System.Data.ConnectionState.Open);
        }

        [Test]
        public void ConnectToDatabase()
        {
            PersistentSupport sp = PersistentSupport.getPersistentSupport(Configuration.DefaultYear);
            sp.openConnection();
            Assert.IsTrue(sp.Connection.State == System.Data.ConnectionState.Open);
        }

        private void AddDummySystem(string database) {
            var currentDataSystem = CSGenio.framework.Configuration.DataSystems[0];

            var dataSystem = currentDataSystem.ShallowCopy();
            var databaseName = 
            dataSystem.Name = database;
            dataSystem.Schemas[0].Schema = database;

            CSGenio.framework.Configuration.DataSystems.Add(dataSystem);                
        }



        [Test]
        public void CreateDatabaseOnly()
        {
            string NEW_DB = $"{Configuration.Program}{Configuration.DataSystems[0].Name}_NewDB";
            AddDummySystem(NEW_DB);
            PersistentSupport sp = PersistentSupport.getPersistentSupport(NEW_DB);
            //Arrange: Delete existing databases if any
            if (sp.CheckIfDatabaseExists(NEW_DB))
            {
                sp.Drop(NEW_DB);
            }
            var datasystem = CSGenio.framework.Configuration.ResolveDataSystem(NEW_DB, CSGenio.framework.Configuration.DbTypes.NORMAL);
            var user = datasystem.LoginDecode();
            var password = datasystem.PasswordDecode();
            var dbMaintenance = new DBMaintenance(AppDomain.CurrentDomain.BaseDirectory);

            //Act: Reindex
            var result = dbMaintenance.StartReindexation(user, password, "CREATEDB", null, "", false, year: NEW_DB);
            
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            while (!result.Progress.IsFinished() && stopWatch.Elapsed.TotalSeconds < 15)
                Thread.Sleep(50);

            //Assert: Check if database exists
            Assert.IsTrue(sp.CheckIfDatabaseExists(NEW_DB));
            Assert.AreEqual(result.Progress.State, ExecuteQueryCore.RdxProgressStatus.SUCCESS, result.Progress.Message);

            //Teardown
            sp.Drop(NEW_DB);
        }


        [Test]
        public void CreateDatabaseDefaultScripts()
        {
            string NEW_DB = $"{Configuration.Program}{Configuration.DataSystems[0].Name}_NewSchema";
            AddDummySystem(NEW_DB);
            PersistentSupport sp = PersistentSupport.getPersistentSupport(NEW_DB);
            //Arrange: Delete existing databases if any
            if (sp.CheckIfDatabaseExists(NEW_DB))
            {
                sp.Drop(NEW_DB);
            }
            var datasystem = CSGenio.framework.Configuration.ResolveDataSystem(NEW_DB, CSGenio.framework.Configuration.DbTypes.NORMAL);
            var user = datasystem.LoginDecode();
            var password = datasystem.PasswordDecode();
            var dbMaintenance = new DBMaintenance(AppDomain.CurrentDomain.BaseDirectory);

            //Act: Reindex
            var result = dbMaintenance.StartReindexation(user, password, "", new System.Collections.Generic.List<string>(), "", false, year: NEW_DB);
            
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            while (!result.Progress.IsFinished() && stopWatch.Elapsed.TotalSeconds < 60)
                Thread.Sleep(50);

            
            //Assert: Check if database exists
            Assert.IsTrue(sp.CheckIfDatabaseExists(NEW_DB));
            Assert.AreEqual(result.Progress.State, ExecuteQueryCore.RdxProgressStatus.SUCCESS, result.Progress.Message);
            Assert.AreEqual(Configuration.VersionDbGen, Configuration.GetDbVersion(NEW_DB));
            
            //Teardown
            sp.Drop(NEW_DB);
        }
    }
}