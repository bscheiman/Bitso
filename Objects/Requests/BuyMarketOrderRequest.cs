#region
using Newtonsoft.Json;

#endregion

namespace Bitso.Objects.Requests {
    public class BuyMarketOrderRequest : BasePostObject {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("book")]
        public string Book { get; set; }
    }
}