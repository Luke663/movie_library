using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Rep
{
    public partial class ViewAllTilePage_UC : UserControl
    {
        private static Form1 parentForm;

        private Dictionary<ViewTile, string[]> tiles; // Master set of all database entries
        private SortedList<string, ViewTile> visibleTiles; // Currently visible/on-screen tiles

        // Maps the selected sort dropdown box text to the index of the relevant sorting info. (string[]) stored for each tile/entry in tiles.
        private Dictionary<string, int> sortTermLookup = new Dictionary<string, int>() 
        { 
            [" A - Z"] = 0,
            [" Z - A"] = 0,
            [" Score"] = 2,
            [" Date (new to old)"] = 3,
            [" Date (old to new)"] = 3
        };

        public ViewTile HIGHLIGHTED = null; // Currently highlighted tile, ensuring one at a time.

        public ViewAllTilePage_UC()
        {
            InitializeComponent();

            // Sets scroll arrows to a useable/appropriate value
            view_flowLayoutPanel.VerticalScroll.SmallChange = 200;
        }

        /// <summary>
        /// Allows the user control access to the methods of the given form.
        /// </summary>
        /// <param name="form">Instantiating form</param>
        public static void SetFormReference(Form1 form)
        {
            parentForm = form;
        }

        // Switch back to the Home page
        private void home_button_Click(object sender, EventArgs e)
        {
            parentForm.SwitchPages(Constants.GetPageIndex("HOME"));
        }

        /// <summary>
        /// Add the genres from the home page to the filter dropdown to allow filtering by genre
        /// and retrieves the entry info from the database to create/display the tiles.
        /// </summary>
        /// <param name="filters">List of genres to be used as filters</param>
        public void PopulateViewAllPage(List<string> filters)
        {
            filters_comboBox.Items.Clear();
            filters_comboBox.Items.Add(" All");

            foreach (string filter in filters)
                filters_comboBox.Items.Add(" " + filter.Split('(')[0].Trim());

            InitialiseTiles(parentForm.GetTileValues());
        }

        // Creates the dictionary of Tile objects with their stored sorting info. (string[]).
        private void InitialiseTiles(List<string> tileValues)
        {
            // tileValues = multiples of: title, path, genres, rating, date

            tiles = new Dictionary<ViewTile, string[]>();
            int numberOfReceivedFields = 5;

            for (int i = 0; i < tileValues.Count; i += numberOfReceivedFields)
            {
                ViewTile item = new ViewTile();
                item.SetValues(Image.FromFile(tileValues[i + 1]), tileValues[i], tileValues[i + 3], this);

                tiles[item] = new string[] { tileValues[i], tileValues[i + 2], tileValues[i + 3], tileValues[i + 4] }; // Title, Genres, Score, Date (For sorting)
            }

            Filter();
        }

        /// <summary>
        /// Loops through each tile in tiles to find the ones with the desired filter term,
        /// adding them to the visible tiles list for display.
        /// </summary>
        private void Filter()
        {
            visibleTiles = new SortedList<string, ViewTile>();
            string filterTerm = filters_comboBox.Text.Trim() == "All" ? "" : filters_comboBox.Text.Trim(); // Simplification: all strings contain ""

            // Loops through all tiles to find ones with the desired filter term
            foreach (KeyValuePair<ViewTile, string[]> tile in tiles)
            {
                if (tile.Value[1].Contains(filterTerm))
                {
                    string key = tile.Value[sortTermLookup[(string)sort_combobox.SelectedItem]];

                    // Adds '0' to the key to avoid duplicate key exceptions (used when sorting by score)
                    while (visibleTiles.ContainsKey(key))
                        key += "0";

                    visibleTiles.Add(key, tile.Key);
                }
            }

            // If sorting by date the collected items are reorganised correctly
            if (sortTermLookup[(string)sort_combobox.SelectedItem] == 3)
            {
                SortItemsByDate();
                return;
            }

            DisplayTiles((string)sort_combobox.SelectedItem != " A - Z");
        }

        /// <summary>
        /// Called when the ordering term is altered, reorganises the visible tiles
        /// by using the new ordering term as the key in a sorted list.
        /// </summary>
        private void ReOrderTiles()
        {
            SortedList<string, ViewTile> tempTiles = new SortedList<string, ViewTile>();

            foreach (ViewTile item in visibleTiles.Values)
            {
                string sortKey = tiles[item][sortTermLookup[(string)sort_combobox.SelectedItem]];

                // Adds '0' to the key to avoid duplicate key exceptions (used when sorting by score)
                while (tempTiles.ContainsKey(sortKey))
                    sortKey = sortKey + "0";

                tempTiles.Add(sortKey, item);
            }

            visibleTiles = tempTiles;
            DisplayTiles((string)sort_combobox.SelectedItem != " A - Z");
        }

        // Clears then re-applies the desired tiles to the panel
        private void DisplayTiles(bool reversed)
        {
            view_flowLayoutPanel.Controls.Clear();

            foreach (ViewTile item in reversed == true ? visibleTiles.Values.Reverse() : visibleTiles.Values)
                view_flowLayoutPanel.Controls.Add(item);
        }

        // Desired filter altered in filter dropdown
        private void filters_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter();
        }

        // Desired sort term altered in 'sort by' dropdown
        private void sort_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sortTermLookup[(string)sort_combobox.SelectedItem] == 3) // Sort term = date
                SortItemsByDate();
            else
                ReOrderTiles();
        }

        // Switch pages to view the clicked entry in ViewEntryPage
        public void ViewResult(string resultTitle)
        {
            parentForm.ViewEntry(resultTitle);
        }

        // Un-highlight tile, if any highlighted, when the mouse leaves the panel
        private void view_flowLayoutPanel_MouseLeave(object sender, EventArgs e)
        {
            if (HIGHLIGHTED == null)
                return;

            HIGHLIGHTED.RevertHighlight();
            HIGHLIGHTED = null;
        }

        /// <summary>
        /// Converts 'date' string to a DateTime object to sort the tiles appropriately before
        /// using the correct ordering to apply the list back to the visibleTiles<string, ViewTile>
        /// list via an integer.
        /// </summary>
        private void SortItemsByDate()
        {
            SortedList<DateTime, ViewTile> tmpViewItems_date = new SortedList<DateTime, ViewTile>();

            // Reorganise visible tiles by their date
            foreach (ViewTile item in visibleTiles.Values)
            {
                string date = tiles[item][3].Split('–')[0].Trim();
                DateTime convertedDate = new DateTime(Convert.ToInt32(date), 1, 1);

                // Add seconds to avoid duplicate keys
                while (tmpViewItems_date.ContainsKey(convertedDate))
                    convertedDate += TimeSpan.FromSeconds(1);

                tmpViewItems_date.Add(convertedDate, item);
            }

            // Temp list with custom comparer to apply natural ordering of date terms (0, 5, 20 not 0, 20, 5)
            SortedList<string, ViewTile> tmpViewItems = new SortedList<string, ViewTile>(
                Comparer<string>.Create((x, y) => Convert.ToInt32(x).CompareTo(Convert.ToInt32(y)))
                );

            // Maintain date ordering with integer to make applicable to visibleTiles (SortedList<string, ViewTile>)
            for (int i = 0; i < tmpViewItems_date.Values.Count; i++)
                tmpViewItems.Add(i.ToString(), tmpViewItems_date.Values[i]);

            visibleTiles = tmpViewItems;

            DisplayTiles((string)(sort_combobox.SelectedItem) == " Date (new to old)");
        }
    }
}
