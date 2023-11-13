using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rep
{
    public partial class Form1 : Form
    {
        private UserControl[] pages = new UserControl[Constants.NUMBER_OF_PAGES];
        private Database dB;
        
        // Track pages
        public static int lastPage = 0;
        public static int currentPage = 0;

        // Tracks alterations to database so relevant info can be updated (genre list on home page and view all page)
        private static bool DATABASE_ALTERATION_MADE = true;

        public Form1()
        {
            InitializeComponent();

            dB = Database.GetInstance();

            HomePage_UC.SetFormReference(this);
            SearchResultsPage_UC.SetFormReference(this);
            ViewEntryPage_UC.SetFormReference(this);
            ViewAllTilePage_UC.SetFormReference(this);

            pages[0] = homePage_UC1;
            pages[1] = searchResultsPage_UC1;
            pages[2] = viewEntryPage_UC1;
            pages[3] = viewAllTilePage_UC1;

            homePage_UC1.Enabled = false;

            SwitchPages(Constants.GetPageIndex("HOME"));
        }

        /// <summary>
        /// Switches to the desired page (UserControl) hiding the current page in the process
        /// </summary>
        /// <param name="desiredPage">int: index of the desired page in: UserControl[] pages</param>
        public void SwitchPages(int desiredPage)
        {
            ShowPage(desiredPage);

            if (desiredPage != currentPage)
                HidePage(currentPage);

            lastPage = currentPage;
            currentPage = desiredPage;
        }

        // Shows the desired page (UserControl) when switching to a different page
        private void ShowPage(int desiredPage)
        {
            pages[desiredPage].Show();
            pages[desiredPage].Enabled = true;
            pages[desiredPage].BringToFront();
        }

        // Hides the desired page (UserControl) when switching to a different page
        private void HidePage(int visiblePage)
        {
            pages[visiblePage].Hide();
            pages[visiblePage].Enabled = false;
        }

        // Used to step back a page (saves having to re-run searches or re-apply filters/sort operations)
        public void GoBack()
        {
            SwitchPages(lastPage);
        }

        // Runs search for a user entered term, passing all entries matching the term to the display search results method.
        public void RunSearch(string searchTerm)
        {
            List<string> searchResults = dB.RunGetQuery(Queries.SEARCH_GENERIC + searchTerm.Replace('*', '%') + "%'");

            DisplaySearchResults(searchTerm, searchResults);
        }

        // Runs search for a genre, passing all entries of the selected genre to the display search results method.
        public void SelectGenre(string genre)
        {
            DisplaySearchResults(genre, dB.RunGetQuery(Queries.GET_GENRE_ENTRIES + genre + "'"));
        }

        // Switches to the view entry page, setting the relevant page aspects (title, image...) as needed
        private void DisplaySearchResults(string searchTerm, List<string> results)
        {
            searchResultsPage_UC1.SetSearchResults(searchTerm, results);
            SwitchPages(Constants.GetPageIndex("SEARCH"));
        }

        /// <summary>
        /// Called at start-up or after adding/removing an entry to load the genres list (home page)
        /// and the view all page's tiles and filter terms.
        /// </summary>
        public void PrepareHomePage()
        {
            if (!DATABASE_ALTERATION_MADE)
                return;

            DATABASE_ALTERATION_MADE = false;

            List<string> genres = dB.GetGenresAndCount();

            homePage_UC1.LoadPage(genres);
            viewAllTilePage_UC1.PopulateViewAllPage(genres);
        }

        // Calls to view the selected entry, retrieving entry info from the database.
        public void ViewEntry(string entryName)
        {
            DislayResult(dB.RunGetQuery(Queries.GET_ENTRY + entryName + "'"));
        }

        // Calls to view a random entry, retrieving entry info from the database.
        public void FindRandomEntry()
        {
            DislayResult(dB.RunGetQuery(Queries.GET_RANDOM_ENTRY));
        }

        /// <summary>
        /// Switches to ViewEntryPage to view the selected entry. Reloading the home and view all
        /// pages can take time after a scrape operation (as the number of entries grows) this method
        /// pauses for a second to allow the ViewEntryPage to load before begining the reload process
        /// in the background. Allowing the work of the reloading to be done in the background reducing
        /// the effect on the user.
        /// </summary>
        /// <param name="resultValues">List of strings, each field from the database for desired entry.</param>
        private async void DislayResult(List<string> resultValues)
        {
            viewEntryPage_UC1.DisplayResult(resultValues);
            SwitchPages(Constants.GetPageIndex("RESULT"));

            await Task.Delay(500); // Allows the result's page to load fully before re-loading new database info in the background
            PrepareHomePage();
        }

        /// <summary>
        /// Uses provided URL and the Scraper class to scrape the required info
        /// from the desired page then displays the entry if successful.
        /// </summary>
        public void HomePageScrapeEntry(string entryURL)
        {
            DATABASE_ALTERATION_MADE = true;

            Scraper scraper = new Scraper();
            string entryTitle = scraper.ScrapeEntry(entryURL);

            if (entryTitle == "ERROR")
            {
                MessageBox.Show("An invalid address was entered.");
                return;
            }

            ViewEntry(entryTitle);
        }

        /// <summary>
        /// Used by ViewAllTilePage to query database for the title, image path,
        /// genres, rating and date of all entries currently in the database.
        /// </summary>
        /// <returns>List<string> of all database entries (multiples of: title,
        /// image path, genres, rating and date)</returns>
        public List<string> GetTileValues()
        {
            return dB.RunGetQuery(Queries.GET_ALL_TILES);
        }

        /// <summary>
        /// Called by ViewEntryPage to alter the 'Note' field (in database) of
        /// the entry currently being viewed.
        /// </summary>
        /// <param name="entryTitle">Name of entry being viewed.</param>
        /// <param name="updatedNote">New text value to be stored as note.</param>
        public void UpdateEntryNote(string entryTitle, string updatedNote)
        {
            dB.UpdateEntry(entryTitle, updatedNote);
        }

        public void DeleteEntryFromDB(string iD)
        {
            DATABASE_ALTERATION_MADE = true;
            dB.DeleteEntry(iD);
        }
    }
}