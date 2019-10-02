using System;
using AppSlider.Application.Business.Results;
using Newtonsoft.Json;

namespace AppSlider.Application.Equipament.Results
{
    public class EquipamentResult
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("nome")]
        public String Name { get; set; }

        [JsonProperty("descricao")]
        public String Description { get; set; }

        [JsonProperty("mac_address")]
        public String MacAddress { get; set; }

        [JsonProperty("id_franquia")]
        public Guid IdFranchise { get; set; }

        [JsonProperty("id_estabelecimento")]
        public Guid? IdEstablishment { get; set; }

        [JsonProperty("id_playlist")]
        public Guid? IdPlaylist { get; set; }

        [JsonProperty("establishment")]    
        BusinessResult Establishment {get;set;}

        [JsonProperty("ativo")]
        public Boolean Active { get; set; }

        public static explicit operator EquipamentResult(Domain.Entities.Equipaments.Equipament equipament)
        {
            return equipament == null ? null :
                new EquipamentResult
                {
                    Active = equipament.Active,
                    Description = equipament.Description,
                    Id = equipament.Id,
                    IdEstablishment = equipament.IdEstablishment,
                    Establishment = (BusinessResult)equipament.Establishment,
                    IdFranchise = equipament.IdFranchise,
                    IdPlaylist = equipament.IdPlaylist,
                    MacAddress = equipament.MacAddress,
                    Name = equipament.Name
                };
        }

        public static explicit operator Domain.Entities.Equipaments.Equipament(EquipamentResult equipament)
        {
            return equipament == null ? null :
                new Domain.Entities.Equipaments.Equipament
                {
                    Active = equipament.Active,
                    Description = equipament.Description,
                    Id = equipament.Id,
                    IdEstablishment = equipament.IdEstablishment,
                    IdFranchise = equipament.IdFranchise,
                    IdPlaylist = equipament.IdPlaylist,
                    MacAddress = equipament.MacAddress,
                    Name = equipament.Name
                };
        }
    }
}