using AppSlider.Application.Playlist.Results;
using AppSlider.Domain.Repositories;
using System;
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

            var advertisers = await businessRepository.GetAdvertisers(equipamentPlaylist.Id);
            int i = 0;
            while (playlist.PlaylistFiles.Count <= 60)
            {
                Guid Id;

                foreach (var advertiser in advertisers)
                {

                    if (advertiser.Id == Id)
                        break;

                    if (i % 7 == 0 && i > 0)
                    {
                        var establishmentFile = equipamentPlaylist.Establishment.Playlists.FirstOrDefault()?.PlaylistFiles.OrderBy(r => Guid.NewGuid()).Take(1).FirstOrDefault();
                        var curiosity = curiosities.Playlists.FirstOrDefault()?.PlaylistFiles.OrderBy(r => Guid.NewGuid()).Take(1).FirstOrDefault();
                        var ad = midiafone.Playlists.FirstOrDefault()?.PlaylistFiles.OrderBy(r => Guid.NewGuid()).Take(1).FirstOrDefault();
                        if (establishmentFile != null)
                            playlist.PlaylistFiles.Add(establishmentFile);
                        if (curiosity != null)
                            playlist.PlaylistFiles.Add(curiosity);
                        if (ad != null)
                            playlist.PlaylistFiles.Add(ad);

                    }
                    var files = await playlistRepository.GetByBusiness(advertiser.Id);

                    

                    if (files?.PlaylistFiles != null)
                    {
                        foreach (var file in files.PlaylistFiles)
                        {
                            if (file != null)
                                playlist.PlaylistFiles.Add(file);
                        }
                        i++;
                    }
                    Id = advertiser.Id;

                }
            }
            playlist.PlaylistFiles = playlist.PlaylistFiles.Where((value, index) => index < 60).ToList();
            return (PlaylistResult)playlist;

        }
    }
}
