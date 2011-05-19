using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using EnvDTE;
using EnvDTE80;
using System.Linq;
using System.Collections.Generic;

namespace YongFa365.BatchRefactor
{

    public static class MyClass
    {
        public static void ForEach<TItem>(this IEnumerable<TItem> source, Action<TItem> action)
        {
            foreach (TItem local in source)
            {
                action(local);
            }
        }
    }






    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    ///
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the 
    /// IVsPackage interface and uses the registration attributes defined in the framework to 
    /// register itself and its components with the shell.
    /// </summary>
    // This attribute tells the PkgDef creation utility (CreatePkgDef.exe) that this class is
    // a package.
    [PackageRegistration(UseManagedResourcesOnly = true)]
    // This attribute is used to register the informations needed to show the this package
    // in the Help/About dialog of Visual Studio.
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    // This attribute is needed to let the shell know that this package exposes some menus.
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(GuidList.guidBatchRefactorPkgString)]
    public sealed class BatchRefactorPackage : Package
    {
        private DTE dte = null;



        /// <summary>
        /// Default constructor of the package.
        /// Inside this method you can place any initialization code that does not require 
        /// any Visual Studio service because at this point the package object is created but 
        /// not sited yet inside Visual Studio environment. The place to do all the other 
        /// initialization is the Initialize method.
        /// </summary>
        public BatchRefactorPackage()
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
        }



        /////////////////////////////////////////////////////////////////////////////
        // Overriden Package Implementation
        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initilaization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));
            base.Initialize();
            dte = (DTE)base.GetService(typeof(DTE));

            // Add our command handlers for menu (commands must exist in the .vsct file)
            OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (null != mcs)
            {
                // Create the command for the menu item.
                CommandID menuCommandID = null;
                MenuCommand menuItem = null;

                menuCommandID = new CommandID(GuidList.guidBatchRefactorCmdSet, (int)PkgCmdIDList.cmdidFormatDocument);
                menuItem = new MenuCommand(MenuItemCallback1, menuCommandID);
                mcs.AddCommand(menuItem);

                menuCommandID = new CommandID(GuidList.guidBatchRefactorCmdSet, (int)PkgCmdIDList.cmdidRemoveAndSortUsings);
                menuItem = new MenuCommand(MenuItemCallback2, menuCommandID);
                mcs.AddCommand(menuItem);

                menuCommandID = new CommandID(GuidList.guidBatchRefactorCmdSet, (int)PkgCmdIDList.cmdidRemoveAndSortUsingsAndFormatDocument);
                menuItem = new MenuCommand(MenuItemCallback3, menuCommandID);
                mcs.AddCommand(menuItem);
            }
        }
        #endregion


        private void MenuItemCallback1(object sender, EventArgs e)
        {
            
            Project project = dte.SelectedItems.Item(1).Project;

            if (null != project && project.Kind == GuidList.guidCsharpProjectString)
            {
                ProcessProject(project);

            }
            else if (dte.Solution != null)
            {
                var prjs = (from Project prj in dte.Solution
                            where prj.Kind == GuidList.guidCsharpProjectString
                            select prj);
                foreach (var item in prjs)
                {
                    ProcessProject(item);
                }

            }
        }

        private void ProcessProject(Project project)
        {
            string fileName;
            if (project != null)
            {
                List<string> alreadyOpenFiles;

                RunningDocumentTable table = new RunningDocumentTable(this);
                alreadyOpenFiles = (from info in table select info.Moniker).ToList<string>();
                var aaa = (from ProjectItem item in project.ProjectItems
                           where item.FileCodeModel != null
                           select item).ToList();


                (from ProjectItem item in project.ProjectItems
                 where item.FileCodeModel != null
                 select item).ForEach(item =>
                 {
                     var asdf = item.Name;
                     var aaaaaaa = item.FileNames[1];
                     fileName = item.get_FileNames(1);
                     Window window = dte.OpenFile("{7651A703-06E5-11D1-8EBD-00A0C90F26EA}", fileName);
                     window.Activate();
                     try
                     {
                         dte.ExecuteCommand("Edit.RemoveAndSort", string.Empty);
                         dte.ExecuteCommand("Edit.FormatDocument", string.Empty);
                     }
                     catch (COMException)
                     {
                     }
                     if (alreadyOpenFiles.Exists(file => file.Equals(fileName, StringComparison.OrdinalIgnoreCase)))
                     {
                         dte.ActiveDocument.Save(fileName);
                     }
                     else
                     {
                         window.Close(vsSaveChanges.vsSaveChangesYes);
                     }
                 });

            }
        }



        private void MenuItemCallback2(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Test2");
        }
        private void MenuItemCallback3(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Test3");
        }
        private void MenuItemCallback4(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Test4");
        }

    }
}
