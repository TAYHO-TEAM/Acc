using Services.Common.DomainObjects;
using Services.Common.Utilities;

namespace Acc.Cmd.Domain
{
    public static class AccExtensions
    {
        public static void AddAPIErrorMessage(this VoidMethodResult errorResult, string errorCode, string[] errorValues)
        {
            errorResult.AddErrorMessage(errorCode, GetErrorMessage(errorCode), errorValues);
        }

        public static string GetErrorMessage(string errorCode)
        {
            return ErrorHelpers.GetErrorMessage(errorCode, typeof(AccExtensions).Assembly);
        }
    }
}
