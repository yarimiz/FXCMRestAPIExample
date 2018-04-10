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
        public T Parse<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }

    public interface IFXCMResponseParser
    {
        T Parse<T>(string json);
    }
}
