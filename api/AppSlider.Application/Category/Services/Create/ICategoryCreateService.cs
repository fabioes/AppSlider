using AppSlider.Application.Category.Commands;
using AppSlider.Application.Category.Results;
using System.Threading.Tasks;

namespace AppSlider.Application.Category.Services.Create
{
    public interface ICategoryCreateService
    {
        Task<CategoryResult> Process(CategoryCreateCommand command);
    }
}
