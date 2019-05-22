using AppSlider.Application.User.Commands;
using AppSlider.Application.User.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Application.User.Services.Get
{
    public interface IUserGetService
    {
        Task<UserResult> Get(UserGetCommand command);

        Task<List<UserResult>> GetAll();
    }
}
