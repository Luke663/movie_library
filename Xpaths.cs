namespace Rep
{
    // Strings used to find the desired information from the scraped page
    static class Xpaths
    {
        public const string TITLE = "//h1";

        // returns: year, rating, duration (begins with TV Series for series) without spaces
        // Gives 3 or 4 items in one string, form of: "TV Series 1997–2003 12 44m" for series and "2023 15 1h 47m" for movies
        public const string SECONDARY = "//*[@class=\"ipc-inline-list ipc-inline-list--show-dividers sc-afe43def-4 kdXikI baseAlt\"]";

        public const string SCORE = "//*[@class=\"sc-bde20123-1 iZlgcd\"]";

        public const string GENRES = "//*[@class=\"ipc-chip-list__scroller\"]";

        public const string IMAGE = "//*[@class=\"ipc-image\"]";

        public const string DESCRIPTION = "//*[@data-testid=\"plot\"]/span[3]";

        public const string EPISODES = "//*[@class=\"ipc-title__text\"]/span[2]";
    }
}
