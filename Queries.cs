namespace Rep
{
    // SQL Query list
    static class Queries
    {
        public const string GET_ENTRY = "SELECT * FROM [Entry] WHERE Entry.Title = N'"; // N before for string literals, prevents problems from specials characters
        public const string SEARCH_GENERIC = "SELECT * FROM [Entry] WHERE Entry.Title LIKE '%";

        public const string ADD_ENTRY = "INSERT INTO [Entry] (Title, Description, Path, Date, Age_rating, Genres, Score, Duration) VALUES(@Title, @Description, @Path, @Date, @Age_rating, @Genres, @Score, @Duration)";
        public const string ADD_GENRE = "INSERT INTO [Genres] (Genre) VALUES ('";
        
        public const string GET_GENRE = "SELECT * FROM [Genres] WHERE Genres.Genre = @Category";
        public const string INSERT_GENRE_CONNECTION = "INSERT INTO [Entry_has_genre] (EntryID, GenreID) VALUES (@EntryID, @GenreID)";

        public const string GET_GENRE_ENTRIES = "SELECT Entry.Id, Entry.Title, Entry.Description, Entry.Path, Entry.Date, Entry.Age_rating, Entry.Genres, Entry.Score, Entry.Duration, Entry.Note FROM [Entry] " +
            "INNER JOIN [Entry_has_genre] ON CAST(Entry_has_genre.EntryID AS INTEGER) = Entry.Id INNER JOIN [Genres] ON Genres.Id = CAST(Entry_has_genre.GenreID AS INTEGER) WHERE Genres.Genre = '";
        
        public const string GET_GENRES_AND_COUNT = "SELECT Genre, COUNT(*) FROM [Genres] INNER JOIN [Entry_has_genre] ON Genres.Id = CAST(Entry_has_genre.GenreID AS INTEGER) GROUP BY Genres.Genre";
        
        public const string GET_RANDOM_ENTRY = "SELECT * FROM [Entry] WHERE Entry.Id = " +
            "(CAST((((SELECT MAX(Entry.Id) FROM [Entry]) - (SELECT MIN(Entry.Id) FROM [Entry])) * RAND()) AS INTEGER)) + (SELECT MIN(Entry.Id) FROM [Entry]);";

        public const string GET_ALL_TILES = "SELECT Entry.Title, Entry.Path, Entry.Genres, Entry.Score, Entry.Date FROM [Entry]";

        public const string DELETE_ENTRY = "DELETE FROM [Entry] WHERE Entry.Id = 1; DELETE FROM[Entry_has_genre] WHERE Entry_has_genre.EntryID = 1;";

        public static string GetDeleteEntryQuery(string iD)
        { return "DELETE FROM [Entry] WHERE Entry.Id = " + iD + "; DELETE FROM[Entry_has_genre] WHERE Entry_has_genre.EntryID = " + iD + ";"; }

        public static string Get_UpdateNote_Query(string title, string note)
        {  return "UPDATE Entry SET Note = '" + note + "' WHERE Title = '" + title + "';"; }
    }
}
