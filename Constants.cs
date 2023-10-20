using System.Drawing;

namespace Rep
{
    static class Constants
    {
        // Number of application pages
        public const int NUMBER_OF_PAGES = 4;

        // Number of columns in Entry table
        public const int NUMBER_OF_ENTRY_FIELDS = 10;

        // Widths for the search results displayed on SearchResultPage_UC.
        // 'SMALL' size shortens the result to accommodate for the scroll bar
        public const int SEARCH_RESULT_ITEM_SIZE_SMALL = 746;
        public const int SEARCH_RESULT_ITEM_SIZE_LARGE = 764;

        public static Color TEXT_COLOUR = Color.FromKnownColor(KnownColor.ButtonFace);
        public static Color BACKGROUND_COLOUR = Color.FromKnownColor(KnownColor.ControlDarkDark);
        public static Color THEME_COLOUR = Color.FromArgb(46, 46, 46);

        /// <summary>
        /// Returns the index of the desired page via the given string
        /// (either: HOME, SEARCH, RESULT or VIEW_ALL).
        /// </summary>
        /// <param name="pageName">Desired page</param>
        /// <returns>Page index.</returns>
        public static int GetPageIndex(string pageName)
        {
            switch (pageName)
            {
                case "HOME":
                    return 0;

                case "SEARCH":
                    return 1;

                case "RESULT":
                    return 2;

                case "VIEW_ALL":
                    return 3;

                default:
                    return 0;
            }
        }
    }
}
