using System;

namespace FXCMRestAPIExample
{
    public class FXCMCandle
    {
        public DateTime Time { get; set; }
        public decimal BidOpen { get; set; }
        public decimal BidClose { get; set; }
        public decimal BidHigh { get; set; }
        public decimal BidLow { get; set; }
        public decimal AskOpen { get; set; }
        public decimal AskClose { get; set; }
        public decimal AskHigh { get; set; }
        public decimal AskLow { get; set; }
        public int TickQty { get; set; }

        public override string ToString()
        {
            return $"{Time},{BidOpen},{AskOpen},{BidHigh},{AskHigh},{BidLow},{AskLow},{BidClose},{AskClose}";
        }
    }
}
