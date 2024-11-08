using System;
using System.Collections.Generic;
using System.Web.Mvc;

using CSGenio.framework;

namespace GenioMVC.Models.Navigation
{
	/// <summary>
	/// Interface Message
	/// </summary>
	[Serializable]
	public class Message
	{
		private string m_content;
		public string Content
		{
			get
			{
				return m_content;
			}
		}

		private string m_title;
		public string Title
		{
			get
			{
				return m_title;
			}
		}

		private string m_id;
		public string ID
		{
			get
			{
				return m_id;
			}
		}

		private Status m_status;
		[Newtonsoft.Json.JsonIgnore]
		public Status Status
		{
			get
			{
				return m_status;
			}
		}

		// MH - To simplify serialization and to not create a dependency of the Newtonsoft library on the CSGenio.framework
		[Newtonsoft.Json.JsonProperty("Status")]
		public String StrStatus
		{
			get
			{
				return m_status.ToString();
			}
		}

		private bool m_containsHTML;
		public bool ContainsHtml
		{
			get
			{
				return m_containsHTML;
			}
		}

		public Message(string content, Status status, bool containsHtml = false)
		{
			this.m_content = content;
			this.m_id = Guid.NewGuid().ToString();
			this.m_status = status;
			this.m_containsHTML = containsHtml;
		}

		public Message(string title, string content, Status status, bool containsHtml = false)
		{
			this.m_title = title;
			this.m_content = content;
			this.m_id = Guid.NewGuid().ToString();
			this.m_status = status;
			this.m_containsHTML = containsHtml;
		}
	}

	public class Messages
	{
		public static string getID(String navigationID)
		{
			return "Messages_" + navigationID;
		}
	}
}
