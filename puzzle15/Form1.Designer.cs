namespace puzzle15
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
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuSpiel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEnde = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAnzReihen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu3Reihen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu4Reihen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu5Reihen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu6Reihen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu7Reihen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu8Reihen = new System.Windows.Forms.ToolStripMenuItem();
            this.tbZuege = new System.Windows.Forms.ToolStripTextBox();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.AutoSize = false;
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSpiel,
            this.mnuSettings,
            this.tbZuege});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMain.ShowItemToolTips = true;
            this.mnuMain.Size = new System.Drawing.Size(284, 27);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "menu1";
            // 
            // mnuSpiel
            // 
            this.mnuSpiel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.mnuEnde});
            this.mnuSpiel.Name = "mnuSpiel";
            this.mnuSpiel.Size = new System.Drawing.Size(44, 23);
            this.mnuSpiel.Text = "&Spiel";
            // 
            // mnuNew
            // 
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.Size = new System.Drawing.Size(100, 22);
            this.mnuNew.Text = "&Neu";
            this.mnuNew.Click += new System.EventHandler(this.neuToolStripMenuItem_Click);
            // 
            // mnuEnde
            // 
            this.mnuEnde.Name = "mnuEnde";
            this.mnuEnde.Size = new System.Drawing.Size(100, 22);
            this.mnuEnde.Text = "&Ende";
            this.mnuEnde.Click += new System.EventHandler(this.endeToolStripMenuItem_Click);
            // 
            // mnuSettings
            // 
            this.mnuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAnzReihen});
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(90, 23);
            this.mnuSettings.Text = "&Einstellungen";
            // 
            // mnuAnzReihen
            // 
            this.mnuAnzReihen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu3Reihen,
            this.mnu4Reihen,
            this.mnu5Reihen,
            this.mnu6Reihen,
            this.mnu7Reihen,
            this.mnu8Reihen});
            this.mnuAnzReihen.Name = "mnuAnzReihen";
            this.mnuAnzReihen.Size = new System.Drawing.Size(149, 22);
            this.mnuAnzReihen.Text = "&Anzahl Reihen";
            // 
            // mnu3Reihen
            // 
            this.mnu3Reihen.Name = "mnu3Reihen";
            this.mnu3Reihen.Size = new System.Drawing.Size(80, 22);
            this.mnu3Reihen.Text = "3";
            this.mnu3Reihen.Click += new System.EventHandler(this.menuAnzReihen_Click);
            // 
            // mnu4Reihen
            // 
            this.mnu4Reihen.Name = "mnu4Reihen";
            this.mnu4Reihen.Size = new System.Drawing.Size(80, 22);
            this.mnu4Reihen.Text = "4";
            this.mnu4Reihen.Click += new System.EventHandler(this.menuAnzReihen_Click);
            // 
            // mnu5Reihen
            // 
            this.mnu5Reihen.Name = "mnu5Reihen";
            this.mnu5Reihen.Size = new System.Drawing.Size(80, 22);
            this.mnu5Reihen.Text = "5";
            this.mnu5Reihen.Click += new System.EventHandler(this.menuAnzReihen_Click);
            // 
            // mnu6Reihen
            // 
            this.mnu6Reihen.Name = "mnu6Reihen";
            this.mnu6Reihen.Size = new System.Drawing.Size(80, 22);
            this.mnu6Reihen.Text = "6";
            this.mnu6Reihen.Click += new System.EventHandler(this.menuAnzReihen_Click);
            // 
            // mnu7Reihen
            // 
            this.mnu7Reihen.Name = "mnu7Reihen";
            this.mnu7Reihen.Size = new System.Drawing.Size(80, 22);
            this.mnu7Reihen.Text = "7";
            this.mnu7Reihen.Click += new System.EventHandler(this.menuAnzReihen_Click);
            // 
            // mnu8Reihen
            // 
            this.mnu8Reihen.Name = "mnu8Reihen";
            this.mnu8Reihen.Size = new System.Drawing.Size(80, 22);
            this.mnu8Reihen.Text = "8";
            this.mnu8Reihen.Click += new System.EventHandler(this.menuAnzReihen_Click);
            // 
            // tbZuege
            // 
            this.tbZuege.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbZuege.AutoToolTip = true;
            this.tbZuege.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tbZuege.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbZuege.Name = "tbZuege";
            this.tbZuege.ReadOnly = true;
            this.tbZuege.ShortcutsEnabled = false;
            this.tbZuege.Size = new System.Drawing.Size(100, 23);
            this.tbZuege.Text = "Spielzüge";
            this.tbZuege.ToolTipText = "Anzahl der Züge";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = this.mnuMain;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuSpiel;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuNew;
        private System.Windows.Forms.ToolStripMenuItem mnuEnde;
        private System.Windows.Forms.ToolStripMenuItem mnuAnzReihen;
        private System.Windows.Forms.ToolStripTextBox tbZuege;
        private System.Windows.Forms.ToolStripMenuItem mnu3Reihen;
        private System.Windows.Forms.ToolStripMenuItem mnu4Reihen;
        private System.Windows.Forms.ToolStripMenuItem mnu5Reihen;
        private System.Windows.Forms.ToolStripMenuItem mnu6Reihen;
        private System.Windows.Forms.ToolStripMenuItem mnu7Reihen;
        private System.Windows.Forms.ToolStripMenuItem mnu8Reihen;
    }
}

