using System;
using Newtonsoft.Json;

namespace AppSlider.WebApi.Model
{
    public class ApiReturnItem<T> where T : new()
    {
        [JsonProperty("item")]
        public T Item { get; set; }

        [JsonProperty("message")]
        public ApiReturnMessage ApiReturnMessage { get; set; }

        [JsonProperty("success")]
        public Boolean Success { get; set; }
    }
}