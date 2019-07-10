using AppSlider.Application.Playlist.Results;
using AppSlider.Domain.Entities.PlayLists;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSlider.Application.Equipament.Services.Playlist
{
    public interface IEquipamentPlaylistService
    {
        Task<PlaylistResult> Process(String macAddress);
    }

    public class EquipamentPlaylistService : IEquipamentPlaylistService
    {
        private readonly IPlaylistRepository playlistRepository;
        private readonly IEquipamentRepository equipamentRepository;

        public EquipamentPlaylistService(IPlaylistRepository playlistRepository, IEquipamentRepository equipamentRepository)
        {
            this.playlistRepository = playlistRepository;
            this.equipamentRepository = equipamentRepository;
        }

        public async Task<PlaylistResult> Process(String macAddress)
        {
            if (String.IsNullOrWhiteSpace(macAddress))
                throw new Exception("Favor informar o Mac Address de um Equipamento válido");

            var equipamentPlaylist = await equipamentRepository.GetByMacAddress(macAddress);
            if (equipamentPlaylist == null)
                throw new Exception("Favor informar o Mac Address de um Equipamento válido");

            if (equipamentPlaylist?.PlayList?.PlaylistFiles.Any() != true)
                throw new Exception("Playlist do equipamento não possui itens");

            var midiaFoneUtilitiesPlaylist = await playlistRepository.GetMidiaFoneUtilitiesPlaylist();

            if (midiaFoneUtilitiesPlaylist?.PlaylistFiles?.Any() == true)
            {
                //make random order
                var randomMidiaFoneOrdened = midiaFoneUtilitiesPlaylist.PlaylistFiles.OrderBy(x => Guid.NewGuid()).ToList(); // new List<PlayListFile>();

                //return playlist instance.
                var returnPlaylistItems = new List<Domain.Entities.PlayLists.PlaylistFile>();

                //group original equipament playlist (chunk) for every 5 items.
                var chunckedEquipamentPlaylistItems = new List<List<Domain.Entities.PlayLists.PlaylistFile>>();
                var originalEquipamentPlaylistItems = equipamentPlaylist.PlayList.PlaylistFiles.ToList();

                for (int i = 0; i < originalEquipamentPlaylistItems.Count; i += 5)
                {
                    chunckedEquipamentPlaylistItems.Add(originalEquipamentPlaylistItems.GetRange(i, Math.Min(5, originalEquipamentPlaylistItems.Count - i)));
                }
                //

                if (randomMidiaFoneOrdened.Count > chunckedEquipamentPlaylistItems.Count)
                {
                    var playlistIteratorCount = 0;
                    foreach (var item in randomMidiaFoneOrdened)
                    {
                        returnPlaylistItems.AddRange(chunckedEquipamentPlaylistItems[playlistIteratorCount]);
                        returnPlaylistItems.Add(item);

                        playlistIteratorCount = (playlistIteratorCount + 1) < chunckedEquipamentPlaylistItems.Count
                                              ? playlistIteratorCount + 1 : 0;
                    }
                }
                else
                {
                    var playlistIteratorCount = 0;
                    foreach (var item in chunckedEquipamentPlaylistItems)
                    {
                        returnPlaylistItems.AddRange(item);
                        returnPlaylistItems.Add(randomMidiaFoneOrdened[playlistIteratorCount]);

                        playlistIteratorCount = (playlistIteratorCount + 1) < randomMidiaFoneOrdened.Count
                                              ? playlistIteratorCount + 1 : 0;
                    }
                }
                equipamentPlaylist.PlayList.PlaylistFiles = returnPlaylistItems;
            }

            return (PlaylistResult)equipamentPlaylist.PlayList;
        }
    }
}
