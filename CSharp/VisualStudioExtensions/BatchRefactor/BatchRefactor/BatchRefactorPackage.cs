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

namespace YongFa365.BatchRefactor
{
    [ProvideMenuResource("Menus.ctmenu", 1)]
    public sealed class BatchRefactorPackage : Package
    {
        protected override void Initialize()
        {
            base.Initialize();
        }
    }
}
