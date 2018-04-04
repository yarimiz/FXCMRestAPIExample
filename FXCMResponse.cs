using Newtonsoft.Json;

namespace FXCMRestAPIExample
{
    public class FXCMResponse
    {
        [JsonProperty("response")]
        public ResponseMetaData Metadata { get; set; }

        [JsonProperty("instrument_id")]
        public int InstrumentId { get; set; }

        [JsonProperty("period_id")]
        public string PeriodId { get; set; }

        [JsonProperty("candles")]
        public object[][] Candles { get; set; }
    }
}
