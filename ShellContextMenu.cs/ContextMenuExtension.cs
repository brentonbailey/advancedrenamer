using SharpShell.Attributes;
using SharpShell.SharpContextMenu;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ShellContextMenu
{
    /// <summary>
    /// Implements a shell context menu
    /// </summary>
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.Directory)]
    public class ContextMenuExtension : SharpContextMenu
    {
        /// <summary>
        /// Gets whether we should show our context menu or not
        /// </summary>
        /// <returns>True, we should show for all files</returns>
        protected override bool CanShowMenu()
        {
            return SelectedItemPaths.Count() != 0;
        }

        /// <summary>
        /// Create the context menu entry for our shell extension
        /// </summary>
        protected override ContextMenuStrip CreateMenu()
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            //Assembly thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            //Stream file = thisExe.GetManifestResourceStream("ShellContextMenu.Properties.Resources.icon.ico");

            

            ToolStripMenuItem root = new ToolStripMenuItem() { 
                Text = "Advanced Renamer"
            };
            root.Click += root_Click;

            menu.Items.Add(root);
            return menu;
        }

        void root_Click(object sender, EventArgs e)
        {
            try
            {
                OpenRenamer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        /// <summary>
        /// Open the renamer application
        /// </summary>
        private void OpenRenamer()
        {
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            ProcessStartInfo startInfo = new ProcessStartInfo(dir + "\\" + "AdvancedRenamer.exe");

            string renameDir = SelectedItemPaths.FirstOrDefault();
            if (renameDir != "")
            {
                // Replace any single quotes with double quotes
                renameDir = renameDir.Replace("\"", "\"\"");
                startInfo.Arguments = "\"" + renameDir + "\"";
            }

            Process.Start(startInfo);
        }

        
    }
}
