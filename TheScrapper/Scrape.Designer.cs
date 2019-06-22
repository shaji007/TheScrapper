namespace TheScrapper
{
    partial class Scrape
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
            this.clbScrape = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // clbScrape
            // 
            this.clbScrape.FormattingEnabled = true;
            this.clbScrape.Location = new System.Drawing.Point(13, 13);
            this.clbScrape.Name = "clbScrape";
            this.clbScrape.Size = new System.Drawing.Size(200, 379);
            this.clbScrape.TabIndex = 0;
            // 
            // Scrape
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 405);
            this.Controls.Add(this.clbScrape);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Scrape";
            this.Text = "Scrape";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Scrape_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Scrape_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbScrape;
    }
}