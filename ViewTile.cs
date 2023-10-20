using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rep
{
    public partial class ViewTile : UserControl
    {
        private static ViewAllTilePage_UC PARENT = null;
        private string myTitle = "";

        public ViewTile()
        {
            InitializeComponent();
            ReparentScoreLabel();
        }

        private void ReparentScoreLabel()
        {
            // Transparent background of label uses the ViewTile not the Image, making the background
            // grey. This re-parents the score label to the image making its background transparent.

            var pos = score_label.Parent.PointToScreen(score_label.Location);
            pos = item_pictureBox.PointToClient(pos);
            score_label.Parent = item_pictureBox;
            score_label.Location = pos;
            score_label.BackColor = Color.Transparent;
        }

        /// <summary>
        /// Sets the visual aspects of the tile (title, image...).
        /// </summary>
        /// <param name="img">Image to be displayed.</param>
        /// <param name="title">Title of entry displayed.</param>
        /// <param name="score">Entry's score.</param>
        /// <param name="_parent">Reference of the instantiating object (ViewAllTilePage_UC).</param>
        public void SetValues(Image img, string title, string score, ViewAllTilePage_UC parent)
        {
            item_pictureBox.Image = img;
            myTitle = title;

            if (title.Length > 37)
                title = title.Substring(0, 37) + "...";

            title_textBox.Text = title;
            score_label.Text = score;

            if (PARENT == null)
                PARENT = parent;
        }

        // View entry when clicked
        private void item_Click(object sender, EventArgs e)
        {
            PARENT.ViewResult(myTitle);
        }

        // Highlight hovered-over tile
        private void ViewAllItem_MouseEnter(object sender, EventArgs e)
        {
            HandleHighlight();
        }

        // Highlights tile while maintaining the parent user control's (ViewAllTilePage_UC) HIGHLIGTED variable
        // (prevents multiple tiles being highlighted due to missed events caused by scrolling).
        private void HandleHighlight()
        {
            if (PARENT.HIGHLIGHTED != null)
                PARENT.HIGHLIGHTED.RevertHighlight();

            Highlight(this, title_textBox, Color.Gold, Color.Gold, Color.Black);

            PARENT.HIGHLIGHTED = this;
        }

        /// <summary>
        /// Sets the apperance of the tile, can be used to apply or remove highlighting.
        /// </summary>
        private void Highlight(ViewTile item, TextBox itemTitle, Color tileBackColour, Color textBackColour, Color foreColour)
        {
            item.BackColor = tileBackColour;
            itemTitle.BackColor = textBackColour;
            itemTitle.ForeColor = foreColour;
        }

        /// <summary>
        /// Removes highlighting that has been applied.
        /// </summary>
        public void RevertHighlight()
        {
            Highlight(this, title_textBox, Color.Transparent, Constants.THEME_COLOUR, Constants.TEXT_COLOUR);
        }
    }
}
