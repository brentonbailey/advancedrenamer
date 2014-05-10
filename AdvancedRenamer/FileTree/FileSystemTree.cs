using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AdvancedRenamer.FileTree
{
    public delegate void DirectoryDelegate(FileSystemTree sender, DirectoryInfo directory);

    public partial class FileSystemTree : UserControl
    {
        public event DirectoryDelegate DirectoryClicked;
        public event DirectoryDelegate DirectoryDoubleClicked;

        public FileSystemTree()
        {
            InitializeComponent();
            PopulateDrives();

            // Add the folder icons
            imageListIcons.Images.Add("DIRECTORY", ShellManager.GetFolderIcon(Environment.CurrentDirectory, false));
        }

        private void PopulateDrives()
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                string name;
                if (drive.IsReady)
                    name = String.Format("{0} ({1}:)", drive.VolumeLabel, drive.Name[0]);
                else
                    name = String.Format("{0} ({1}:)", drive.DriveType, drive.Name[0]);

                fileTreeView.Nodes.Add(CreateDirectoryNode(name, drive.RootDirectory));
            }
        }


        private TreeNode CreateDirectoryNode(DirectoryInfo dir)
        {
            return CreateDirectoryNode(dir.Name, dir);
        }

        /// <summary>
        /// Create a directory tree node
        /// </summary>
        /// <param name="dir">The parent directory</param>
        /// <returns>The tree node that represents the directory</returns>
        private TreeNode CreateDirectoryNode(string name, DirectoryInfo dir)
        {

            string key = "DIRECTORY";
            if (dir.Parent == null)
            {
                // This is a drive
                key = name;
                imageListIcons.Images.Add(key, ShellManager.GetSmallIcon(dir.FullName));
            }

            DirectoryTreeNode node = new DirectoryTreeNode()
            {
                Text = name,
                Directory = dir,
                ImageKey = key,
                SelectedImageKey = key
            };

            // Add a dummy node so that this node shows an expanding icon
            TreeNode dummyNode = new TreeNode()
            {
                Text = "Loading...",
                Tag = "DUMMY"
            };

            node.Nodes.Add(dummyNode);

            return node;
        }

        private TreeNode CreateFileNode(FileInfo file)
        {
            string key = file.Extension;
            if (!imageListIcons.Images.ContainsKey(file.Extension))
            {
                // Get the icon for this extension
                imageListIcons.Images.Add(key, ShellManager.GetSmallIcon(file.FullName));
            }

            TreeNode node = new TreeNode()
            {
                Text = file.Name,
                ImageKey = key,
                SelectedImageKey = key
            };

            return node;
        }

        private void fileTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            DirectoryTreeNode node = (DirectoryTreeNode)e.Node;
            PopulateNode(node);
        }

        private void PopulateNode(DirectoryTreeNode node)
        {
            if (!node.HasExpanded)
            {
                // Populate the child nodes
                node.Nodes.Clear();
                foreach (DirectoryInfo subDir in node.Directory.GetDirectories().OrderBy(d => d.Name))
                {
                    if (CheckDisplay(subDir.Attributes))
                        node.Nodes.Add(CreateDirectoryNode(subDir));
                }


                foreach (FileInfo file in node.Directory.GetFiles().OrderBy(f => f.Name))
                {
                    if (CheckDisplay(file.Attributes))
                        node.Nodes.Add(CreateFileNode(file));
                }

                node.HasExpanded = true;
            }
        }

        /// <summary>
        /// Check whether we want to display this item
        /// </summary>
        /// <param name="attributes">The file attributes</param>
        /// <returns>true if we want to display it, false otherwise</returns>
        private bool CheckDisplay(FileAttributes attributes)
        {
            return ((attributes & FileAttributes.Hidden) == 0 && (attributes & FileAttributes.System) == 0);
        }

        /// <summary>
        /// Fires when the user double clicks
        /// </summary>
        private void fileTreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DirectoryInfo dir = GetDirectoryClicked(e.Location);
            if (dir != null && DirectoryDoubleClicked != null)
                DirectoryDoubleClicked(this, dir);
        }

        /// <summary>
        /// Fires when the user clicks
        /// </summary>
        private void fileTreeView_MouseClick(object sender, MouseEventArgs e)
        {
            DirectoryInfo dir = GetDirectoryClicked(e.Location);
            if (dir != null && DirectoryClicked != null)
                DirectoryClicked(this, dir);
        }

        /// <summary>
        /// Get the directory clicked on
        /// </summary>
        /// <param name="pt">The mouse location</param>
        /// <returns>The directory clicked on or null</returns>
        private DirectoryInfo GetDirectoryClicked(Point pt)
        {
            DirectoryInfo dir = null;
            TreeNode node = fileTreeView.GetNodeAt(pt);
            if (node != null && node is DirectoryTreeNode)
            {
                dir = (node as DirectoryTreeNode).Directory;
            }

            return dir;
        }

        /// <summary>
        /// Navigate to a directory
        /// </summary>
        /// <param name="dir">The directory to navigate to</param>
        public void NavigateToDirectory(DirectoryInfo dir)
        {
            ExpandDirNode(dir);
        }

        private TreeNode ExpandDirNode(DirectoryInfo dir)
        {
            TreeNodeCollection nodes = null;

            if (dir.Parent == null)
            {
                // We are at the root level
                nodes = fileTreeView.Nodes;
                dir = dir.Root;
            }
            else
            {
                // Expand the parent level first
                TreeNode parentNode = ExpandDirNode(dir.Parent);
                nodes = parentNode.Nodes;
            }
            

            foreach (TreeNode node in nodes)
            {
                if (node is DirectoryTreeNode)
                {
                    DirectoryTreeNode dirNode = (DirectoryTreeNode)node;
                    // DirectoryInfo comparison is annoyingly unhelpful.
                    // use string comparison instead...
                    string str1 = dirNode.Directory.FullName.TrimEnd(new char[] { '\\' });
                    string str2 = dir.FullName.TrimEnd(new char[] { '\\' });

                    if (str1.Equals(str2, StringComparison.CurrentCultureIgnoreCase))
                    {
                        PopulateNode(dirNode);
                        node.Expand();
                        return node;
                    }
                }
            }

            return null;
        }
    }
}
