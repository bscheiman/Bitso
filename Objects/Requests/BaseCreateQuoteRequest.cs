#region
using Newtonsoft.Json;

#endregion

namespace Bitso.Objects.Requests {
    public class BaseCreateQuoteRequest : BasePostObject {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("payment_outlet")]
        public string PaymentOutlet { get; set; }

        [JsonProperty("rate")]
        public decimal Rate { get; set; }
    }
}