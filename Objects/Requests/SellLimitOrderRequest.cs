#region
using Newtonsoft.Json;

#endregion

namespace Bitso.Objects.Requests {
    public class SellLimitOrderRequest : BasePostObject {
        [JsonProperty("book")]
        public string Book { get; set; }
    }
}