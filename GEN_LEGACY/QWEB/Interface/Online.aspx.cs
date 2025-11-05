using System;
using System.Xml;

namespace CSGenio
{
    public partial class Online : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //reply allways ok
            Response.ContentType = "text/xml";
            XmlDocument document = new XmlDocument();
            XmlElement elem = document.CreateElement("Status");
            document.AppendChild(elem);
            elem.AppendChild(document.CreateTextNode("Ok"));
            Response.Write(document.OuterXml);
        }
    }
}