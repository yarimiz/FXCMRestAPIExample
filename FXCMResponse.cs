﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXCMRestAPIExample
{
    public abstract class FXCMResponse
    {
        [JsonProperty("response")]
        public ResponseMetaData Metadata { get; set; }
    }
}
