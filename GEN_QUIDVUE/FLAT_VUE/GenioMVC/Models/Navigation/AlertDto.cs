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
		/// Gets or sets the on alert click target.
		/// </summary>
		public AlertClickTarget target { get; set; }

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
			this.target = alert.Target;
		}
	}
}
