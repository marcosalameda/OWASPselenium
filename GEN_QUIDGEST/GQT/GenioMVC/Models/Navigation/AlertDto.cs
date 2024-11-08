namespace GenioMVC.Models.Navigation
{
	/// <summary>
	/// A data transfer object for alerts.
	/// </summary>
	public class AlertDto
	{
		/// <summary>
		/// Gets or sets the alert identifier.
		/// </summary>
		public string id { get; set; }
		/// <summary>
		/// Gets or sets the row count.
		/// </summary>
		public float count { get; set; }
		/// <summary>
		/// Gets or sets the alert type.
		/// </summary>
		public string type { get; set; }
		/// <summary>
		/// Gets or sets the module of the alert.
		/// </summary>
		public string module { get; set; }
		/// <summary>
		/// Gets or sets the title of the alert.
		/// </summary>
		public string title { get; set; }
		/// <summary>
		/// Gets or sets the description of the alert.
		/// </summary>
		public string description { get; set; }
		/// <summary>
		/// Gets or sets whether the alert is dismissible.
		/// </summary>
		public bool dismissible { get; set; }
		/// <summary>
		/// Gets or sets the "Disable if lower than" alert property.
		/// </summary>
		public int disableIfLowerThan { get; set; }
		/// <summary>
		/// Gets or sets the URL of the alert on click target.
		/// </summary>
		public string url { get; set; }
		
		/// <summary>
		/// Initializes a new instance of the <see cref="AlertDto"/> class.
		/// </summary>
		/// <param name="alert">The alert.</param>
		public AlertDto(Alert alert)
		{
			this.id = alert.Idalert;
			this.count = alert.Count;
			this.type = alert.Type;
			this.module = alert.Module;
			this.title = alert.Title;
			this.description = alert.Content;
			this.dismissible = alert.Dismissible == 1;
			this.disableIfLowerThan = alert.DisableIfLowerThan;
			this.url = alert.URL;
		}
	}
}
