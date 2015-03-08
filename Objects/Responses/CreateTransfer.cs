#region
using Newtonsoft.Json;

#endregion

namespace Bitso.Objects.Responses {
    public class CreateTransfer {
        [JsonProperty("order")]
        public Order Order { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}