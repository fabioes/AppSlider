using Newtonsoft.Json;
using System;

namespace AppSlider.Application.PlaylistFile.Messages
{
    public class PlaylistFileCreateRequest
    {
        [JsonProperty("id_playlist")]
        public virtual Guid IdPlayList { get; set; }

        [JsonProperty("tipo")]
        public virtual String PlayListFileType { get; set; }

        [JsonProperty("tempo_duracao")]
        public virtual Int16 Duration { get; set; }
    }
}
