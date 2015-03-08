#region
using Newtonsoft.Json;

#endregion

namespace Bitso.Objects.Requests {
    public class OpenOrdersRequest : BasePostObject {
        [JsonProperty("book")]
        public string Book { get; set; }
    }
}