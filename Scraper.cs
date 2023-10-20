using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace Rep
{
    class Scraper
    {
        private Database model = Database.GetInstance();

        /// <summary>
        /// Complies the dictionary of values for the entry to be then added into the database.
        /// </summary>
        /// <param name="entry_url">URL of the desired imbd page for a particular movie/series.</param>
        /// <returns>String: the name of the given entry for display.</returns>
        public string ScrapeEntry(string entry_url)
        {
            HtmlDocument document = GetDocument(entry_url);

            if (document == null || !entry_url.Contains("www.imdb.com"))
                return "ERROR";

            Dictionary<string, string> values = new Dictionary<string, string>();

            values["title"] = ExtractText(document, Xpaths.TITLE);
            values["imgPath"] = DownloadImage(ExtractImageURL(document, Xpaths.IMAGE), values["title"]);
            values["description"] = ExtractText(document, Xpaths.DESCRIPTION);
            values["score"] = ExtractText(document, Xpaths.SCORE);

            // The date, rating and duration are displayed together so must be collected as a single string ("1994U1h 28m")
            string date_rating_duration = ExtractText(document, Xpaths.SECONDARY);
            string duration = ExtractDuration(date_rating_duration);

            values["duration"] = "Duration: " + duration;
            date_rating_duration = date_rating_duration.Replace(duration, "");

            values["date"] = ExtractDate(date_rating_duration);
            date_rating_duration = date_rating_duration.Replace(values["date"], "");

            // Check for 'TV' in string meaning entry is a series. If so this replaces the duration text (Duration: 1h 24m)
            // with episode text (Episodes: 24).
            if (date_rating_duration.Contains("TV"))
            {
                date_rating_duration = date_rating_duration.Replace("TV Series", "").Replace("TV Mini Series", "");
                values["duration"] = "Episodes: " + ExtractText(document, Xpaths.EPISODES);
            }

            values["rating"] = date_rating_duration;

            List<string> genres = new List<string>();
            string genres_text = ExtractText(document, Xpaths.GENRES);

            values["genres"] = ExtractGenres(genres_text, ref genres);

            // Insert entry into database
            bool successfulInsert = model.InsertEntry(values);

            // If this fails or the entry is already in the database the method ends here
            if (!successfulInsert)
                return values["title"];

            string entryID = model.RunGetQuery(Queries.GET_ENTRY + values["title"] + "'")[0];

            foreach (string genre in genres)
                if (genre != "")
                    HandleGenre(genre, entryID);


            return values["title"];
        }

        private string ExtractDuration(string date_rating_duration)
        {
            Regex r = new Regex(@"([0-9]h\s)?([0-9]{2}m)"); // Find mins (42m) or both (1h 42m)
            Regex r2 = new Regex(@"([0-9]h)"); // Find hours only (2h)

            string retString = r.Match(date_rating_duration).ToString();

            return retString == "" ? r2.Match(date_rating_duration).ToString() : retString;
        }

        /// <summary>
        /// Retrieves the entry's release date (for simplification this needs to be done
        /// after duration has been removed from the combined date_rating_duration string).
        /// </summary>
        private string ExtractDate(string date_rating)
        {
            Regex r = new Regex(@"[0-9]{4}–?(\s)?([0-9]{4})?");

            return r.Match(date_rating).ToString();
        }

        private string ExtractGenres(string genreText, ref List<string> genres)
        {
            string dbText = "";
            string[] alternates = new string[] { "Sci-Fi", "Film-Noir", "Reality-TV", "Game-Show" };

            // To simplify parsing this looks for known variations on the typical capital letter folowed by lower case.
            foreach (string alt in alternates)
            {
                if (genreText.Contains(alt))
                {
                    dbText = dbText + alt + ", ";
                    genreText = genreText.Replace(alt, "");

                    genres.Add(alt);
                }
            }

            // Regex to extract each genre (eg Action) adding them to a list for individual processing
            // and to the entry's own (string) record.
            Regex r = new Regex(@"[A-Z][a-z]+");
            MatchCollection matches = r.Matches(genreText);

            foreach (Match match in matches)
            {
                genres.Add(match.ToString());
                dbText = dbText + match.ToString() + ", ";
            }

            return dbText.Trim(new char[] { ' ', ','});
        }

        private HtmlDocument GetDocument(string url)
        {
            HtmlWeb web = new HtmlWeb();

            try
            {
                return web.Load(url);
            }
            catch (UriFormatException)
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves the desired text from the given document via the given X-Path.
        /// (replacing characters as needed due to HtmlAgilityPack's formatting)
        /// </summary>
        private string ExtractText(HtmlDocument document, string xPath)
        {
            if (document.DocumentNode.SelectSingleNode(xPath) != null)
                return document.DocumentNode.SelectSingleNode(xPath).InnerText.Replace("&quot;", "\"").Replace("&#039;", "'").Replace("&mdash;", " - ").Replace("&iuml;", "i").Replace("&#x27;", "'");

            return "";
        }

        private string ExtractImageURL(HtmlDocument document, string xPath)
        {
            return document.DocumentNode.SelectSingleNode(xPath).Attributes["src"].Value;
        }

        /// <summary>
        /// Save image file to 'pics' folder, removing invalid characters where needed.
        /// </summary>
        private string DownloadImage(string imageURL, string entry_title)
        {
            char[] restrictedCharacters = new char[] { '<', '>', ':', '\"', '/', '\\', '|', '?', '*' };

            foreach (char chara in restrictedCharacters)
                entry_title = entry_title.Replace(chara, '-');

            string imagePath = "pics/" + entry_title + ".jpg";

            WebClient client = new WebClient();
            client.DownloadFile(imageURL, imagePath);

            return imagePath;
        }

        /// <summary>
        /// Adds the genre-entry connection to the database, also adding the
        /// genre if it is not already in the database.
        /// </summary>
        private void HandleGenre(string genre, string entryID)
        {
            string genreID = model.GetGenreID(genre);

            if (genreID == "")
                genreID = model.AddGenre(genre);

            model.InsertGenreConnection(entryID, genreID);
        }
    }
}
