using AppSlider.Application.Business.Commands;
using AppSlider.Application.Business.Results;
using System.Threading.Tasks;

namespace AppSlider.Application.Business.Services.Create
{
    public interface IBusinessCreateService
    {
        Task<BusinessResult> Process(BusinessCreateCommand command);
    }
}
