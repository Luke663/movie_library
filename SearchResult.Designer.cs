
namespace Rep
{
    partial class SearchResult
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.episodes_label = new System.Windows.Forms.Label();
            this.resulttitle_label = new System.Windows.Forms.Label();
            this.resultgenre_label = new System.Windows.Forms.Label();
            this.resultdate_label = new System.Windows.Forms.Label();
            this.resultscore_label = new System.Windows.Forms.Label();
            this.result_pictureBox = new System.Windows.Forms.PictureBox();
            this.score_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.result_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // episodes_label
            // 
            this.episodes_label.AutoSize = true;
            this.episodes_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.episodes_label.Location = new System.Drawing.Point(95, 71);
            this.episodes_label.Name = "episodes_label";
            this.episodes_label.Size = new System.Drawing.Size(74, 13);
            this.episodes_label.TabIndex = 14;
            this.episodes_label.Text = "Episodes: 102";
            this.episodes_label.Click += new System.EventHandler(this.SearchResultItem_Click);
            // 
            // resulttitle_label
            // 
            this.resulttitle_label.AutoSize = true;
            this.resulttitle_label.BackColor = System.Drawing.Color.Transparent;
            this.resulttitle_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resulttitle_label.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.resulttitle_label.Location = new System.Drawing.Point(102, 13);
            this.resulttitle_label.MaximumSize = new System.Drawing.Size(550, 0);
            this.resulttitle_label.Name = "resulttitle_label";
            this.resulttitle_label.Size = new System.Drawing.Size(174, 25);
            this.resulttitle_label.TabIndex = 13;
            this.resulttitle_label.Text = "Title Placeholder";
            this.resulttitle_label.UseMnemonic = false;
            this.resulttitle_label.Click += new System.EventHandler(this.SearchResultItem_Click);
            // 
            // resultgenre_label
            // 
            this.resultgenre_label.AutoSize = true;
            this.resultgenre_label.BackColor = System.Drawing.Color.Transparent;
            this.resultgenre_label.Location = new System.Drawing.Point(439, 71);
            this.resultgenre_label.Name = "resultgenre_label";
            this.resultgenre_label.Size = new System.Drawing.Size(267, 13);
            this.resultgenre_label.TabIndex = 10;
            this.resultgenre_label.Text = "Genres: Action, Adventure, Mystery, Horror, Martial Arts";
            this.resultgenre_label.Click += new System.EventHandler(this.SearchResultItem_Click);
            // 
            // resultdate_label
            // 
            this.resultdate_label.AutoSize = true;
            this.resultdate_label.BackColor = System.Drawing.Color.Transparent;
            this.resultdate_label.Location = new System.Drawing.Point(210, 71);
            this.resultdate_label.Name = "resultdate_label";
            this.resultdate_label.Size = new System.Drawing.Size(170, 13);
            this.resultdate_label.TabIndex = 12;
            this.resultdate_label.Text = "Date: 12 Jan 2000 to 12 Feb 2000";
            this.resultdate_label.Click += new System.EventHandler(this.SearchResultItem_Click);
            // 
            // resultscore_label
            // 
            this.resultscore_label.AutoSize = true;
            this.resultscore_label.BackColor = System.Drawing.Color.Transparent;
            this.resultscore_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultscore_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.resultscore_label.Location = new System.Drawing.Point(668, 33);
            this.resultscore_label.Name = "resultscore_label";
            this.resultscore_label.Size = new System.Drawing.Size(83, 25);
            this.resultscore_label.TabIndex = 11;
            this.resultscore_label.Text = "7.99 /10";
            this.resultscore_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.resultscore_label.Click += new System.EventHandler(this.SearchResultItem_Click);
            // 
            // result_pictureBox
            // 
            this.result_pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.result_pictureBox.Location = new System.Drawing.Point(3, 4);
            this.result_pictureBox.MaximumSize = new System.Drawing.Size(76, 85);
            this.result_pictureBox.Name = "result_pictureBox";
            this.result_pictureBox.Size = new System.Drawing.Size(65, 85);
            this.result_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.result_pictureBox.TabIndex = 9;
            this.result_pictureBox.TabStop = false;
            this.result_pictureBox.Click += new System.EventHandler(this.SearchResultItem_Click);
            // 
            // score_label
            // 
            this.score_label.AutoSize = true;
            this.score_label.BackColor = System.Drawing.Color.Transparent;
            this.score_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.score_label.Location = new System.Drawing.Point(604, 33);
            this.score_label.Name = "score_label";
            this.score_label.Size = new System.Drawing.Size(70, 25);
            this.score_label.TabIndex = 15;
            this.score_label.Text = "Score:";
            this.score_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SearchResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.score_label);
            this.Controls.Add(this.episodes_label);
            this.Controls.Add(this.resulttitle_label);
            this.Controls.Add(this.resultgenre_label);
            this.Controls.Add(this.resultdate_label);
            this.Controls.Add(this.resultscore_label);
            this.Controls.Add(this.result_pictureBox);
            this.DoubleBuffered = true;
            this.Name = "SearchResult";
            this.Size = new System.Drawing.Size(763, 92);
            this.Click += new System.EventHandler(this.SearchResultItem_Click);
            this.MouseEnter += new System.EventHandler(this.SearchResultItem_MouseEnter);
            ((System.ComponentModel.ISupportInitialize)(this.result_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label episodes_label;
        private System.Windows.Forms.Label resulttitle_label;
        private System.Windows.Forms.Label resultgenre_label;
        private System.Windows.Forms.Label resultdate_label;
        private System.Windows.Forms.Label resultscore_label;
        private System.Windows.Forms.PictureBox result_pictureBox;
        private System.Windows.Forms.Label score_label;
    }
}
