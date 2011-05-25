using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using EnvDTE;
using Microsoft.VisualStudio.Shell;


namespace YongFa365.BatchFormat
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(GuidList.guidBatchFormatPkgString)]
    public sealed class BatchFormatPackage : Package
    {
        private DTE dte = null;
        private PkgCmdIDList selectedMenu = PkgCmdIDList.Null;
        private List<string> alreadyOpenFiles = new List<string>();


        protected override void Initialize()
        {
            base.Initialize();
            dte = (DTE)base.GetService(typeof(DTE));

            // Add our command handlers for menu (commands must exist in the .vsct file)
            var mcs = GetService(typeof(IMenuCommandService)) as MenuCommandService;
            if (null != mcs)
            {
                // Create the command for the menu item.
                foreach (int item in Enum.GetValues(typeof(PkgCmdIDList)))
                {
                    var menuCommandID = new CommandID(GuidList.guidBatchFormatCmdSet, item);
                    var menuItem = new MenuCommand(Excute, menuCommandID);
                    mcs.AddCommand(menuItem);
                }
            }
        }


        private void Excute(object sender, EventArgs e)
        {
            selectedMenu = (PkgCmdIDList)((MenuCommand)sender).CommandID.ID;

            var table = new RunningDocumentTable(this);
            alreadyOpenFiles = (from info in table select info.Moniker).ToList<string>();

            var selectedItem = dte.SelectedItems.Item(1);
            dte.StatusBar.Text = "BatchFormat 处理中...";
            Stopwatch sp = new Stopwatch();
            sp.Start();

            if (selectedItem.Project == null && selectedItem.ProjectItem == null)
            {
                ProcessSolution();
            }
            else if (selectedItem.Project != null)
            {
                ProcessProject(selectedItem.Project);
            }
            else if (selectedItem.ProjectItem != null)
            {
                if (selectedItem.ProjectItem.ProjectItems.Count > 0)
                {
                    ProcessProjectItems(selectedItem.ProjectItem.ProjectItems);
                }
                else
                {
                    ProcessProjectItem(selectedItem.ProjectItem);
                }
            }
            sp.Stop();
            dte.StatusBar.Text = string.Format("BatchFormat 处理中完成 耗时：{0}s", sp.ElapsedMilliseconds / 1000);

        }

        private void ProcessSolution()
        {
            if (dte.Solution != null)
            {
                var projects = (from prj in new ProjectIterator(dte.Solution)
                                where prj.Kind == GuidList.guidCsharpProjectString
                                select prj);

                projects.ForEach(prj => ProcessProject(prj));
            }
        }

        private void ProcessProject(Project project)
        {
            if (project != null)
            {
                ProcessProjectItems(project.ProjectItems);
            }
        }

        private void ProcessProjectItems(ProjectItems projectItems)
        {
            if (projectItems != null)
            {
                var result = from item in new ProjectItemIterator(projectItems)
                             where item.FileCodeModel != null
                             select item;
                result.ForEach(item => ProcessProjectItem(item));
            }
        }

        private void ProcessProjectItem(ProjectItem projectItem)
        {
            string fileName;
            if (projectItem != null)
            {
                fileName = projectItem.FileNames[1];
                dte.StatusBar.Text = "BatchFormat 正在处理：" + fileName;
                Window window = dte.OpenFile("{7651A703-06E5-11D1-8EBD-00A0C90F26EA}", fileName);
                window.Activate();
                #region 执行命令
                try
                {
                    switch (selectedMenu)
                    {
                        case PkgCmdIDList.cmdidRemoveUnusedUsings:
                            dte.ExecuteCommand("Edit.RemoveUnusedUsings");
                            break;
                        case PkgCmdIDList.cmdidSortUsings:
                            dte.ExecuteCommand("Edit.SortUsings");
                            break;
                        case PkgCmdIDList.cmdidRemoveAndSortUsings:
                            dte.ExecuteCommand("Edit.RemoveAndSort");
                            break;
                        case PkgCmdIDList.cmdidFormatDocument:
                            dte.ExecuteCommand("Edit.FormatDocument");
                            break;
                        case PkgCmdIDList.cmdidSortUsingsAndFormatDocument:
                            dte.ExecuteCommand("Edit.SortUsings");
                            dte.ExecuteCommand("Edit.FormatDocument");
                            break;
                        case PkgCmdIDList.cmdidRemoveAndSortUsingsAndFormatDocument:
                            dte.ExecuteCommand("Edit.RemoveAndSort");
                            dte.ExecuteCommand("Edit.FormatDocument");
                            break;
                        default:
                            break;
                    }

                }
                catch (COMException)
                {
                }
                #endregion

                if (alreadyOpenFiles.Exists(file => file.Equals(fileName, StringComparison.OrdinalIgnoreCase)))
                {
                    dte.ActiveDocument.Save(fileName);
                }
                else
                {
                    window.Close(vsSaveChanges.vsSaveChangesYes);
                }
            }
        }

    }
}
