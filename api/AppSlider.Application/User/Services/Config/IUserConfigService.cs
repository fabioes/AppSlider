using AppSlider.Application.User.Commands;
using AppSlider.Application.User.Results;
using System.Threading.Tasks;

namespace AppSlider.Application.User.Services.Config
{
    public interface IUserConfigService
    {
        Task<UserResult> SwitchActive(UserConfigCommand command);

        Task<UserResult> ResetPassword(UserConfigCommand command);
    }
}
