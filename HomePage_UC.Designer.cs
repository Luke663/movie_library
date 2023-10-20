
namespace Rep
{
    partial class HomePage_UC
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
            this.viewall_button = new System.Windows.Forms.Button();
            this.homePage_genre_listView = new System.Windows.Forms.ListView();
            this.search_textBox = new System.Windows.Forms.TextBox();
            this.random_button = new System.Windows.Forms.Button();
            this.genres_label = new System.Windows.Forms.Label();
            this.search_label = new System.Windows.Forms.Label();
            this.add_textBox = new System.Windows.Forms.TextBox();
            this.add_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // viewall_button
            // 
            this.viewall_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.viewall_button.Font = new System.Drawing.Font("Sitka Text", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewall_button.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.viewall_button.Location = new System.Drawing.Point(124, 442);
            this.viewall_button.Name = "viewall_button";
            this.viewall_button.Size = new System.Drawing.Size(166, 41);
            this.viewall_button.TabIndex = 3;
            this.viewall_button.Text = "View All";
            this.viewall_button.UseVisualStyleBackColor = false;
            this.viewall_button.Click += new System.EventHandler(this.viewall_button_Click);
            // 
            // homePage_genre_listView
            // 
            this.homePage_genre_listView.BackColor = System.Drawing.Color.Gainsboro;
            this.homePage_genre_listView.Cursor = System.Windows.Forms.Cursors.Default;
            this.homePage_genre_listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homePage_genre_listView.ForeColor = System.Drawing.SystemColors.Highlight;
            this.homePage_genre_listView.HideSelection = false;
            this.homePage_genre_listView.LabelWrap = false;
            this.homePage_genre_listView.Location = new System.Drawing.Point(110, 270);
            this.homePage_genre_listView.MultiSelect = false;
            this.homePage_genre_listView.Name = "homePage_genre_listView";
            this.homePage_genre_listView.Size = new System.Drawing.Size(642, 154);
            this.homePage_genre_listView.TabIndex = 41;
            this.homePage_genre_listView.UseCompatibleStateImageBehavior = false;
            this.homePage_genre_listView.View = System.Windows.Forms.View.SmallIcon;
            this.homePage_genre_listView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.homePage_genre_listview_clicked);
            // 
            // search_textBox
            // 
            this.search_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.search_textBox.Font = new System.Drawing.Font("Sitka Text", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_textBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.search_textBox.Location = new System.Drawing.Point(221, 89);
            this.search_textBox.Name = "search_textBox";
            this.search_textBox.Size = new System.Drawing.Size(531, 31);
            this.search_textBox.TabIndex = 1;
            this.search_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_textBox_KeyDown);
            // 
            // random_button
            // 
            this.random_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.random_button.Font = new System.Drawing.Font("Sitka Text", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.random_button.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.random_button.Location = new System.Drawing.Point(576, 442);
            this.random_button.Name = "random_button";
            this.random_button.Size = new System.Drawing.Size(166, 41);
            this.random_button.TabIndex = 4;
            this.random_button.Text = "Random";
            this.random_button.UseVisualStyleBackColor = false;
            this.random_button.Click += new System.EventHandler(this.random_button_Click);
            // 
            // genres_label
            // 
            this.genres_label.AutoSize = true;
            this.genres_label.BackColor = System.Drawing.Color.Transparent;
            this.genres_label.Font = new System.Drawing.Font("Sitka Text", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genres_label.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.genres_label.Location = new System.Drawing.Point(368, 232);
            this.genres_label.Name = "genres_label";
            this.genres_label.Size = new System.Drawing.Size(113, 35);
            this.genres_label.TabIndex = 36;
            this.genres_label.Text = "Genres: ";
            // 
            // search_label
            // 
            this.search_label.AutoSize = true;
            this.search_label.BackColor = System.Drawing.Color.Transparent;
            this.search_label.Font = new System.Drawing.Font("Sitka Text", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_label.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.search_label.Location = new System.Drawing.Point(104, 86);
            this.search_label.Name = "search_label";
            this.search_label.Size = new System.Drawing.Size(111, 35);
            this.search_label.TabIndex = 35;
            this.search_label.Text = "Search: ";
            // 
            // add_textBox
            // 
            this.add_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.add_textBox.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_textBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.add_textBox.Location = new System.Drawing.Point(221, 165);
            this.add_textBox.Name = "add_textBox";
            this.add_textBox.Size = new System.Drawing.Size(531, 28);
            this.add_textBox.TabIndex = 2;
            this.add_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.add_textBox_KeyDown);
            // 
            // add_label
            // 
            this.add_label.AutoSize = true;
            this.add_label.BackColor = System.Drawing.Color.Transparent;
            this.add_label.Font = new System.Drawing.Font("Sitka Text", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_label.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.add_label.Location = new System.Drawing.Point(138, 158);
            this.add_label.Name = "add_label";
            this.add_label.Size = new System.Drawing.Size(77, 35);
            this.add_label.TabIndex = 39;
            this.add_label.Text = "Add: ";
            // 
            // HomePage_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.viewall_button);
            this.Controls.Add(this.homePage_genre_listView);
            this.Controls.Add(this.search_textBox);
            this.Controls.Add(this.random_button);
            this.Controls.Add(this.genres_label);
            this.Controls.Add(this.search_label);
            this.Controls.Add(this.add_textBox);
            this.Controls.Add(this.add_label);
            this.Name = "HomePage_UC";
            this.Size = new System.Drawing.Size(856, 568);
            this.EnabledChanged += new System.EventHandler(this.Home_EnabledChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button viewall_button;
        private System.Windows.Forms.ListView homePage_genre_listView;
        private System.Windows.Forms.TextBox search_textBox;
        private System.Windows.Forms.Button random_button;
        private System.Windows.Forms.Label genres_label;
        private System.Windows.Forms.Label search_label;
        private System.Windows.Forms.TextBox add_textBox;
        private System.Windows.Forms.Label add_label;
    }
}
