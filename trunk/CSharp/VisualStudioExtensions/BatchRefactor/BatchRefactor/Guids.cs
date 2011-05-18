// Guids.cs
// MUST match guids.h
using System;

namespace YongFa365.BatchRefactor
{
    static class GuidList
    {
        public const string guidBatchRefactorPkgString = "ca45914b-4959-408a-98cf-87e4f9e97815";
        public const string guidBatchRefactorCmdSetString = "70fd9bbd-df20-4bc5-b51c-eaa35b408b7c";

        public static readonly Guid guidBatchRefactorCmdSet = new Guid(guidBatchRefactorCmdSetString);
    };
}