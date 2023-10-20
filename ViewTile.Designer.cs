
namespace Rep
{
    partial class ViewTile
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
            this.score_label = new System.Windows.Forms.Label();
            this.title_textBox = new System.Windows.Forms.TextBox();
            this.item_pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.item_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // score_label
            // 
            this.score_label.AutoSize = true;
            this.score_label.BackColor = System.Drawing.Color.Transparent;
            this.score_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score_label.ForeColor = System.Drawing.Color.Red;
            this.score_label.Location = new System.Drawing.Point(103, 153);
            this.score_label.Name = "score_label";
            this.score_label.Size = new System.Drawing.Size(35, 15);
            this.score_label.TabIndex = 6;
            this.score_label.Text = "7.25";
            this.score_label.Click += new System.EventHandler(this.item_Click);
            // 
            // title_textBox
            // 
            this.title_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.title_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.title_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_textBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.title_textBox.Location = new System.Drawing.Point(14, 187);
            this.title_textBox.Multiline = true;
            this.title_textBox.Name = "title_textBox";
            this.title_textBox.Size = new System.Drawing.Size(125, 30);
            this.title_textBox.TabIndex = 5;
            this.title_textBox.Text = "Title Placeholder";
            this.title_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.title_textBox.Click += new System.EventHandler(this.item_Click);
            // 
            // item_pictureBox
            // 
            this.item_pictureBox.BackColor = System.Drawing.Color.Silver;
            this.item_pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.item_pictureBox.Location = new System.Drawing.Point(15, 8);
            this.item_pictureBox.Name = "item_pictureBox";
            this.item_pictureBox.Size = new System.Drawing.Size(122, 164);
            this.item_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.item_pictureBox.TabIndex = 4;
            this.item_pictureBox.TabStop = false;
            this.item_pictureBox.Click += new System.EventHandler(this.item_Click);
            // 
            // ViewTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.score_label);
            this.Controls.Add(this.title_textBox);
            this.Controls.Add(this.item_pictureBox);
            this.DoubleBuffered = true;
            this.Name = "ViewTile";
            this.Size = new System.Drawing.Size(153, 225);
            this.Click += new System.EventHandler(this.item_Click);
            this.MouseEnter += new System.EventHandler(this.ViewAllItem_MouseEnter);
            ((System.ComponentModel.ISupportInitialize)(this.item_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label score_label;
        private System.Windows.Forms.TextBox title_textBox;
        private System.Windows.Forms.PictureBox item_pictureBox;
    }
}
