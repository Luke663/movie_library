using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Rep
{
    public partial class ViewEntryPage_UC : UserControl
    {
        private static Form1 parentForm;
        private string currentNote; // Reference of note state to check for alteration

        private string entryID; // ID reference for deletion

        public ViewEntryPage_UC()
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

        // Sets the page's text, image.. values to those of the passed entry.
        public void DisplayResult(List<string> result)
        {
            // Reset title font if alterrations were previously needed (re-sizing)
            results_title_textBox.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold | FontStyle.Underline);

            entryID = result[0];
            results_title_textBox.Text = result[1];
            results_pictureBox.Image = Image.FromFile(result[3]);
            description_richTextBox.Text = result[2];
            score_label.Text = result[7].Length == 1 ? " " + result[7] : result[7];
            date_var_label.Text = result[4];
            genre_var_label.Text = result[6];
            rating_label.Text = result[5].Length == 1 ? " " + result[5] : result[5];
            resultepisodes_label.Text = result[8];
            notes_textBox.Text = result[9];
            currentNote = result[9];


            // Resize entry title until it fits the given space
            while (CreateGraphics().MeasureString(results_title_textBox.Text, results_title_textBox.Font).Width > 900)
            {
                int newFontSize = (int)results_title_textBox.Font.Size - 1;
                results_title_textBox.Font = new Font("Microsoft Sans Serif", newFontSize, FontStyle.Bold | FontStyle.Underline);
            }
        }

        // Switches the user to the home page after checking for any note alterations.
        private void home_button_Click(object sender, EventArgs e)
        {
            CheckForNote();
            parentForm.SwitchPages(Constants.GetPageIndex("HOME"));
        }

        // Switches the user back to the previous page after checking for any note alterations.
        private void back_button_Click(object sender, EventArgs e)
        {
            CheckForNote();
            parentForm.GoBack();
        }

        /// <summary>
        /// If the entry's note text is not the same as what is stored this updates
        /// the database with the new text/lack of text.
        /// </summary>
        private void CheckForNote()
        {
            if (notes_textBox.Text != currentNote)
            {
                parentForm.UpdateEntryNote(results_title_textBox.Text, notes_textBox.Text);
                currentNote = notes_textBox.Text;
            }
        }

        // Allows user to have the note field of the current entry updated by pressing 'enter'.
        private void notes_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                CheckForNote();
            }
        }

        /// <summary>
        /// Removes the the entry from the database and switches the user back to the home page
        /// if the user confirms the delete operation.
        /// </summary>
        private void delete_button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this entry?\nThis cannot be undone.", "Confirm delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                parentForm.DeleteEntryFromDB(entryID);
                parentForm.SwitchPages(Constants.GetPageIndex("HOME"));
            }
        }
    }
}
