using System;
using System.Threading.Tasks;

namespace AppSlider.Application.Category.Services.Delete
{
    public interface ICategoryDeleteService
    {
        Task<Boolean> Process(int id);
    }
}
