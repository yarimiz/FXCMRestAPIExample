using Newtonsoft.Json;

namespace FXCMRestAPIExample
{
    public class FXCMCandlesResponse : FXCMResponse
    {
        [JsonProperty("instrument_id")]
        public int InstrumentId { get; set; }

        [JsonProperty("period_id")]
        public string PeriodId { get; set; }

        [JsonProperty("candles")]
        public object[][] Candles { get; set; }
    }
}
