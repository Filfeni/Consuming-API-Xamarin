using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp.Models
{
    public class Brand
    {
        [JsonProperty("idmarca")]
        public int Id { get; set; }

        [JsonProperty("marca1")]
        public string Name { get; set; }
    }
}
