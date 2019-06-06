using AppSlider.Application.Category.Commands;
using AppSlider.Application.Category.Results;
using System.Threading.Tasks;

namespace AppSlider.Application.Category.Services.Update
{
    public interface ICategoryUpdateService
    {
        Task<CategoryResult> Process(CategoryUpdateCommand command);
    }
}
