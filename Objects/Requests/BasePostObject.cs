#region
using bscheiman.Common.Extensions;
using bscheiman.Common.Util;
using Newtonsoft.Json;

#endregion

namespace Bitso.Objects.Requests {
    public class BasePostObject {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("nonce")]
        public long Nonce { get; private set; }

        [JsonProperty("signature")]
        public string Signature { get; private set; }

        public void Setup(string apiUser, long client, string apiSecret) {
            Nonce = DateUtil.Now;
            Key = apiUser;

            string sign = Nonce + Key + client;
            Signature = sign.ToHMAC256(apiSecret);
        }
    }
}