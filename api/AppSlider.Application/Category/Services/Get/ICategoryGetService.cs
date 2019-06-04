using AppSlider.Application.Category.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Application.Category.Services.Get
{
    public interface ICategoryGetService
    {
        Task<CategoryResult> Get(Guid id);

        Task<CategoryResult> GetByName(String name);

        Task<List<CategoryResult>> GetAll();
    }
}
