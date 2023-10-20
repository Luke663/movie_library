using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Rep
{
    class Database
    {
        protected static string connString;
        protected static SqlConnection dbConnetion;
        private static Database instance = null;

        protected Database()
        {
            connString = Properties.Settings.Default.userConnStr;
        }

        // Singleton design pattern, preventing duplicate instances of the Database class.
        public static Database GetInstance()
        {
            if (instance == null)
                instance = new Database();

            return instance;
        }

        /// <summary>
        /// Inserts the 8 required fields of an entry to the Entry table.
        /// </summary>
        /// <param name="values">Scraped string information for an entry</param>
        /// <returns>True if table insertion is completed correctly (and/or entry does not already exist).</returns>
        public bool InsertEntry(Dictionary<string, string> values)
        {
            if (RunGetQuery(Queries.GET_ENTRY + values["title"] + "'").Count > 0)
                return false;

            using (dbConnetion = new SqlConnection(connString))
            {
                dbConnetion.Open();

                SqlCommand cmd = new SqlCommand(Queries.ADD_ENTRY, dbConnetion);
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("Title", values["title"]));
                cmd.Parameters.Add(new SqlParameter("Description", values["description"]));
                cmd.Parameters.Add(new SqlParameter("Path", values["imgPath"]));
                cmd.Parameters.Add(new SqlParameter("Date", values["date"]));
                cmd.Parameters.Add(new SqlParameter("Age_rating", values["rating"]));
                cmd.Parameters.Add(new SqlParameter("Genres", values["genres"]));
                cmd.Parameters.Add(new SqlParameter("Score", values["score"]));
                cmd.Parameters.Add(new SqlParameter("Duration", values["duration"]));

                cmd.ExecuteNonQuery();
                dbConnetion.Close();
            }

            return true;
        }

        // Adds genre to the Genre table.
        public string AddGenre(string genre)
        {
            using (dbConnetion = new SqlConnection(connString))
            {
                dbConnetion.Open();

                SqlCommand cmd = new SqlCommand(Queries.ADD_GENRE + genre + "')", dbConnetion);
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.ExecuteNonQuery();
                dbConnetion.Close();
            }

            return GetGenreID(genre);
        }

        /// <summary>
        /// Gets the ID of a genre stroed in the Genre table. Used to
        /// add entry-genre connection.
        /// </summary>
        public string GetGenreID(string genreName)
        {
            string desiredID = "";

            try
            {
                using (dbConnetion = new SqlConnection(connString))
                {
                    dbConnetion.Open();

                    SqlCommand cmd = new SqlCommand(Queries.GET_GENRE, dbConnetion);
                    cmd.Parameters.Add(new SqlParameter("Category", genreName));

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        desiredID = reader.GetInt32(0).ToString();
                    }

                    dbConnetion.Close();

                    return desiredID;
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// Adds connection between entry and genre to the Entry_has_genre table of the database.
        /// </summary>
        public void InsertGenreConnection(string entryID, string genreID)
        {
            using (dbConnetion = new SqlConnection(connString))
            {
                dbConnetion.Open();

                SqlCommand cmd = new SqlCommand(Queries.INSERT_GENRE_CONNECTION, dbConnetion);
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("GenreID", genreID));
                cmd.Parameters.Add(new SqlParameter("EntryID", entryID));

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Used to retrieve genres for the home page with the number of entries that
        /// share those genres.
        /// </summary>
        /// <returns>List of strings in form of 'genre (count)' (eg 'Action (10)')</returns>
        public List<string> GetGenresAndCount()
        {
            try
            {
                using (dbConnetion = new SqlConnection(connString))
                {
                    dbConnetion.Open();

                    SqlCommand cmd = new SqlCommand(Queries.GET_GENRES_AND_COUNT, dbConnetion);
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<string> values = new List<string>();

                    while (reader.Read())
                    {
                        values.Add(reader.GetValue(0).ToString() + " (" + reader.GetValue(1).ToString() + ")");
                    }

                    dbConnetion.Close();

                    return values;
                }
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }

        /// <summary>
        /// Runs the given query, used to retrieve values where values need to be
        /// stored sequentially in a list.
        /// </summary>
        /// <param name="query">SQL query to run.</param>
        /// <returns>List<string> of values</returns>
        public List<string> RunGetQuery(string query)
        {
            try
            {
                using (dbConnetion = new SqlConnection(connString))
                {
                    dbConnetion.Open();

                    SqlCommand cmd = new SqlCommand(query, dbConnetion);
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<string> values = new List<string>();

                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                            values.Add(reader.GetValue(i).ToString());
                    }

                    dbConnetion.Close();

                    return values;
                }
            }
            catch (SqlException)
            { return new List<string>(); }
        }

        /// <summary>
        /// Alters the 'Note' field of the database for an entry.
        /// </summary>
        public void UpdateEntry(string entryTitle, string note)
        {
            try
            {
                using (dbConnetion = new SqlConnection(connString))
                {
                    dbConnetion.Open();

                    SqlCommand cmd = new SqlCommand(Queries.Get_UpdateNote_Query(entryTitle, note), dbConnetion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.ExecuteNonQuery();
                    dbConnetion.Close();
                }
            }
            catch (SqlException) { }
        }

        /// <summary>
        /// Deletes entry from the database.
        /// </summary>
        /// <param name="iD">ID of undesired entry.</param>
        public void DeleteEntry(string iD)
        {
            try
            {
                using (dbConnetion = new SqlConnection(connString))
                {
                    dbConnetion.Open();

                    SqlCommand cmd = new SqlCommand(Queries.GetDeleteEntryQuery(iD), dbConnetion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.ExecuteNonQuery();
                    dbConnetion.Close();
                }
            }
            catch (SqlException) { }
        }
    }
}
