using Services.Common.DomainObjects;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.BLL.Extensions
{
    public static class OperationManagerExtensions
    {
        public static void AddAPIErrorMessage(this VoidMethodResult errorResult, string errorCode, string[] errorValues)
        {
            errorResult.AddErrorMessage(errorCode, GetErrorMessage(errorCode), errorValues);
        }

        public static string GetErrorMessage(string errorCode)
        {
            return ErrorHelpers.GetErrorMessage(errorCode, typeof(OperationManagerExtensions).Assembly);
        }
    }
}
