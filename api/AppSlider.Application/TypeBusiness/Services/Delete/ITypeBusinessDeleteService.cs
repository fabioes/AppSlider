using System;
using System.Threading.Tasks;

namespace AppSlider.Application.TypeBusiness.Services.Delete
{
    public interface ITypeBusinessDeleteService
    {
        Task<Boolean> Process(Guid id);
    }
}
