namespace GenioMVC.Helpers.Table.Columns
{
    public class TableRowViewData<TModel>
    {
        /// <summary>
		/// The current item for this row in the data source.
		/// </summary>
        public TModel Item { get; private set; }
		
		/// <summary>
		/// Whether this is an alternating row
		/// </summary>
		public bool IsAlternate { get; private set; }

		/// <summary>
		/// Creates a new instance of the GridRowViewData class.
		/// </summary>
        public TableRowViewData(TModel item, bool isAlternate)
		{
			Item = item;
			IsAlternate = isAlternate;
		}
    }
}