namespace AdvancedRenamer.TheTVDB
{
    partial class FrmRenamePattern
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
            this.panelButtons = new System.Windows.Forms.Panel();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.linkLabelShow = new System.Windows.Forms.LinkLabel();
            this.lblSubstitutions = new System.Windows.Forms.Label();
            this.linkLabelSeason = new System.Windows.Forms.LinkLabel();
            this.linkLabelEpisode = new System.Windows.Forms.LinkLabel();
            this.linkLabelTitle = new System.Windows.Forms.LinkLabel();
            this.richTextRenamePattern = new System.Windows.Forms.RichTextBox();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.butCancel);
            this.panelButtons.Controls.Add(this.butOK);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 175);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(483, 78);
            this.panelButtons.TabIndex = 0;
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(261, 3);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(102, 63);
            this.butCancel.TabIndex = 1;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // butOK
            // 
            this.butOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butOK.Location = new System.Drawing.Point(369, 3);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(102, 64);
            this.butOK.TabIndex = 0;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            // 
            // linkLabelShow
            // 
            this.linkLabelShow.AutoSize = true;
            this.linkLabelShow.Location = new System.Drawing.Point(12, 99);
            this.linkLabelShow.Name = "linkLabelShow";
            this.linkLabelShow.Size = new System.Drawing.Size(64, 20);
            this.linkLabelShow.TabIndex = 2;
            this.linkLabelShow.TabStop = true;
            this.linkLabelShow.Text = "<show>";
            this.linkLabelShow.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelShow_LinkClicked);
            // 
            // lblSubstitutions
            // 
            this.lblSubstitutions.AutoSize = true;
            this.lblSubstitutions.Location = new System.Drawing.Point(12, 70);
            this.lblSubstitutions.Name = "lblSubstitutions";
            this.lblSubstitutions.Size = new System.Drawing.Size(102, 20);
            this.lblSubstitutions.TabIndex = 3;
            this.lblSubstitutions.Text = "Substitutions";
            // 
            // linkLabelSeason
            // 
            this.linkLabelSeason.AutoSize = true;
            this.linkLabelSeason.Location = new System.Drawing.Point(12, 129);
            this.linkLabelSeason.Name = "linkLabelSeason";
            this.linkLabelSeason.Size = new System.Drawing.Size(79, 20);
            this.linkLabelSeason.TabIndex = 4;
            this.linkLabelSeason.TabStop = true;
            this.linkLabelSeason.Text = "<season>";
            this.linkLabelSeason.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSeason_LinkClicked);
            // 
            // linkLabelEpisode
            // 
            this.linkLabelEpisode.AutoSize = true;
            this.linkLabelEpisode.Location = new System.Drawing.Point(142, 99);
            this.linkLabelEpisode.Name = "linkLabelEpisode";
            this.linkLabelEpisode.Size = new System.Drawing.Size(83, 20);
            this.linkLabelEpisode.TabIndex = 5;
            this.linkLabelEpisode.TabStop = true;
            this.linkLabelEpisode.Text = "<episode>";
            this.linkLabelEpisode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelEpisode_LinkClicked);
            // 
            // linkLabelTitle
            // 
            this.linkLabelTitle.AutoSize = true;
            this.linkLabelTitle.Location = new System.Drawing.Point(142, 129);
            this.linkLabelTitle.Name = "linkLabelTitle";
            this.linkLabelTitle.Size = new System.Drawing.Size(52, 20);
            this.linkLabelTitle.TabIndex = 6;
            this.linkLabelTitle.TabStop = true;
            this.linkLabelTitle.Text = "<title>";
            this.linkLabelTitle.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelTitle_LinkClicked);
            // 
            // richTextRenamePattern
            // 
            this.richTextRenamePattern.Location = new System.Drawing.Point(16, 12);
            this.richTextRenamePattern.Name = "richTextRenamePattern";
            this.richTextRenamePattern.Size = new System.Drawing.Size(455, 36);
            this.richTextRenamePattern.TabIndex = 7;
            this.richTextRenamePattern.Text = "";
            this.richTextRenamePattern.TextChanged += new System.EventHandler(this.richTextRenamePattern_TextChanged);
            // 
            // FrmRenamePattern
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 253);
            this.Controls.Add(this.richTextRenamePattern);
            this.Controls.Add(this.linkLabelTitle);
            this.Controls.Add(this.linkLabelEpisode);
            this.Controls.Add(this.linkLabelSeason);
            this.Controls.Add(this.lblSubstitutions);
            this.Controls.Add(this.linkLabelShow);
            this.Controls.Add(this.panelButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRenamePattern";
            this.Text = "Rename Pattern";
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.LinkLabel linkLabelShow;
        private System.Windows.Forms.Label lblSubstitutions;
        private System.Windows.Forms.LinkLabel linkLabelSeason;
        private System.Windows.Forms.LinkLabel linkLabelEpisode;
        private System.Windows.Forms.LinkLabel linkLabelTitle;
        private System.Windows.Forms.RichTextBox richTextRenamePattern;
    }
}