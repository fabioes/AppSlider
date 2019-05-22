using System.Threading.Tasks;
using AppSlider.Application.Login.Messages;
using AppSlider.Application.User.Results;

namespace AppSlider.Application.Login.Services
{
    public interface ILoginService
    {
        Task<UserResult> Process(LoginRequest command);
    }
}
