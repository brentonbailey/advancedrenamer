using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedRenamer.FileTree
{

    
       

    public class ShellManager
    {
        [Flags]
        enum SHGFI : int
        {
            /// <summary>get icon</summary>
            Icon = 0x000000100,
            /// <summary>get display name</summary>
            DisplayName = 0x000000200,
            /// <summary>get type name</summary>
            TypeName = 0x000000400,
            /// <summary>get attributes</summary>
            Attributes = 0x000000800,
            /// <summary>get icon location</summary>
            IconLocation = 0x000001000,
            /// <summary>return exe type</summary>
            ExeType = 0x000002000,
            /// <summary>get system icon index</summary>
            SysIconIndex = 0x000004000,
            /// <summary>put a link overlay on icon</summary>
            LinkOverlay = 0x000008000,
            /// <summary>show icon in selected state</summary>
            Selected = 0x000010000,
            /// <summary>get only specified attributes</summary>
            Attr_Specified = 0x000020000,
            /// <summary>get large icon</summary>
            LargeIcon = 0x000000000,
            /// <summary>get small icon</summary>
            SmallIcon = 0x000000001,
            /// <summary>get open icon</summary>
            OpenIcon = 0x000000002,
            /// <summary>get shell size icon</summary>
            ShellIconSize = 0x000000004,
            /// <summary>pszPath is a pidl</summary>
            PIDL = 0x000000008,
            /// <summary>use passed dwFileAttribute</summary>
            UseFileAttributes = 0x000000010,
            /// <summary>apply the appropriate overlays</summary>
            AddOverlays = 0x000000020,
            /// <summary>Get the index of the overlay in the upper 8 bits of the iIcon</summary>
            OverlayIndex = 0x000000040,
        }

        private const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
        private const uint FILE_ATTRIBUTE_FILE = 0x00000100;

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern int SHGetFileInfo(
            string pszPath,
            uint dwFileAttributes,
            out    SHFILEINFO psfi,
            uint cbfileInfo,
            SHGFI uFlags
        );

        /// <summary>Maximal Length of unmanaged Windows-Path-strings</summary>
        private const int MAX_PATH = 260;
        /// <summary>Maximal Length of unmanaged Typename</summary>
        private const int MAX_TYPE = 80;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct SHFILEINFO
        {
            public SHFILEINFO(bool b)
            {
                hIcon = IntPtr.Zero;
                iIcon = 0;
                dwAttributes = 0;
                szDisplayName = "";
                szTypeName = "";
            }
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_TYPE)]
            public string szTypeName;
        };

        /// <summary>
        /// Get the small icon for the given path
        /// </summary>
        /// <param name="path">The file system path of the item</param>
        /// <returns>The file system icon</returns>
        public static Icon GetSmallIcon(string path)
        {
            return GetIcon(path, SHGFI.SmallIcon, FILE_ATTRIBUTE_FILE);
        }

        /// <summary>
        /// Get the folder icon
        /// </summary>
        /// <param name="path">The path of the folder</param>
        /// <param name="expanded">Whether or not the folder is expanded</param>
        /// <returns>The file system icon</returns>
        public static Icon GetFolderIcon(string path, bool expanded)
        {
            SHGFI flags = SHGFI.SmallIcon;
            if (expanded)
                flags |= SHGFI.OpenIcon;

            return GetIcon(path, flags, FILE_ATTRIBUTE_DIRECTORY);
        }

        /// <summary>
        /// Get the file system icon for the given path
        /// </summary>
        /// <param name="path">The file system path</param>
        /// <param name="flags">The properties of the icon to retrieve</param>
        /// <returns>The filesystem icon</returns>
        private static Icon GetIcon(string path, SHGFI flags, uint attributes)
        {
            SHFILEINFO info = new SHFILEINFO(true);
            int cbFileInfo = Marshal.SizeOf(info);
            flags |= SHGFI.Icon | SHGFI.UseFileAttributes;
            
            SHGetFileInfo(path, attributes, out info, (uint)cbFileInfo, flags);
            Icon icon = Icon.FromHandle(info.hIcon);
            return icon;
        }
    }
}
