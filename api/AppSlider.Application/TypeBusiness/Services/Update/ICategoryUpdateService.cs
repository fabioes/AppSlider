using AppSlider.Application.TypeBusiness.Commands;
using AppSlider.Application.TypeBusiness.Results;
using System.Threading.Tasks;

namespace AppSlider.Application.TypeBusiness.Services.Update
{
    public interface ITypeBusinessUpdateService
    {
        Task<TypeBusinessResult> Process(TypeBusinessUpdateCommand command);
    }
}
