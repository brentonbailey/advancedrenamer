using AdvancedRenamer.FileTree;
using AdvancedRenamer.Regexes;
using AdvancedRenamer.TheTVDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedRenamer
{
    public partial class FrmMain : Form
    {

        private List<RenameSuggestion> renameSuggestions = new List<RenameSuggestion>();
        private FileSystemTree tree = null;
        private ContextMenuInstaller contextMenuInstaller = new ContextMenuInstaller();

        TvDBMatcher matcher = new TvDBMatcher();
        RegexMatcher regexMatcher = new RegexMatcher();

        public FrmMain(DirectoryInfo dir)
        {

            InitializeComponent();
            tree = new FileSystemTree() 
            { 
                Dock = DockStyle.Fill
            };

            if (dir != null)
            {
                try
                {
                    tree.NavigateToDirectory(dir);
                    ChangeDirectory(dir);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Failed to navigate to " + dir.FullName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            splitContainer.Panel1.Controls.Add(tree);

            // Attach to the events
            tree.DirectoryClicked += tree_DirectoryClicked;

        }

        

        void tree_DirectoryClicked(FileSystemTree sender, DirectoryInfo directory)
        {
            ChangeDirectory(directory);
        }

        /// <summary>
        /// Change the UI to the given directory
        /// </summary>
        /// <param name="dir">The directory to change to</param>
        private void ChangeDirectory(DirectoryInfo dir)
        {
            renameSuggestions.Clear();
            foreach (FileInfo file in dir.GetFiles().OrderBy(f => f.Name).ToList())
            {
                RenameSuggestion suggestion = new RenameSuggestion(file);
                renameSuggestions.Add(suggestion);
            }

            if (dir.Parent != null)
            {
                txtShowTitle.Text = dir.Parent.Name;
                txtShowTitle.ForeColor = Color.Gray;
                txtSeason.Text = dir.Name;
                txtSeason.ForeColor = Color.Gray;
            }

            toolStripStatusLabelDirectory.Text = dir.FullName;

            PopulateFileList();
        }

        /// <summary>
        /// Populate the list of filenames
        /// </summary>
        private void PopulateFileList()
        {
            fileListView.Items.Clear();

            foreach (RenameSuggestion suggestion in renameSuggestions)
            {
                ListViewItem item = new ListViewItem(suggestion.OriginalName);
                item.SubItems.Add(suggestion.SuggestedName);
                item.Tag = suggestion;
                item.Checked = suggestion.ShouldRename;
                fileListView.Items.Add(item);
            }

            int selectedCount = renameSuggestions.Count(s => s.ShouldRename);
            statusLabel.Text = selectedCount.ToString() + " files selected";
            butRename.Enabled = selectedCount != 0;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
        }

        private void butRename_Click(object sender, EventArgs e)
        {
            DoRename();
        }

        private void DoRename()
        {
            int successCount = 0;
            int failCount = 0;
            foreach (ListViewItem item in fileListView.Items)
            {
                if (item.Tag != null && item.Tag is RenameSuggestion)
                {
                    RenameSuggestion suggestion = (RenameSuggestion)item.Tag;
                    if (suggestion.ShouldRename)
                    {
                        try
                        {
                            suggestion.TargetFile.MoveTo(suggestion.TargetFile.DirectoryName + "\\" + suggestion.SuggestedName);
                            item.Checked = false;
                            item.SubItems[0].Text = suggestion.TargetFile.Name;
                            item.ForeColor = Color.Green;
                            successCount++;
                        }
                        catch (Exception e)
                        {
                            item.ForeColor = Color.Red;
                            item.ToolTipText = e.Message;
                            failCount++;
                        }
                        finally
                        {
                            toolStripProgressBar.Value++;
                        }
                    }
                }
            }

            statusLabel.Text = "Renamed " + successCount + " files (" + failCount + " failed)";
        }

        private void fileListView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ListViewItem item = fileListView.Items[e.Index];
            if (item.Tag != null && item.Tag is RenameSuggestion)
            {
                RenameSuggestion suggestion = (RenameSuggestion)item.Tag;
                suggestion.ShouldRename = (e.NewValue == CheckState.Checked);
            }

            int selectedCount = renameSuggestions.Count(s => s.ShouldRename);
            statusLabel.Text = selectedCount.ToString() + " files selected";
            butRename.Enabled = selectedCount != 0;
            butRename.Text = "Rename " + selectedCount + " files";
        }

        private void fileListView_Resize(object sender, EventArgs e)
        {
            foreach (ColumnHeader header in fileListView.Columns)
                header.Width = (fileListView.Width - (fileListView.Margin.Left + fileListView.Margin.Right)) / 2;
        }

        private void txtShowTitle_KeyDown(object sender, KeyEventArgs e)
        {
            txtShowTitle.ForeColor = Color.Black;
        }

        private void txtSeason_KeyDown(object sender, KeyEventArgs e)
        {
            txtSeason.ForeColor = Color.Black;
        }

        private void butLookup_Click(object sender, EventArgs e)
        {
            butLookup.Enabled = false;

            try
            {
                matcher.MatchFiles(
                    txtShowTitle.Text,
                    txtSeason.Text,
                    linkRenamePattern.Text,
                    renameSuggestions
                );
            }
            catch
            {
                MessageBox.Show("Failed to download show details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                butLookup.Enabled = true;
            }

            PopulateFileList();
        }

        private void linkRenamePattern_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRenamePattern frmRenamePattern = new FrmRenamePattern(linkRenamePattern.Text);
            if (frmRenamePattern.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                linkRenamePattern.Text = frmRenamePattern.Pattern;
        }

        private void butRename_Click_1(object sender, EventArgs e)
        {
            toolStripProgressBar.Enabled = true;
            toolStripProgressBar.Maximum = renameSuggestions.Count(s => s.ShouldRename);

            try
            {
                DoRename();
            }
            catch { }

            toolStripProgressBar.Value = 0;
            toolStripProgressBar.Enabled = false;
        }

        private void bottomStatus_Resize(object sender, EventArgs e)
        {

        }

        private void butRegex_Click(object sender, EventArgs e)
        {
            butRegex.Enabled = false;

            try
            {
                regexMatcher.MatchFiles(
                    txtRegex.Text,
                    txtReplace.Text,
                    chkIgnoreCase.Checked,
                    renameSuggestions
                );
            }
            catch
            {
                MessageBox.Show("Failed to apply regular expression", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                butRegex.Enabled = true;
            }

            PopulateFileList();
        }

        private void txtRegex_TextChanged(object sender, EventArgs e)
        {
            // Attempt to complie the regular expression
            txtRegex.ForeColor = (regexMatcher.TestRegex(txtRegex.Text)) ? Color.Green : Color.Red;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void installExplorerContextMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                contextMenuInstaller.InstallContextMenu();
                MessageBox.Show("Successfully installed context menu");
            }
            catch (Exception err)
            {
                MessageBox.Show("Failed to install context menu: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void uninstallExplorerContextMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                contextMenuInstaller.UninstallContextMenu();
                MessageBox.Show("Successfully uninstalled context menu");
            }
            catch (Exception err)
            {
                MessageBox.Show("Failed to uninstall context menu: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Select all items in the list view
        /// </summary>
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in fileListView.Items)
                item.Checked = true;
        }

        /// <summary>
        /// Deselect all items in the list view
        /// </summary>
        private void deselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in fileListView.Items)
                item.Checked = false;
        }

        private void renameFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoRename();
        }

        private void deleteFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int deleteCount = renameSuggestions.Count(s => s.ShouldRename);

            if (MessageBox.Show("Delete " + deleteCount + " files?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                return;

            toolStripProgressBar.Enabled = true;
            toolStripProgressBar.Maximum = deleteCount;

            try
            {
                DoDelete();
            }
            catch { }

            toolStripProgressBar.Value = 0;
            toolStripProgressBar.Enabled = false;
        }

        private void DoDelete()
        {
            int successCount = 0;
            int failCount = 0;
            List<ListViewItem> removals = new List<ListViewItem>();

            foreach (ListViewItem item in fileListView.Items)
            {
                if (!item.Checked)
                    continue;

                if (item.Tag != null && item.Tag is RenameSuggestion)
                {
                    RenameSuggestion suggestion = (RenameSuggestion)item.Tag;

                    try
                    {
                        suggestion.TargetFile.Delete();
                        removals.Add(item);
                        item.Checked = false;
                        successCount++;
                    }
                    catch (Exception e)
                    {
                        item.ForeColor = Color.Red;
                        item.ToolTipText = e.Message;
                        failCount++;
                    }
                    finally
                    {
                        toolStripProgressBar.Value++;
                    }
                }

                foreach (ListViewItem removal in removals)
                {
                    if (item.Tag != null && item.Tag is RenameSuggestion)
                    {
                        RenameSuggestion suggestion = (RenameSuggestion)item.Tag;
                        renameSuggestions.Remove(suggestion);
                    }
                    fileListView.Items.Remove(removal);
                }

                statusLabel.Text = "Deleted " + successCount + " files (" + failCount + " failed)";
            }
        }
    }
}
