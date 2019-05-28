using AppSlider.Application.Business.Commands;
using AppSlider.Application.Business.Results;
using System.Threading.Tasks;

namespace AppSlider.Application.Business.Services.Update
{
    public interface IBusinessUpdateService
    {
        Task<BusinessResult> Process(BusinessUpdateRequestCommand command);
    }
}
