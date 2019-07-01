using System;
using System.Threading.Tasks;

namespace AppSlider.Application.Equipament.Services.Delete
{
    public interface IEquipamentDeleteService
    {
        Task<Boolean> Process(Guid id);
    }
}
