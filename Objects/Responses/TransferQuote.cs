#region
using Newtonsoft.Json;

#endregion

namespace Bitso.Objects.Responses {
    public class TransferQuote {
        [JsonProperty("quote")]
        public Quote Quote { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}