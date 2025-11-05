using System.Collections.Generic;
using System.Text;
using System.Xml;
using System;

/// <summary>
/// Summary description for Qweb2Qcom
/// </summary>
public static class Qweb2Qcom
{
    public static QcomBlk Deserialize(string xml)
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xml);

        QcomBlk res = new QcomBlk();
        res.Stat = doc.DocumentElement.Attributes["STAT"].InnerText;
        res.Online = doc.DocumentElement.Attributes["ONLINE"].InnerText;
        res.Lang = doc.DocumentElement.Attributes["LANG"].InnerText;
        res.Ses = doc.DocumentElement.Attributes["SES"].InnerText;

        res.QcomList = new List<Qcom>();
        foreach (XmlNode pedido in doc.DocumentElement.ChildNodes)
        {
            Qcom msg = new Qcom();
            msg.App = pedido.Attributes["APP"].InnerText;
            msg.Ident = pedido.Attributes["IDENT"].InnerText;
            msg.Func = pedido.Attributes["FUNC"].InnerText;
            msg.Cond = pedido.Attributes["COND"].InnerText;
            msg.Ord = pedido.Attributes["ORD"].InnerText;
            msg.Opt = pedido.Attributes["OPT"].InnerText;
            msg.Msg = pedido.Attributes["MSG"].InnerText;
            msg.Stat = pedido.Attributes["STAT"].InnerText;
            msg.Mod = pedido.Attributes["MOD"].InnerText;
            msg.Fich = pedido.Attributes["FICH"].InnerText;

            msg.Cmps = pedido.Attributes["CMPS"].InnerText.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);

            msg.Dados = new List<string[]>();
            if (msg.Cmps.Length > 0 || ! string.IsNullOrEmpty(pedido.Attributes["DADOS"].InnerText))
            {
                string[] rows = pedido.Attributes["DADOS"].InnerText.Split(new char[] { '{' });
                foreach (string row in rows)
                    msg.Dados.Add(row.Split('['));
            }
			
            res.QcomList.Add(msg);
        }

        return res;
    }

    public static string Serialize(QcomBlk qcomBlk)
    {
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = false;
        settings.OmitXmlDeclaration = true;

        StringBuilder res = new StringBuilder();
        using (XmlWriter doc = XmlWriter.Create(res, settings))
        {
            //doc.WriteStartDocument();
            doc.WriteStartElement("QCOMBLK");
            doc.WriteAttributeString("STAT", qcomBlk.Stat);
            doc.WriteAttributeString("ONLINE", qcomBlk.Online);
            doc.WriteAttributeString("LANG", qcomBlk.Lang);
            doc.WriteAttributeString("SES", qcomBlk.Ses);

            foreach (Qcom qcom in qcomBlk.QcomList)
            {
                doc.WriteStartElement("QCOM");

                doc.WriteAttributeString("MOD", qcom.Mod);
                doc.WriteAttributeString("APP", qcom.App);
                doc.WriteAttributeString("IDENT", qcom.Ident);
                doc.WriteAttributeString("FUNC", qcom.Func);
                doc.WriteAttributeString("COND", qcom.Cond);
                doc.WriteAttributeString("ORD", qcom.Ord);

                doc.WriteAttributeString("CMPS", string.Join(",", qcom.Cmps));

                List<string> rows = new List<string>();
                foreach (string[] row in qcom.Dados)
                    rows.Add(string.Join("[", row));

                doc.WriteAttributeString("DADOS", string.Join("{", rows.ToArray()));

                doc.WriteAttributeString("OPT", qcom.Opt);
                doc.WriteAttributeString("MSG", qcom.Msg);
                doc.WriteAttributeString("STAT", qcom.Stat);                
                doc.WriteAttributeString("FICH", qcom.Fich);

                doc.WriteEndElement();
            }
            doc.WriteEndElement();
        }

        return res.ToString();
    }
}
