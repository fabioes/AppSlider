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
        private readonly IBusinessRepository businessRepository;

        public EquipamentPlaylistService(IPlaylistRepository playlistRepository, IEquipamentRepository equipamentRepository, IBusinessRepository businessRepository)
        {
            this.playlistRepository = playlistRepository;
            this.equipamentRepository = equipamentRepository;
            this.businessRepository = businessRepository;
        }

        public async Task<PlaylistResult> Process(String macAddress)
        {
            if (String.IsNullOrWhiteSpace(macAddress))
                throw new Exception("Favor informar o Mac Address de um Equipamento válido");

            var equipamentPlaylist = await equipamentRepository.GetByMacAddress(macAddress);
            if (equipamentPlaylist == null)
                throw new Exception("Favor informar o Mac Address de um Equipamento válido");
            var playlist = new Domain.Entities.PlayLists.Playlist();
            var curiosities = (await businessRepository.GetByType("Curiosidades")).FirstOrDefault();
            var midiafone = (await businessRepository.GetByType("Midiafone")).FirstOrDefault();
            for (int i = 1; i < 60; i++)
            {
                int j = 1;
                Guid Id;
                while (j < 7)
                {
                    
                    var advertisers = await businessRepository.GetAdvertisers(equipamentPlaylist.Id);
                    
                    foreach (var advertiser in advertisers)
                    {
                        if (Id == advertiser.Id)
                        {
                            break;
                        }
                        var files = await playlistRepository.GetByBusiness(advertiser.Id);
                       
                         Id = advertiser.Id;

                        if (files.PlaylistFiles != null)
                        {
                            foreach (var file in files.PlaylistFiles)
                            {
                                playlist.PlaylistFiles.Add(file);
                            }
                        }
                    }
                    j++;
                }
                j = 0;
                var establishmentFile = equipamentPlaylist.Establishment.Playlists.FirstOrDefault().PlaylistFiles.OrderBy(r => Guid.NewGuid()).Take(1).FirstOrDefault();
                var curiosity = curiosities.Playlists.FirstOrDefault().PlaylistFiles.OrderBy(r => Guid.NewGuid()).Take(1).FirstOrDefault();
                var ad = midiafone.Playlists.FirstOrDefault().PlaylistFiles.OrderBy(r => Guid.NewGuid()).Take(1).FirstOrDefault();

                playlist.PlaylistFiles.Add(establishmentFile);
                playlist.PlaylistFiles.Add(curiosity);
                playlist.PlaylistFiles.Add(ad);
                if (playlist.PlaylistFiles.Count >= 60)
                    break;
            }

                                   
            //foreach (var file in curiosities.Playlists.FirstOrDefault().PlaylistFiles)
            //{
            //    playlist.PlaylistFiles.Add(file);
            //}
            //foreach (var file in midiafone.Playlists.FirstOrDefault().PlaylistFiles)
            //{
            //    playlist.PlaylistFiles.Add(file);
            //}






            //if (equipamentPlaylist?.PlayList?.PlaylistFiles.Any() != true)
            //    throw new Exception("Playlist do equipamento não possui itens");

            //var midiaFoneUtilitiesPlaylist = await playlistRepository.GetMidiaFoneUtilitiesPlaylist();

            //if (midiaFoneUtilitiesPlaylist?.PlaylistFiles?.Any() == true)
            //{
            //    //make random order
            //    var randomMidiaFoneOrdened = midiaFoneUtilitiesPlaylist.PlaylistFiles.OrderBy(x => Guid.NewGuid()).ToList(); // new List<PlayListFile>();

            //    //return playlist instance.
            //    var returnPlaylistItems = new List<Domain.Entities.PlayLists.PlaylistFile>();

            //    //group original equipament playlist (chunk) for every 5 items.
            //    var chunckedEquipamentPlaylistItems = new List<List<Domain.Entities.PlayLists.PlaylistFile>>();
            //    var originalEquipamentPlaylistItems = equipamentPlaylist.PlayList.PlaylistFiles.ToList();

            //    for (int i = 0; i < originalEquipamentPlaylistItems.Count; i += 5)
            //    {
            //        chunckedEquipamentPlaylistItems.Add(originalEquipamentPlaylistItems.GetRange(i, Math.Min(5, originalEquipamentPlaylistItems.Count - i)));
            //    }
            //    //

            //    if (randomMidiaFoneOrdened.Count > chunckedEquipamentPlaylistItems.Count)
            //    {
            //        var playlistIteratorCount = 0;
            //        foreach (var item in randomMidiaFoneOrdened)
            //        {
            //            returnPlaylistItems.AddRange(chunckedEquipamentPlaylistItems[playlistIteratorCount]);
            //            returnPlaylistItems.Add(item);

            //            playlistIteratorCount = (playlistIteratorCount + 1) < chunckedEquipamentPlaylistItems.Count
            //                                  ? playlistIteratorCount + 1 : 0;
            //        }
            //    }
            //    else
            //    {
            //        var playlistIteratorCount = 0;
            //        foreach (var item in chunckedEquipamentPlaylistItems)
            //        {
            //            returnPlaylistItems.AddRange(item);
            //            returnPlaylistItems.Add(randomMidiaFoneOrdened[playlistIteratorCount]);

            //            playlistIteratorCount = (playlistIteratorCount + 1) < randomMidiaFoneOrdened.Count
            //                                  ? playlistIteratorCount + 1 : 0;
            //        }
            //    }
            //    equipamentPlaylist.PlayList.PlaylistFiles = returnPlaylistItems;
            //}

            return (PlaylistResult)playlist;
        }
    }
}
