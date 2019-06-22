namespace TheScrapper
{
    partial class Settings
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
            this.CbSaveMethod = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ChkbSupport = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // CbSaveMethod
            // 
            this.CbSaveMethod.FormattingEnabled = true;
            this.CbSaveMethod.Items.AddRange(new object[] {
            "C#",
            "JAVA",
            "XML"});
            this.CbSaveMethod.Location = new System.Drawing.Point(12, 29);
            this.CbSaveMethod.Name = "CbSaveMethod";
            this.CbSaveMethod.Size = new System.Drawing.Size(329, 21);
            this.CbSaveMethod.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "How do you want to save the locators?";
            // 
            // ChkbSupport
            // 
            this.ChkbSupport.AutoSize = true;
            this.ChkbSupport.Location = new System.Drawing.Point(12, 73);
            this.ChkbSupport.Name = "ChkbSupport";
            this.ChkbSupport.Size = new System.Drawing.Size(159, 17);
            this.ChkbSupport.TabIndex = 2;
            this.ChkbSupport.Text = "Use Support UI Terminology";
            this.ChkbSupport.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 106);
            this.Controls.Add(this.ChkbSupport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CbSaveMethod);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Text = "Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BtnSettings_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnSettings_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CbSaveMethod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ChkbSupport;
    }
}