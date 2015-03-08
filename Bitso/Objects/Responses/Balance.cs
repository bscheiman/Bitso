#region
using Newtonsoft.Json;

#endregion

namespace Bitso.Objects.Responses {
    public class Balance {
        [JsonProperty("btc_available")]
        public decimal BtcAvailable { get; set; }

        [JsonProperty("btc_balance")]
        public decimal BtcBalance { get; set; }

        [JsonProperty("btc_reserved")]
        public decimal BtcReserved { get; set; }

        [JsonProperty("fee")]
        public decimal Fee { get; set; }

        [JsonProperty("mxn_available")]
        public decimal MxnAvailable { get; set; }

        [JsonProperty("mxn_balance")]
        public decimal MxnBalance { get; set; }

        [JsonProperty("mxn_reserved")]
        public decimal MxnReserved { get; set; }
    }
}