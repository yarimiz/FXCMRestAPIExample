using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXCMRestAPIExample
{
    public class FXCMOfferResponse : FXCMResponse
    {
        [JsonProperty("offers")]
        public List<FXCMOffer> Offers { get; set; }
    }
}
