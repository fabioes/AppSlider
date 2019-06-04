using AppSlider.Application.TypeBusiness.Commands;
using AppSlider.Application.TypeBusiness.Results;
using System.Threading.Tasks;

namespace AppSlider.Application.TypeBusiness.Services.Create
{
    public interface ITypeBusinessCreateService
    {
        Task<TypeBusinessResult> Process(TypeBusinessCreateCommand command);
    }
}
