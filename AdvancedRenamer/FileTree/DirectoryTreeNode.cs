using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedRenamer.FileTree
{
    class DirectoryTreeNode : TreeNode
    {
        bool hasExpanded = false;

        /// <summary>
        /// Gets or sets whether this node has been expanded before
        /// </summary>
        public bool HasExpanded
        {
            get { return hasExpanded; }
            set { hasExpanded = value; }
        }

        /// <summary>
        /// Gets or sets the directory this node is tied to
        /// </summary>
        public DirectoryInfo Directory { get; set; }

    }
}
