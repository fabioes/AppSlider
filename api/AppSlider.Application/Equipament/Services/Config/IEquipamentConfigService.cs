using AppSlider.Application.Equipament.Results;
using System;
using System.Threading.Tasks;

namespace AppSlider.Application.Equipament.Services.Config
{
    public interface IEquipamentConfigService
    {
        Task<EquipamentResult> SwitchActive(Guid id);
                
    }
}
