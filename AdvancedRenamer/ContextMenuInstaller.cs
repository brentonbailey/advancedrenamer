using SharpShell;
using SharpShell.ServerRegistration;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AdvancedRenamer
{
    public class ContextMenuInstaller
    {
        /// <summary>
        /// Gets the assembly path of the shell extension context menu dll
        /// </summary>
        private string ContextMenuAssemblyPath
        {
            get
            {
                string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                return Path.Combine(dir, "ShellContextMenu.dll");
            }
        }



        /// <summary>
        /// Install the shell extension context menu
        /// </summary>
        public void InstallContextMenu()
        {
            RegistrationType regType = Environment.Is64BitOperatingSystem ? RegistrationType.OS64Bit : RegistrationType.OS32Bit;
            foreach (ISharpShellServer server in LoadServerTypes(ContextMenuAssemblyPath))
            {
                SharpShell.ServerRegistration.ServerRegistrationManager.InstallServer(server, regType, false);
                SharpShell.ServerRegistration.ServerRegistrationManager.RegisterServer(server, regType);
            }
        }

        /// <summary>
        /// Uninstall the shell extension context menu
        /// </summary>
        public void UninstallContextMenu()
        {
            RegistrationType regType = Environment.Is64BitOperatingSystem ? RegistrationType.OS64Bit : RegistrationType.OS32Bit;
            foreach (ISharpShellServer server in LoadServerTypes(ContextMenuAssemblyPath))
            {
                SharpShell.ServerRegistration.ServerRegistrationManager.UninstallServer(server, regType);
                SharpShell.ServerRegistration.ServerRegistrationManager.UnregisterServer(server, regType);
            }
        }



        private static IEnumerable<ISharpShellServer> LoadServerTypes(string assemblyPath)
        {
            //  Create an assembly catalog for the assembly and a container from it.
            AssemblyCatalog catalog = new AssemblyCatalog(Path.GetFullPath(assemblyPath));
            CompositionContainer container = new CompositionContainer(catalog);

            //  Get all exports of type ISharpShellServer.
            return container.GetExports<ISharpShellServer>().Select(st => st.Value);
        }
    }
}
