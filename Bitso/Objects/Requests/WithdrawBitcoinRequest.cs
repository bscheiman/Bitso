#region
using Newtonsoft.Json;

#endregion

namespace Bitso.Objects.Requests {
    public class WithdrawBitcoinRequest : BasePostObject {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }
}