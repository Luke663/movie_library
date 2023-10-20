using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Rep
{
    public partial class SearchResultsPage_UC : UserControl
    {
        private static Form1 parentForm;
        private SortedList<string, SearchResult> searchItems;

        public SearchResult HIGHLIGHTED = null; // Currently highlighted search result

        public SearchResultsPage_UC()
        {
            InitializeComponent();

            // Alter scroll bar arrows to appropriate value
            searchresults_flowpanel.VerticalScroll.SmallChange = 100;
        }

        /// <summary>
        /// Allows the user control access to the methods of the given form.
        /// </summary>
        /// <param name="form">Instantiating form</param>
        public static void SetFormReference(Form1 form)
        {
            parentForm = form;
        }

        /// <summary>
        /// Instantiates the search result items for the searched term, sizing them appropriately.
        /// </summary>
        /// <param name="searchTerm">What the user searched for.</param>
        /// <param name="searchResults">Database query results.</param>
        public void SetSearchResults(string searchTerm, List<string> searchResults)
        {
            // searchResults: continuous list of values (ID, Title, Description, Path, Date, Age_rating, Genres, Score, Duration, Note)
            searchResult_textBox.Text = searchTerm;

            searchItems = new SortedList<string, SearchResult>();

            for (int i = 0; i < searchResults.Count; i += Constants.NUMBER_OF_ENTRY_FIELDS)
            {
                SearchResult item = new SearchResult();
                item.Width = Constants.SEARCH_RESULT_ITEM_SIZE_SMALL;
                item.SetValues(Image.FromFile(searchResults[i + 3]), searchResults[i + 1], searchResults[i + 6], searchResults[i + 7], searchResults[i + 4], searchResults[i + 8], this);

                searchItems.Add(searchResults[i + 1], item);
            }

            // If less than 4 results, the scroll bar is not shown. This widens the result to fill the space
            if (searchItems.Count < 4)
                foreach (SearchResult item in searchItems.Values)
                    item.Width = Constants.SEARCH_RESULT_ITEM_SIZE_LARGE;

            AddSearchItems(false);
        }

        // Switch to the home page
        private void home_button_Click(object sender, EventArgs e)
        {
            parentForm.SwitchPages(Constants.GetPageIndex("HOME"));
        }

        // Search database for the newly entered search term
        private void searchResult_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                parentForm.RunSearch(searchResult_textBox.Text);
            }
        }

        // Adds the search results to the panel making them visible
        private void AddSearchItems(bool reverse)
        {
            searchresults_flowpanel.Controls.Clear();

            foreach (SearchResult item in reverse == false ? searchItems.Values : searchItems.Values.Reverse())
                searchresults_flowpanel.Controls.Add(item);
        }

        /// <summary>
        /// Depending on the currently selected sort term (sort_combobox text) loops through
        /// the search results using the slected field info to sort them via the SortedList oject.
        /// </summary>
        private void sort_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SortedList<string, SearchResult> tmpSearchItems = new SortedList<string, SearchResult>();

            bool reverseListValues = false;

            switch (sort_combobox.SelectedItem)
            {
                case " A - Z":
                case " Z - A":
                    foreach (SearchResult item in searchItems.Values)
                        tmpSearchItems.Add(item.GetTitle(), item);

                    reverseListValues = (string)sort_combobox.SelectedItem == " A - Z" ? false : true;
                    break;

                case " Score":
                    foreach (SearchResult item in searchItems.Values)
                    {
                        string score = item.GetScore();

                        // Add '0' to avoid duplicate keys
                        while (tmpSearchItems.ContainsKey(score))
                            score = score + "0";

                        tmpSearchItems.Add(score, item);
                    }

                    reverseListValues = true;
                    break;

                case " Date (old to new)":
                case " Date (new to old)":
                    tmpSearchItems = SortByDate();
                    reverseListValues = (string)(sort_combobox.SelectedItem) == " Date (new to old)";
                    break;
            }

            searchItems = tmpSearchItems;
            AddSearchItems(reverseListValues);
        }

        // Switch to ViewEntry page to see the page for the clicked search result
        public void SelectResult(string resultTitle)
        {
            parentForm.ViewEntry(resultTitle);
        }

        /// <summary>
        /// Converts 'date' string to a DateTime object to sort the results appropriately before
        /// using the correct ordering to apply the list back to the searchItems<string, SearchResult>
        /// list via an integer.
        /// </summary>
        private SortedList<string, SearchResult> SortByDate()
        {
            SortedList<DateTime, SearchResult> tmpSearchItems_date = new SortedList<DateTime, SearchResult>();

            // Reorganise results by their date
            foreach (SearchResult searchItem in searchItems.Values)
            {
                string date = searchItem.GetDate().Split('–')[0].Trim(); // Removes 'until' date (if one), values calculated by start date
                DateTime convertedDate = new DateTime(Convert.ToInt32(date), 1, 1);

                // Adds seconds to DateTime object to avoid duplicate keys
                while (tmpSearchItems_date.ContainsKey(convertedDate))
                    convertedDate += TimeSpan.FromSeconds(1);

                tmpSearchItems_date.Add(convertedDate, searchItem);
            }

            // Temp list with custom comparer to apply natural ordering of date terms (0, 5, 20 not 0, 20, 5)
            SortedList<string, SearchResult> tmpSearchItems = new SortedList<string, SearchResult>(
                Comparer<string>.Create((x, y) => Convert.ToInt32(x).CompareTo(Convert.ToInt32(y)))
                );

            // Maintain date ordering with integer to make applicable to searchItems (<string, SearchResult>)
            for (int i = 0; i < tmpSearchItems_date.Values.Count; i++)
                tmpSearchItems.Add(i.ToString(), tmpSearchItems_date.Values[i]);

            return tmpSearchItems;
        }

        // Remove highlight from result (if any) when mouse leaves panel
        private void searchresults_flowpanel_MouseLeave(object sender, EventArgs e)
        {
            if (HIGHLIGHTED == null)
                return;

            HIGHLIGHTED.RevertHighlight();
            HIGHLIGHTED = null;
        }
    }
}
