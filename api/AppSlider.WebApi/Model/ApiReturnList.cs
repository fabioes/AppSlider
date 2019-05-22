using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AppSlider.WebApi.Model
{
    public class ApiReturnList<T> where T : new()
    {
        [JsonProperty("items")]
        public List<T> Items { get; set; }

        [JsonProperty("message")]
        public ApiReturnMessage ApiReturnMessage { get; set; }

        [JsonProperty("success")]
        public Boolean Success { get; set; }
    }
}