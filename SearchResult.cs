using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rep
{
    public partial class SearchResult : UserControl
    {
        private static SearchResultsPage_UC PARENT = null;

        public SearchResult()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the visual aspects of the search result object.
        /// </summary>
        public void SetValues(Image pic, string title, string genreText, string score, string date, string episodes, SearchResultsPage_UC parent)
        {
            resulttitle_label.Text = title;
            result_pictureBox.Image = pic;
            resultgenre_label.Text = "Genres: " + genreText;
            resultscore_label.Text = score + " /10";
            resultdate_label.Text = "Date: " + date;
            episodes_label.Text = episodes;

            if (PARENT == null)
                PARENT = parent;
        }

        /// <summary>
        /// Displays the selected entry via the VeiwEntryPage when search result is clicked.
        /// </summary>
        private void SearchResultItem_Click(object sender, EventArgs e)
        {
            PARENT.SelectResult(resulttitle_label.Text);
        }

        // Highlight hovered-over result
        private void SearchResultItem_MouseEnter(object sender, EventArgs e)
        {
            HandleHighlight();
        }

        // Highlights result while maintaining the parent user control's (SearchResultsPage_UC) HIGHLIGTED variable
        // (prevents multiple results being highlighted due to missed events caused by scrolling).
        private void HandleHighlight()
        {
            if (PARENT.HIGHLIGHTED != null)
                PARENT.HIGHLIGHTED.RevertHighlight();

            Highlight(this, resulttitle_label, Color.Gold, Color.Black);

            PARENT.HIGHLIGHTED = this;
        }

        /// <summary>
        /// Sets the apperance of the tile, can be used to apply or remove highlighting.
        /// </summary>
        private void Highlight(SearchResult item, Label itemLabel, Color backColour, Color foreColour)
        {
            item.BackColor = backColour;
            itemLabel.BackColor = backColour;
            itemLabel.ForeColor = foreColour;
        }

        /// <summary>
        /// Removes highlighting that has been applied.
        /// </summary>
        public void RevertHighlight()
        {
            Highlight(this, resulttitle_label, Constants.BACKGROUND_COLOUR, Constants.TEXT_COLOUR);
        }

        public string GetTitle()
        {
            return resulttitle_label.Text;
        }

        public string GetScore()
        {
            return resultscore_label.Text.Split(' ')[0];
        }

        public string GetDate()
        {
            return resultdate_label.Text.Replace("Date:", "").Trim();
        }
    }
}
