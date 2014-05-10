namespace AdvancedRenamer
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.bottomStatus = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelDirectory = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.tabRenameOptions = new System.Windows.Forms.TabControl();
            this.tabTvDB = new System.Windows.Forms.TabPage();
            this.linkRenamePattern = new System.Windows.Forms.LinkLabel();
            this.lblRenamePattern = new System.Windows.Forms.Label();
            this.butLookup = new System.Windows.Forms.Button();
            this.txtSeason = new System.Windows.Forms.TextBox();
            this.txtShowTitle = new System.Windows.Forms.TextBox();
            this.lblSeason = new System.Windows.Forms.Label();
            this.lblShowTitle = new System.Windows.Forms.Label();
            this.tabRegex = new System.Windows.Forms.TabPage();
            this.chkIgnoreCase = new System.Windows.Forms.CheckBox();
            this.butRegex = new System.Windows.Forms.Button();
            this.txtReplace = new System.Windows.Forms.TextBox();
            this.txtRegex = new System.Windows.Forms.TextBox();
            this.lblReplace = new System.Windows.Forms.Label();
            this.lblRegex = new System.Windows.Forms.Label();
            this.fileListView = new System.Windows.Forms.ListView();
            this.colOriginalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNewName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.butRename = new System.Windows.Forms.Button();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.installExplorerContextMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uninstallExplorerContextMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottomStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.tabRenameOptions.SuspendLayout();
            this.tabTvDB.SuspendLayout();
            this.tabRegex.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.fileContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomStatus
            // 
            this.bottomStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelDirectory,
            this.statusLabel,
            this.toolStripProgressBar});
            this.bottomStatus.Location = new System.Drawing.Point(0, 610);
            this.bottomStatus.Name = "bottomStatus";
            this.bottomStatus.Size = new System.Drawing.Size(1074, 30);
            this.bottomStatus.TabIndex = 1;
            this.bottomStatus.Text = "statusStrip1";
            // 
            // toolStripStatusLabelDirectory
            // 
            this.toolStripStatusLabelDirectory.Name = "toolStripStatusLabelDirectory";
            this.toolStripStatusLabelDirectory.Size = new System.Drawing.Size(180, 25);
            this.toolStripStatusLabelDirectory.Text = "No directory selected";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.statusLabel.Size = new System.Drawing.Size(758, 25);
            this.statusLabel.Spring = true;
            this.statusLabel.Text = "No files selected";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Enabled = false;
            this.toolStripProgressBar.Margin = new System.Windows.Forms.Padding(1, 3, 20, 3);
            this.toolStripProgressBar.MarqueeAnimationSpeed = 10;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 24);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 33);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.splitContainerMain);
            this.splitContainer.Size = new System.Drawing.Size(1074, 577);
            this.splitContainer.SplitterDistance = 358;
            this.splitContainer.TabIndex = 2;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.IsSplitterFixed = true;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.tabRenameOptions);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.fileListView);
            this.splitContainerMain.Panel2.Controls.Add(this.butRename);
            this.splitContainerMain.Size = new System.Drawing.Size(712, 577);
            this.splitContainerMain.SplitterDistance = 100;
            this.splitContainerMain.TabIndex = 0;
            // 
            // tabRenameOptions
            // 
            this.tabRenameOptions.Controls.Add(this.tabTvDB);
            this.tabRenameOptions.Controls.Add(this.tabRegex);
            this.tabRenameOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabRenameOptions.Location = new System.Drawing.Point(0, 0);
            this.tabRenameOptions.Name = "tabRenameOptions";
            this.tabRenameOptions.SelectedIndex = 0;
            this.tabRenameOptions.Size = new System.Drawing.Size(712, 100);
            this.tabRenameOptions.TabIndex = 2;
            // 
            // tabTvDB
            // 
            this.tabTvDB.Controls.Add(this.linkRenamePattern);
            this.tabTvDB.Controls.Add(this.lblRenamePattern);
            this.tabTvDB.Controls.Add(this.butLookup);
            this.tabTvDB.Controls.Add(this.txtSeason);
            this.tabTvDB.Controls.Add(this.txtShowTitle);
            this.tabTvDB.Controls.Add(this.lblSeason);
            this.tabTvDB.Controls.Add(this.lblShowTitle);
            this.tabTvDB.Location = new System.Drawing.Point(4, 29);
            this.tabTvDB.Name = "tabTvDB";
            this.tabTvDB.Padding = new System.Windows.Forms.Padding(3);
            this.tabTvDB.Size = new System.Drawing.Size(704, 67);
            this.tabTvDB.TabIndex = 1;
            this.tabTvDB.Text = "TVDB";
            this.tabTvDB.UseVisualStyleBackColor = true;
            // 
            // linkRenamePattern
            // 
            this.linkRenamePattern.AutoSize = true;
            this.linkRenamePattern.Location = new System.Drawing.Point(138, 85);
            this.linkRenamePattern.Name = "linkRenamePattern";
            this.linkRenamePattern.Size = new System.Drawing.Size(216, 20);
            this.linkRenamePattern.TabIndex = 6;
            this.linkRenamePattern.TabStop = true;
            this.linkRenamePattern.Text = "<season>x<episode> - <title>";
            this.linkRenamePattern.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRenamePattern_LinkClicked);
            // 
            // lblRenamePattern
            // 
            this.lblRenamePattern.AutoSize = true;
            this.lblRenamePattern.Location = new System.Drawing.Point(6, 85);
            this.lblRenamePattern.Name = "lblRenamePattern";
            this.lblRenamePattern.Size = new System.Drawing.Size(126, 20);
            this.lblRenamePattern.TabIndex = 5;
            this.lblRenamePattern.Text = "Rename Pattern";
            // 
            // butLookup
            // 
            this.butLookup.Location = new System.Drawing.Point(370, 6);
            this.butLookup.Name = "butLookup";
            this.butLookup.Size = new System.Drawing.Size(89, 70);
            this.butLookup.TabIndex = 4;
            this.butLookup.Text = "Lookup";
            this.butLookup.UseVisualStyleBackColor = true;
            this.butLookup.Click += new System.EventHandler(this.butLookup_Click);
            // 
            // txtSeason
            // 
            this.txtSeason.Location = new System.Drawing.Point(83, 42);
            this.txtSeason.Name = "txtSeason";
            this.txtSeason.Size = new System.Drawing.Size(271, 26);
            this.txtSeason.TabIndex = 3;
            this.txtSeason.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSeason_KeyDown);
            // 
            // txtShowTitle
            // 
            this.txtShowTitle.Location = new System.Drawing.Point(83, 7);
            this.txtShowTitle.Name = "txtShowTitle";
            this.txtShowTitle.Size = new System.Drawing.Size(271, 26);
            this.txtShowTitle.TabIndex = 2;
            this.txtShowTitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShowTitle_KeyDown);
            // 
            // lblSeason
            // 
            this.lblSeason.AutoSize = true;
            this.lblSeason.Location = new System.Drawing.Point(6, 41);
            this.lblSeason.Name = "lblSeason";
            this.lblSeason.Size = new System.Drawing.Size(68, 20);
            this.lblSeason.TabIndex = 1;
            this.lblSeason.Text = "Season:";
            // 
            // lblShowTitle
            // 
            this.lblShowTitle.AutoSize = true;
            this.lblShowTitle.Location = new System.Drawing.Point(6, 10);
            this.lblShowTitle.Name = "lblShowTitle";
            this.lblShowTitle.Size = new System.Drawing.Size(53, 20);
            this.lblShowTitle.TabIndex = 0;
            this.lblShowTitle.Text = "Show:";
            // 
            // tabRegex
            // 
            this.tabRegex.Controls.Add(this.chkIgnoreCase);
            this.tabRegex.Controls.Add(this.butRegex);
            this.tabRegex.Controls.Add(this.txtReplace);
            this.tabRegex.Controls.Add(this.txtRegex);
            this.tabRegex.Controls.Add(this.lblReplace);
            this.tabRegex.Controls.Add(this.lblRegex);
            this.tabRegex.Location = new System.Drawing.Point(4, 29);
            this.tabRegex.Name = "tabRegex";
            this.tabRegex.Size = new System.Drawing.Size(704, 67);
            this.tabRegex.TabIndex = 2;
            this.tabRegex.Text = "Regex";
            this.tabRegex.UseVisualStyleBackColor = true;
            // 
            // chkIgnoreCase
            // 
            this.chkIgnoreCase.AutoSize = true;
            this.chkIgnoreCase.Checked = true;
            this.chkIgnoreCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIgnoreCase.Location = new System.Drawing.Point(468, 13);
            this.chkIgnoreCase.Name = "chkIgnoreCase";
            this.chkIgnoreCase.Size = new System.Drawing.Size(122, 24);
            this.chkIgnoreCase.TabIndex = 5;
            this.chkIgnoreCase.Text = "Ignore Case";
            this.chkIgnoreCase.UseVisualStyleBackColor = true;
            // 
            // butRegex
            // 
            this.butRegex.Location = new System.Drawing.Point(370, 6);
            this.butRegex.Name = "butRegex";
            this.butRegex.Size = new System.Drawing.Size(89, 70);
            this.butRegex.TabIndex = 4;
            this.butRegex.Text = "Preview";
            this.butRegex.UseVisualStyleBackColor = true;
            this.butRegex.Click += new System.EventHandler(this.butRegex_Click);
            // 
            // txtReplace
            // 
            this.txtReplace.Location = new System.Drawing.Point(83, 42);
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.Size = new System.Drawing.Size(271, 26);
            this.txtReplace.TabIndex = 3;
            // 
            // txtRegex
            // 
            this.txtRegex.Location = new System.Drawing.Point(83, 8);
            this.txtRegex.Name = "txtRegex";
            this.txtRegex.Size = new System.Drawing.Size(271, 26);
            this.txtRegex.TabIndex = 2;
            this.txtRegex.TextChanged += new System.EventHandler(this.txtRegex_TextChanged);
            // 
            // lblReplace
            // 
            this.lblReplace.AutoSize = true;
            this.lblReplace.Location = new System.Drawing.Point(6, 41);
            this.lblReplace.Name = "lblReplace";
            this.lblReplace.Size = new System.Drawing.Size(72, 20);
            this.lblReplace.TabIndex = 1;
            this.lblReplace.Text = "Replace:";
            // 
            // lblRegex
            // 
            this.lblRegex.AutoSize = true;
            this.lblRegex.Location = new System.Drawing.Point(6, 10);
            this.lblRegex.Name = "lblRegex";
            this.lblRegex.Size = new System.Drawing.Size(59, 20);
            this.lblRegex.TabIndex = 0;
            this.lblRegex.Text = "Regex:";
            // 
            // fileListView
            // 
            this.fileListView.CheckBoxes = true;
            this.fileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOriginalName,
            this.colNewName});
            this.fileListView.ContextMenuStrip = this.fileContextMenu;
            this.fileListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileListView.FullRowSelect = true;
            this.fileListView.Location = new System.Drawing.Point(0, 0);
            this.fileListView.Name = "fileListView";
            this.fileListView.ShowItemToolTips = true;
            this.fileListView.Size = new System.Drawing.Size(712, 421);
            this.fileListView.TabIndex = 0;
            this.fileListView.UseCompatibleStateImageBehavior = false;
            this.fileListView.View = System.Windows.Forms.View.Details;
            this.fileListView.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.fileListView_ItemCheck);
            this.fileListView.Resize += new System.EventHandler(this.fileListView_Resize);
            // 
            // colOriginalName
            // 
            this.colOriginalName.Text = "Old Name";
            this.colOriginalName.Width = 297;
            // 
            // colNewName
            // 
            this.colNewName.Text = "New Name";
            this.colNewName.Width = 346;
            // 
            // butRename
            // 
            this.butRename.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.butRename.Enabled = false;
            this.butRename.Location = new System.Drawing.Point(0, 421);
            this.butRename.Name = "butRename";
            this.butRename.Size = new System.Drawing.Size(712, 52);
            this.butRename.TabIndex = 1;
            this.butRename.Text = "Rename 0 files";
            this.butRename.UseVisualStyleBackColor = true;
            this.butRename.Click += new System.EventHandler(this.butRename_Click_1);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1074, 33);
            this.mainMenu.TabIndex = 3;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.installExplorerContextMenuToolStripMenuItem,
            this.uninstallExplorerContextMenuToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // installExplorerContextMenuToolStripMenuItem
            // 
            this.installExplorerContextMenuToolStripMenuItem.Name = "installExplorerContextMenuToolStripMenuItem";
            this.installExplorerContextMenuToolStripMenuItem.Size = new System.Drawing.Size(336, 30);
            this.installExplorerContextMenuToolStripMenuItem.Text = "Install Explorer Context Menu";
            this.installExplorerContextMenuToolStripMenuItem.Click += new System.EventHandler(this.installExplorerContextMenuToolStripMenuItem_Click);
            // 
            // uninstallExplorerContextMenuToolStripMenuItem
            // 
            this.uninstallExplorerContextMenuToolStripMenuItem.Name = "uninstallExplorerContextMenuToolStripMenuItem";
            this.uninstallExplorerContextMenuToolStripMenuItem.Size = new System.Drawing.Size(336, 30);
            this.uninstallExplorerContextMenuToolStripMenuItem.Text = "Uninstall Explorer Context Menu";
            this.uninstallExplorerContextMenuToolStripMenuItem.Click += new System.EventHandler(this.uninstallExplorerContextMenuToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(336, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // fileContextMenu
            // 
            this.fileContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.deselectAllToolStripMenuItem,
            this.renameFilesToolStripMenuItem,
            this.deleteFilesToolStripMenuItem});
            this.fileContextMenu.Name = "fileContextMenu";
            this.fileContextMenu.Size = new System.Drawing.Size(188, 124);
            // 
            // renameFilesToolStripMenuItem
            // 
            this.renameFilesToolStripMenuItem.Name = "renameFilesToolStripMenuItem";
            this.renameFilesToolStripMenuItem.Size = new System.Drawing.Size(187, 30);
            this.renameFilesToolStripMenuItem.Text = "Rename Files";
            this.renameFilesToolStripMenuItem.Click += new System.EventHandler(this.renameFilesToolStripMenuItem_Click);
            // 
            // deleteFilesToolStripMenuItem
            // 
            this.deleteFilesToolStripMenuItem.Name = "deleteFilesToolStripMenuItem";
            this.deleteFilesToolStripMenuItem.Size = new System.Drawing.Size(187, 30);
            this.deleteFilesToolStripMenuItem.Text = "Delete Files";
            this.deleteFilesToolStripMenuItem.Click += new System.EventHandler(this.deleteFilesToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(187, 30);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // deselectAllToolStripMenuItem
            // 
            this.deselectAllToolStripMenuItem.Name = "deselectAllToolStripMenuItem";
            this.deselectAllToolStripMenuItem.Size = new System.Drawing.Size(187, 30);
            this.deselectAllToolStripMenuItem.Text = "Deselect All";
            this.deselectAllToolStripMenuItem.Click += new System.EventHandler(this.deselectAllToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 640);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.bottomStatus);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "Advanced Renamer";
            this.bottomStatus.ResumeLayout(false);
            this.bottomStatus.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.tabRenameOptions.ResumeLayout(false);
            this.tabTvDB.ResumeLayout(false);
            this.tabTvDB.PerformLayout();
            this.tabRegex.ResumeLayout(false);
            this.tabRegex.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.fileContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip bottomStatus;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.ListView fileListView;
        private System.Windows.Forms.ColumnHeader colOriginalName;
        private System.Windows.Forms.ColumnHeader colNewName;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.TabControl tabRenameOptions;
        private System.Windows.Forms.TabPage tabTvDB;
        private System.Windows.Forms.LinkLabel linkRenamePattern;
        private System.Windows.Forms.Label lblRenamePattern;
        private System.Windows.Forms.Button butLookup;
        private System.Windows.Forms.TextBox txtSeason;
        private System.Windows.Forms.TextBox txtShowTitle;
        private System.Windows.Forms.Label lblSeason;
        private System.Windows.Forms.Label lblShowTitle;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDirectory;
        private System.Windows.Forms.Button butRename;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.TabPage tabRegex;
        private System.Windows.Forms.CheckBox chkIgnoreCase;
        private System.Windows.Forms.Button butRegex;
        private System.Windows.Forms.TextBox txtReplace;
        private System.Windows.Forms.TextBox txtRegex;
        private System.Windows.Forms.Label lblReplace;
        private System.Windows.Forms.Label lblRegex;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem installExplorerContextMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uninstallExplorerContextMenuToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip fileContextMenu;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deselectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteFilesToolStripMenuItem;
    }
}

