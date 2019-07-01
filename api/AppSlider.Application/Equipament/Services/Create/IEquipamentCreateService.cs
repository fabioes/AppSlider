using AppSlider.Application.Equipament.Commands;
using AppSlider.Application.Equipament.Results;
using System.Threading.Tasks;

namespace AppSlider.Application.Equipament.Services.Create
{
    public interface IEquipamentCreateService
    {
        Task<EquipamentResult> Process(EquipamentCreateCommand command);
    }
}
