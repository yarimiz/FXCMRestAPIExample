using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXCMRestAPIExample
{
    public class FXCMResponseParser : IFXCMResponseParser
    {
        public FXCMResponse Parse(string json)
        {
            return JsonConvert.DeserializeObject<FXCMResponse>(json);
        }
    }

    public interface IFXCMResponseParser
    {
        FXCMResponse Parse(string json);
    }
}
