namespace GenioMVC.ViewModels.Dashboard
{
	public class WidgetDto
	{
		/// <summary>
		/// The widget identifier.
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// For widgets with multiple pages, it is the current page.
		/// </summary>
		public string rowkey { get; set; }

		/// <summary>
		/// Whether the widget is in use or not.
		/// </summary>
		public bool visible { get; set; }

		/// <summary>
		/// The horizontal position of the widget.
		/// </summary>
		public int x { get; set; }

		/// <summary>
		/// The vertical position of the widget.
		/// </summary>
		public int y { get; set; }

		public WidgetDto() { }

		public WidgetDto(Widget widget)
		{
			id = widget.Id;
			rowkey = widget.Rowkey;
			visible = widget.Visible;
			x = widget.Hposition;
			y = widget.Vposition;
		}
	}
}
