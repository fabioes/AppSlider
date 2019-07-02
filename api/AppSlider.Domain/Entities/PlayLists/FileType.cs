using System.ComponentModel;

namespace AppSlider.Domain.Entities.PlayLists
{
    public enum PlaylistFileType
    {
        [Description("imagem")]
        Image = 1,
        [Description("video")]
        Video = 2
    }
}
