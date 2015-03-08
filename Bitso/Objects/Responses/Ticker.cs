#region
using System;
using bscheiman.Common.Extensions;
using Newtonsoft.Json;

#endregion

namespace Bitso.Objects.Responses {
    public class Ticker {
        [JsonProperty("ask")]
        public decimal Ask { get; set; }

        [JsonProperty("bid")]
        public decimal Bid { get; set; }

        [JsonProperty("high")]
        public decimal High { get; set; }

        [JsonProperty("last")]
        public decimal Last { get; set; }

        [JsonProperty("low")]
        public decimal Low { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        public DateTime TimestampDt {
            get { return Timestamp.FromEpoch().ToLocalTime(); }
        }

        [JsonProperty("volume")]
        public decimal Volume { get; set; }

        [JsonProperty("vwap")]
        public decimal Vwap { get; set; }
    }
}