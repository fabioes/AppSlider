using Newtonsoft.Json;
using System;

namespace AppSlider.Application.PlaylistFile.Messages
{
    public class PlaylistFileCreateRequest
    {
        [JsonProperty("id_playlist")]
        public virtual Guid IdPlayList { get; set; }
        [JsonProperty("business_id")]
        public virtual Guid IdBusiness { get; set; }
        [JsonProperty("business_type")]
        public virtual int IdType { get; set; }
        [JsonProperty("tipo")]
        public virtual string PlayListFileType { get; set; }
        [JsonProperty("tempo_duracao")]
        public virtual short Duration { get; set; }
    }
}
