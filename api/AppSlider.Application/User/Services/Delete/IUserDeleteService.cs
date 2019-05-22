using AppSlider.Application.User.Commands;
using System;
using System.Threading.Tasks;

namespace AppSlider.Application.User.Services.Delete
{
    public interface IUserDeleteService
    {
        Task<Boolean> Process(UserDeleteCommand command);
    }
}
