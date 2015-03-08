#region
using Newtonsoft.Json;

#endregion

namespace Bitso.Objects.Requests {
    public class TransferQuoteRequest : BasePostObject {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("full")]
        public bool Full { get; set; }
    }
}