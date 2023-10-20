
namespace Rep
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.viewAllTilePage_UC1 = new Rep.ViewAllTilePage_UC();
            this.viewEntryPage_UC1 = new Rep.ViewEntryPage_UC();
            this.searchResultsPage_UC1 = new Rep.SearchResultsPage_UC();
            this.homePage_UC1 = new Rep.HomePage_UC();
            this.SuspendLayout();
            // 
            // viewAllTilePage_UC1
            // 
            this.viewAllTilePage_UC1.BackColor = System.Drawing.Color.Transparent;
            this.viewAllTilePage_UC1.Enabled = false;
            this.viewAllTilePage_UC1.Location = new System.Drawing.Point(0, 0);
            this.viewAllTilePage_UC1.Name = "viewAllTilePage_UC1";
            this.viewAllTilePage_UC1.Size = new System.Drawing.Size(856, 568);
            this.viewAllTilePage_UC1.TabIndex = 3;
            // 
            // viewEntryPage_UC1
            // 
            this.viewEntryPage_UC1.BackColor = System.Drawing.Color.Transparent;
            this.viewEntryPage_UC1.Enabled = false;
            this.viewEntryPage_UC1.Location = new System.Drawing.Point(0, 0);
            this.viewEntryPage_UC1.Name = "viewEntryPage_UC1";
            this.viewEntryPage_UC1.Size = new System.Drawing.Size(856, 568);
            this.viewEntryPage_UC1.TabIndex = 2;
            // 
            // searchResultsPage_UC1
            // 
            this.searchResultsPage_UC1.BackColor = System.Drawing.Color.Transparent;
            this.searchResultsPage_UC1.Enabled = false;
            this.searchResultsPage_UC1.Location = new System.Drawing.Point(0, 0);
            this.searchResultsPage_UC1.Name = "searchResultsPage_UC1";
            this.searchResultsPage_UC1.Size = new System.Drawing.Size(856, 568);
            this.searchResultsPage_UC1.TabIndex = 1;
            // 
            // homePage_UC1
            // 
            this.homePage_UC1.BackColor = System.Drawing.Color.Transparent;
            this.homePage_UC1.Location = new System.Drawing.Point(0, 0);
            this.homePage_UC1.Name = "homePage_UC1";
            this.homePage_UC1.Size = new System.Drawing.Size(856, 568);
            this.homePage_UC1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(856, 567);
            this.Controls.Add(this.viewAllTilePage_UC1);
            this.Controls.Add(this.viewEntryPage_UC1);
            this.Controls.Add(this.searchResultsPage_UC1);
            this.Controls.Add(this.homePage_UC1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library";
            this.ResumeLayout(false);

        }

        #endregion

        private HomePage_UC homePage_UC1;
        private SearchResultsPage_UC searchResultsPage_UC1;
        private ViewEntryPage_UC viewEntryPage_UC1;
        private ViewAllTilePage_UC viewAllTilePage_UC1;
    }
}

