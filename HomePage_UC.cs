using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Rep
{
    public partial class HomePage_UC : UserControl
    {
        private static Form1 parentForm;

        public HomePage_UC()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Allows the user control access to the methods of the given form.
        /// </summary>
        /// <param name="form">Instantiating form</param>
        public static void SetFormReference(Form1 form)
        {
            parentForm = form;
        }

        // Adds the given genre list to the listview
        public void LoadPage(List<string> genres)
        {
            homePage_genre_listView.Items.Clear();

            foreach (string genre in genres)
                homePage_genre_listView.Items.Add(genre);
        }

        // Extract the text of the clicked genre from the genre listview then performs a search for entries matching it
        private void homePage_genre_listview_clicked(object sender, MouseEventArgs e)
        {
            string genre = (((ListView)sender).SelectedItems[0].Text).Split(' ')[0];
            ((ListView)sender).SelectedItems.Clear();

            parentForm.SelectGenre(genre);
        }

        /// <summary>
        /// Removes any text previously entered in the home page then calls Form1 to
        /// check for database alterations. If any have been made the home page (genres)
        /// and the view all page are re-loaded.
        /// </summary>
        private void Home_EnabledChanged(object sender, EventArgs e)
        {
            search_textBox.Text = "";
            add_textBox.Text = "";

            if (this.Enabled == true)
                parentForm.PrepareHomePage();
        }

        // Run search for term entered
        private void search_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                parentForm.RunSearch(search_textBox.Text);
            }
        }

        // Scrape entry using user entered URL
        private void add_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                parentForm.HomePageScrapeEntry(add_textBox.Text);
            }
        }

        // Display random entry from database
        private void random_button_Click(object sender, EventArgs e)
        {
            parentForm.FindRandomEntry();
        }

        // Switch to tile page
        private void viewall_button_Click(object sender, EventArgs e)
        {
            parentForm.SwitchPages(Constants.GetPageIndex("VIEW_ALL"));
        }
    }
}
