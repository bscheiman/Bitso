#region
using System;
using System.Collections.Generic;
using bscheiman.Common.Extensions;
using Newtonsoft.Json;

#endregion

namespace Bitso.Objects.Responses {
    public class OrderBook {
        [JsonProperty("asks")]
        public IList<IList<decimal>> Asks { get; set; }

        [JsonProperty("bids")]
        public IList<IList<decimal>> Bids { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        public DateTime TimestampDt {
            get { return Timestamp.FromEpoch().ToLocalTime(); }
        }
    }
}