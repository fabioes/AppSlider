using AppSlider.Application.User.Commands;
using AppSlider.Application.User.Results;
using System.Threading.Tasks;

namespace AppSlider.Application.User.Services.Update
{
    public interface IUserUpdateService
    {
        Task<UserResult> Process(UserUpdateCommand command);
    }
}
