using AppSlider.Application.Business.Results;
using System;
using System.Threading.Tasks;

namespace AppSlider.Application.Business.Services.Config
{
    public interface IBusinessConfigService
    {
        Task<BusinessResult> SwitchActive(Guid id);
                
    }
}
