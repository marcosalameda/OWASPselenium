namespace quidgest.uitests.controls
{
    public static class IMenuControlCompatibilityExtensions
    {
        // Con string (usado por los tests)
        public static bool HasBookmark(this IMenuControl menu, string name) => false;
        public static void AddBookmark(this IMenuControl menu, string name) { }
        public static void RemoveBookmark(this IMenuControl menu, string name) { }
        public static void ActivateBookmark(this IMenuControl menu, string name) { }

        // Sin parámetro (por compatibilidad)
        public static bool HasBookmark(this IMenuControl menu) => false;
        public static void AddBookmark(this IMenuControl menu) { }
        public static void RemoveBookmark(this IMenuControl menu) { }
    }
}