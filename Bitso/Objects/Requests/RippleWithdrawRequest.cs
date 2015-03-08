#region
using Newtonsoft.Json;

#endregion

namespace Bitso.Objects.Requests {
    public class RippleWithdrawRequest : BasePostObject {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}