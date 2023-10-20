
namespace Rep
{
    partial class ViewAllTilePage_UC
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
            this.filterby_label = new System.Windows.Forms.Label();
            this.filters_comboBox = new System.Windows.Forms.ComboBox();
            this.sortby_label = new System.Windows.Forms.Label();
            this.sort_combobox = new System.Windows.Forms.ComboBox();
            this.home_button = new System.Windows.Forms.Button();
            this.view_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // filterby_label
            // 
            this.filterby_label.AutoSize = true;
            this.filterby_label.BackColor = System.Drawing.Color.Transparent;
            this.filterby_label.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.filterby_label.Location = new System.Drawing.Point(344, 41);
            this.filterby_label.Name = "filterby_label";
            this.filterby_label.Size = new System.Drawing.Size(46, 13);
            this.filterby_label.TabIndex = 25;
            this.filterby_label.Text = "Filter by:";
            // 
            // filters_comboBox
            // 
            this.filters_comboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.filters_comboBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.filters_comboBox.FormattingEnabled = true;
            this.filters_comboBox.Location = new System.Drawing.Point(393, 38);
            this.filters_comboBox.Name = "filters_comboBox";
            this.filters_comboBox.Size = new System.Drawing.Size(107, 21);
            this.filters_comboBox.TabIndex = 2;
            this.filters_comboBox.Text = " All";
            this.filters_comboBox.SelectedIndexChanged += new System.EventHandler(this.filters_comboBox_SelectedIndexChanged);
            // 
            // sortby_label
            // 
            this.sortby_label.AutoSize = true;
            this.sortby_label.BackColor = System.Drawing.Color.Transparent;
            this.sortby_label.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.sortby_label.Location = new System.Drawing.Point(651, 41);
            this.sortby_label.Name = "sortby_label";
            this.sortby_label.Size = new System.Drawing.Size(43, 13);
            this.sortby_label.TabIndex = 23;
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
            this.sort_combobox.Location = new System.Drawing.Point(700, 38);
            this.sort_combobox.Name = "sort_combobox";
            this.sort_combobox.Size = new System.Drawing.Size(107, 21);
            this.sort_combobox.TabIndex = 3;
            this.sort_combobox.Text = " A - Z";
            this.sort_combobox.SelectedIndexChanged += new System.EventHandler(this.sort_combobox_SelectedIndexChanged);
            // 
            // home_button
            // 
            this.home_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.home_button.Font = new System.Drawing.Font("Sitka Text", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.home_button.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.home_button.Location = new System.Drawing.Point(700, 500);
            this.home_button.Name = "home_button";
            this.home_button.Size = new System.Drawing.Size(107, 30);
            this.home_button.TabIndex = 1;
            this.home_button.Text = "Home";
            this.home_button.UseVisualStyleBackColor = false;
            this.home_button.Click += new System.EventHandler(this.home_button_Click);
            // 
            // view_flowLayoutPanel
            // 
            this.view_flowLayoutPanel.AutoScroll = true;
            this.view_flowLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.view_flowLayoutPanel.Location = new System.Drawing.Point(20, 65);
            this.view_flowLayoutPanel.Name = "view_flowLayoutPanel";
            this.view_flowLayoutPanel.Size = new System.Drawing.Size(816, 429);
            this.view_flowLayoutPanel.TabIndex = 20;
            this.view_flowLayoutPanel.MouseLeave += new System.EventHandler(this.view_flowLayoutPanel_MouseLeave);
            // 
            // ViewAllTilePage_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.filterby_label);
            this.Controls.Add(this.filters_comboBox);
            this.Controls.Add(this.sortby_label);
            this.Controls.Add(this.sort_combobox);
            this.Controls.Add(this.home_button);
            this.Controls.Add(this.view_flowLayoutPanel);
            this.DoubleBuffered = true;
            this.Enabled = false;
            this.Name = "ViewAllTilePage_UC";
            this.Size = new System.Drawing.Size(856, 568);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label filterby_label;
        private System.Windows.Forms.ComboBox filters_comboBox;
        private System.Windows.Forms.Label sortby_label;
        private System.Windows.Forms.ComboBox sort_combobox;
        private System.Windows.Forms.Button home_button;
        private System.Windows.Forms.FlowLayoutPanel view_flowLayoutPanel;
    }
}
