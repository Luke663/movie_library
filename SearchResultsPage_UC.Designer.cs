
namespace Rep
{
    partial class SearchResultsPage_UC
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
            this.sortby_label = new System.Windows.Forms.Label();
            this.sort_combobox = new System.Windows.Forms.ComboBox();
            this.searchresults_flowpanel = new System.Windows.Forms.FlowLayoutPanel();
            this.home_button = new System.Windows.Forms.Button();
            this.searchResult_textBox = new System.Windows.Forms.TextBox();
            this.searchResult_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sortby_label
            // 
            this.sortby_label.AutoSize = true;
            this.sortby_label.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.sortby_label.Location = new System.Drawing.Point(662, 85);
            this.sortby_label.Name = "sortby_label";
            this.sortby_label.Size = new System.Drawing.Size(43, 13);
            this.sortby_label.TabIndex = 21;
            this.sortby_label.Text = "Sort by:";
            // 
            // sort_combobox
            // 
            this.sort_combobox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.sort_combobox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.sort_combobox.FormattingEnabled = true;
            this.sort_combobox.Items.AddRange(new object[] {
            " A - Z",
            " Z - A",
            " Score",
            " Date (old to new)",
            " Date (new to old)"});
            this.sort_combobox.Location = new System.Drawing.Point(711, 82);
            this.sort_combobox.Name = "sort_combobox";
            this.sort_combobox.Size = new System.Drawing.Size(107, 21);
            this.sort_combobox.TabIndex = 1;
            this.sort_combobox.Text = " A - Z";
            this.sort_combobox.SelectedIndexChanged += new System.EventHandler(this.sort_combobox_SelectedIndexChanged);
            // 
            // searchresults_flowpanel
            // 
            this.searchresults_flowpanel.AutoScroll = true;
            this.searchresults_flowpanel.BackColor = System.Drawing.Color.Transparent;
            this.searchresults_flowpanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.searchresults_flowpanel.Location = new System.Drawing.Point(44, 109);
            this.searchresults_flowpanel.Name = "searchresults_flowpanel";
            this.searchresults_flowpanel.Size = new System.Drawing.Size(774, 386);
            this.searchresults_flowpanel.TabIndex = 19;
            this.searchresults_flowpanel.MouseLeave += new System.EventHandler(this.searchresults_flowpanel_MouseLeave);
            // 
            // home_button
            // 
            this.home_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.home_button.Font = new System.Drawing.Font("Sitka Text", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.home_button.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.home_button.Location = new System.Drawing.Point(711, 501);
            this.home_button.Name = "home_button";
            this.home_button.Size = new System.Drawing.Size(107, 30);
            this.home_button.TabIndex = 3;
            this.home_button.Text = "Home";
            this.home_button.UseVisualStyleBackColor = false;
            this.home_button.Click += new System.EventHandler(this.home_button_Click);
            // 
            // searchResult_textBox
            // 
            this.searchResult_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.searchResult_textBox.Font = new System.Drawing.Font("Sitka Text", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchResult_textBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.searchResult_textBox.Location = new System.Drawing.Point(143, 41);
            this.searchResult_textBox.Name = "searchResult_textBox";
            this.searchResult_textBox.Size = new System.Drawing.Size(675, 31);
            this.searchResult_textBox.TabIndex = 2;
            this.searchResult_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchResult_textBox_KeyDown);
            // 
            // searchResult_label
            // 
            this.searchResult_label.AutoSize = true;
            this.searchResult_label.BackColor = System.Drawing.Color.Transparent;
            this.searchResult_label.Font = new System.Drawing.Font("Sitka Text", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchResult_label.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.searchResult_label.Location = new System.Drawing.Point(38, 38);
            this.searchResult_label.Name = "searchResult_label";
            this.searchResult_label.Size = new System.Drawing.Size(111, 35);
            this.searchResult_label.TabIndex = 16;
            this.searchResult_label.Text = "Search: ";
            // 
            // SearchResultsPage_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.sortby_label);
            this.Controls.Add(this.sort_combobox);
            this.Controls.Add(this.searchresults_flowpanel);
            this.Controls.Add(this.home_button);
            this.Controls.Add(this.searchResult_textBox);
            this.Controls.Add(this.searchResult_label);
            this.DoubleBuffered = true;
            this.Enabled = false;
            this.Name = "SearchResultsPage_UC";
            this.Size = new System.Drawing.Size(856, 568);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sortby_label;
        private System.Windows.Forms.ComboBox sort_combobox;
        private System.Windows.Forms.FlowLayoutPanel searchresults_flowpanel;
        private System.Windows.Forms.Button home_button;
        private System.Windows.Forms.TextBox searchResult_textBox;
        private System.Windows.Forms.Label searchResult_label;
    }
}
