// PkgCmdID.cs
// MUST match PkgCmdID.h
using System;

namespace YongFa365.BatchRefactor
{
    static class PkgCmdIDList
    {
        public const uint cmdidRemoveUnusedUsings = 0x2001;
        public const uint cmdidSortUsings = 0x2002;
        public const uint cmdidRemoveAndSortUsings = 0x2003;
        public const uint cmdidFormatDocument = 0x2004;
        public const uint cmdidSortUsingsAndFormatDocument = 0x2005;
        public const uint cmdidRemoveAndSortUsingsAndFormatDocument = 0x2006;
    };
}