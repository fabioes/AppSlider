using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AppSlider.WebApi.Model
{
    public class ApiReturnMessage
    {
        [JsonProperty("title")]
        public String Title { get; set; }

        [JsonProperty("details")]
        public List<String> Details { get; set; }
    }
}