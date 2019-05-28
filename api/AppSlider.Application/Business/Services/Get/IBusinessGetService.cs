using AppSlider.Application.Business.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Application.Business.Services.Get
{
    public interface IBusinessGetService
    {
        Task<BusinessResult> Get(Guid id);

        Task<List<BusinessResult>> GetAll();
    }
}
