using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXCMRestAPIExample
{
    public class FXCMOffer
    {
        [JsonProperty("offerid")]
        public int OfferId { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
