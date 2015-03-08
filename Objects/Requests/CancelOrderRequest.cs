#region
using Newtonsoft.Json;

#endregion

namespace Bitso.Objects.Requests {
    public class CancelOrderRequest : BasePostObject {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}