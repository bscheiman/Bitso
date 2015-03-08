#region
using Newtonsoft.Json;

#endregion

namespace Bitso.Objects.Requests {
    public class RippleCreateQuoteRequest : BaseCreateQuoteRequest {
        [JsonProperty("ripple_address")]
        public string RippleAddress { get; set; }
    }
}