// Guids.cs
// MUST match guids.h
using System;

namespace YongFa365.BatchRefactor
{
    static class GuidList
    {
        public const string guidBatchRefactorPkgString = "ca45914b-4959-408a-98cf-87e4f9e97815";
        public const string guidBatchRefactorCmdSetString = "70fd9bbd-df20-4bc5-b51c-eaa35b408b7c";

        //Project
        public const string guidCsharpProjectString = "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}";

        public static readonly Guid guidBatchRefactorCmdSet = new Guid(guidBatchRefactorCmdSetString);
    };
}