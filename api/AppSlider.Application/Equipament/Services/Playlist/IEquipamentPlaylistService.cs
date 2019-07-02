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

            if (equipamentPlaylist?.PlayList?.PLayListFiles.Any() != true)
                throw new Exception("Playlist do equipamento não possui itens");

            var midiaFoneUtilitiesPlaylist = await playlistRepository.GetMidiaFoneUtilitiesPlaylist();

            if (midiaFoneUtilitiesPlaylist?.PLayListFiles?.Any() != true)
            {
                var randomMidiaFonePlaylistItemsUsed = new List<PlayListFile>();
                var countRandom = 0;
                var returnPlaylistItems = new List<PlayListFile>();
                var originalEquipamentPlaylistItems = equipamentPlaylist.PlayList.PLayListFiles.ToList();


                for (var i = 0; i < originalEquipamentPlaylistItems.Count(); i++)
                {
                    returnPlaylistItems.Add(originalEquipamentPlaylistItems[i]);

                    if ((countRandom % 5) == 0)
                    {
                        var randomMidiaFonePlaylistItem = midiaFoneUtilitiesPlaylist.PLayListFiles.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                        while (randomMidiaFonePlaylistItemsUsed.Any(a => a.Id == randomMidiaFonePlaylistItem.Id))
                        {
                            randomMidiaFonePlaylistItem = midiaFoneUtilitiesPlaylist.PLayListFiles.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                        }

                        randomMidiaFonePlaylistItemsUsed.Add(randomMidiaFonePlaylistItem);
                        returnPlaylistItems.Add(randomMidiaFonePlaylistItem);
                    }
                    countRandom++;
                }

                equipamentPlaylist.PlayList.PLayListFiles = returnPlaylistItems;
            }
            
            return (PlaylistResult)equipamentPlaylist.PlayList; 
        }
    }
}
