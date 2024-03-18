namespace GenioMVC.ViewModels.Dashboard
{
	public class WidgetGroup
	{
		/// <summary>
		/// Gets or sets the unique identifier of the group.
		/// </summary>
		public string Identifier { get; set; }

		/// <summary>
		/// Gets or sets the title of the group.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the order of the group in the widget panel.
		/// </summary>
		public int Order { get; set; }
	}
}
