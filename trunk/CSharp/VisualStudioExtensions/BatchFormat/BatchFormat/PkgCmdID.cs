// PkgCmdID.cs
// MUST match PkgCmdID.h

namespace YongFa365.BatchFormat
{
    enum PkgCmdIDList
    {
        Null,
        cmdidRemoveUnusedUsings = 0x2001,
        cmdidSortUsings = 0x2002,
        cmdidRemoveAndSortUsings = 0x2003,
        cmdidFormatDocument = 0x2004,
        cmdidSortUsingsAndFormatDocument = 0x2005,
        cmdidRemoveAndSortUsingsAndFormatDocument = 0x2006
    }
    //static class PkgCmdIDList
    //{
    //    public const uint cmdidRemoveUnusedUsings = 0x2001;
    //    public const uint cmdidSortUsings = 0x2002;
    //    public const uint cmdidRemoveAndSortUsings = 0x2003;
    //    public const uint cmdidFormatDocument = 0x2004;
    //    public const uint cmdidSortUsingsAndFormatDocument = 0x2005;
    //    public const uint cmdidRemoveAndSortUsingsAndFormatDocument = 0x2006;
    //};
}