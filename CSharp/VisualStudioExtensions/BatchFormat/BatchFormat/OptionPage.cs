/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using System.Collections.Generic;

namespace YongFa365.BatchFormat
{
    [Guid(GuidList.GuidPageGeneralString)]
    [ComVisible(true)]
    public class OptionPage : DialogPage
    {
        private string endsWith;

        [Description("Set EndsWith string value split by \"|\" \r\neg:AssemblyInfo.cs|.designer.cs|Reference.cs \r\nDelete All will default.")]
        public string EndsWith
        {
            get
            {
                if (string.IsNullOrWhiteSpace(endsWith))
                {
                    return string.Join("|",ConfigHelper.EndsWithList);
                }
                return endsWith;
            }
            set
            {
                endsWith = value;
            }
        }

    }
}
