using Services.Common.DomainObjects;
using Services.Common.Utilities;
using System;

namespace ProjectManager.CMD.Domain
{
    public static class ProjectManagerExtensions
    {
        public static void AddAPIErrorMessage(this VoidMethodResult errorResult, string errorCode, string[] errorValues)
        {
            errorResult.AddErrorMessage(errorCode, GetErrorMessage(errorCode), errorValues);
        }

        public static string GetErrorMessage(string errorCode)
        {
            return ErrorHelpers.GetErrorMessage(errorCode, typeof(ProjectManagerExtensions).Assembly);
        }
    }
}
