using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Services.Common.DomainObjects
{
    public class ErrorResult
    {
        public ErrorResult(void v)
        {
            ErrorValues = new List<string>();
        }

        [JsonPropertyName("errorCode")]
        public string ErrorCode { get; set; }

        [JsonPropertyName("errorMessage")]
        public string ErrorMessage { get; set; }

        [JsonPropertyName("errorValues")]
        public List<string> ErrorValues { get; set; }
    }
}