namespace TheScrapper
{
    partial class TheScrapperForm
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
            this.BtnLaunch = new System.Windows.Forms.Button();
            this.BtnScrape = new System.Windows.Forms.Button();
            this.TvFrames = new System.Windows.Forms.TreeView();
            this.LvLocators = new System.Windows.Forms.ListView();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnSettings = new System.Windows.Forms.Button();
            this.BtnFrames = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnLaunch
            // 
            this.BtnLaunch.Location = new System.Drawing.Point(10, 12);
            this.BtnLaunch.Name = "BtnLaunch";
            this.BtnLaunch.Size = new System.Drawing.Size(95, 52);
            this.BtnLaunch.TabIndex = 0;
            this.BtnLaunch.Text = "Launch Chrome";
            this.BtnLaunch.UseVisualStyleBackColor = true;
            this.BtnLaunch.Click += new System.EventHandler(this.BtnLaunch_Click);
            // 
            // BtnScrape
            // 
            this.BtnScrape.Enabled = false;
            this.BtnScrape.Location = new System.Drawing.Point(212, 12);
            this.BtnScrape.Name = "BtnScrape";
            this.BtnScrape.Size = new System.Drawing.Size(95, 52);
            this.BtnScrape.TabIndex = 1;
            this.BtnScrape.Text = "Scrape";
            this.BtnScrape.UseVisualStyleBackColor = true;
            this.BtnScrape.Click += new System.EventHandler(this.BtnScrape_Click);
            // 
            // TvFrames
            // 
            this.TvFrames.Location = new System.Drawing.Point(10, 72);
            this.TvFrames.Name = "TvFrames";
            this.TvFrames.Size = new System.Drawing.Size(296, 162);
            this.TvFrames.TabIndex = 2;
            this.TvFrames.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvFrames_AfterSelect);
            // 
            // LvLocators
            // 
            this.LvLocators.FullRowSelect = true;
            this.LvLocators.GridLines = true;
            this.LvLocators.LabelEdit = true;
            this.LvLocators.Location = new System.Drawing.Point(10, 241);
            this.LvLocators.Name = "LvLocators";
            this.LvLocators.Size = new System.Drawing.Size(296, 305);
            this.LvLocators.TabIndex = 3;
            this.LvLocators.UseCompatibleStateImageBehavior = false;
            this.LvLocators.View = System.Windows.Forms.View.Details;
            this.LvLocators.SelectedIndexChanged += new System.EventHandler(this.LvLocators_SelectedIndexChanged);
            this.LvLocators.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LvLocators_KeyUp);
            this.LvLocators.Leave += new System.EventHandler(this.LvLocators_Leave);
            this.LvLocators.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LvLocators_MouseClick);
            this.LvLocators.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LvLocators_MouseDoubleClick);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(12, 556);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(143, 52);
            this.BtnSave.TabIndex = 4;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnSettings
            // 
            this.BtnSettings.Location = new System.Drawing.Point(163, 556);
            this.BtnSettings.Name = "BtnSettings";
            this.BtnSettings.Size = new System.Drawing.Size(143, 52);
            this.BtnSettings.TabIndex = 5;
            this.BtnSettings.Text = "Settings";
            this.BtnSettings.UseVisualStyleBackColor = true;
            this.BtnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // BtnFrames
            // 
            this.BtnFrames.Enabled = false;
            this.BtnFrames.Location = new System.Drawing.Point(111, 12);
            this.BtnFrames.Name = "BtnFrames";
            this.BtnFrames.Size = new System.Drawing.Size(95, 52);
            this.BtnFrames.TabIndex = 6;
            this.BtnFrames.Text = "Frames";
            this.BtnFrames.UseVisualStyleBackColor = true;
            this.BtnFrames.Click += new System.EventHandler(this.BtnFrames_Click);
            // 
            // TheScrapperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 617);
            this.Controls.Add(this.BtnFrames);
            this.Controls.Add(this.BtnSettings);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.LvLocators);
            this.Controls.Add(this.TvFrames);
            this.Controls.Add(this.BtnScrape);
            this.Controls.Add(this.BtnLaunch);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TheScrapperForm";
            this.Text = "The Scrapper";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TheScrapperForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnLaunch;
        private System.Windows.Forms.Button BtnScrape;
        private System.Windows.Forms.TreeView TvFrames;
        private System.Windows.Forms.ListView LvLocators;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnSettings;
        private System.Windows.Forms.Button BtnFrames;
    }
}

