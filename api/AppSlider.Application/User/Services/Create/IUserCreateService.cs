using System.Threading.Tasks;
using AppSlider.Application.User.Commands;
using AppSlider.Application.User.Results;

namespace AppSlider.Application.User.Services.Create
{
    public interface IUserCreateService
    {
        Task<UserResult> Process(UserCreateCommand command);
    }
}
