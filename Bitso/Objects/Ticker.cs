#region
using System;
using System.Collections.Generic;
using bscheiman.Common.Extensions;
using Newtonsoft.Json;

#endregion

namespace Bitso.Objects {
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

    public class Transaction {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("date")]
        public long Date { get; set; }

        public DateTime DateDt {
            get { return Date.FromEpoch().ToLocalTime(); }
        }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("tid")]
        public int Tid { get; set; }
    }

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