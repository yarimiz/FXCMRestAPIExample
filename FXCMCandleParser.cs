using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXCMRestAPIExample
{
    public class FXCMCandleParser : IFXCMCandleParser
    {
        public List<FXCMCandle> ParseCandles(FXCMCandlesResponse fxcmResponse)
        {
            var candleList = new List<FXCMCandle>();
            fxcmResponse.Candles.ToList().ForEach(array => candleList.Add(ParseCandle(array)));

            return candleList;
        }

        private FXCMCandle ParseCandle(object[] properties)
        {
            return new FXCMCandle
            {
                Time = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(double.Parse(properties[0].ToString())),
                BidOpen = decimal.Parse(properties[1].ToString()),
                BidClose = decimal.Parse(properties[2].ToString()),
                BidHigh = decimal.Parse(properties[3].ToString()),
                BidLow = decimal.Parse(properties[4].ToString()),
                AskOpen = decimal.Parse(properties[5].ToString()),
                AskClose = decimal.Parse(properties[6].ToString()),
                AskHigh = decimal.Parse(properties[7].ToString()),
                AskLow = decimal.Parse(properties[8].ToString()),
                TickQty = int.Parse(properties[9].ToString())
            };
        }
    }
}
