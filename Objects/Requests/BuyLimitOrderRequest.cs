#region
using Newtonsoft.Json;

#endregion

namespace Bitso.Objects.Requests {
    public class BuyLimitOrderRequest : BasePostObject {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("book")]
        public string Book { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}