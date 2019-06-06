using AppSlider.Application.TypeBusiness.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Application.TypeBusiness.Services.Get
{
    public interface ITypeBusinessGetService
    {
        Task<TypeBusinessResult> Get(Guid id);

        Task<TypeBusinessResult> GetByName(String name);

        Task<List<TypeBusinessResult>> GetAll();
    }
}
