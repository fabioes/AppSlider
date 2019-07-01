using AppSlider.Application.Equipament.Commands;
using AppSlider.Application.Equipament.Results;
using System.Threading.Tasks;

namespace AppSlider.Application.Equipament.Services.Update
{
    public interface IEquipamentUpdateService
    {
        Task<EquipamentResult> Process(EquipamentUpdateCommand command);
    }
}
