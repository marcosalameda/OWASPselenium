namespace GenioMVC.Helpers.Table.Builder //FIX MARA: Provavelmente não é necessária esta class
{
    public class GridSlideShow<TModel> : TableListBuilder<TModel>
        where TModel : class
    {
        public GridSlideShow(Table<TModel> builder, bool canFilter)
            : base(builder, canFilter)
        {
        }
    }
}