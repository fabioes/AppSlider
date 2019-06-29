using AppSlider.Application.Role.Results;
using AppSlider.Domain.Authentication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Application.Role.Services.Get
{
    public interface IRoleGetService
    {
        Task<List<RoleResult>> GetAll();

        Task<List<RoleResult>> GetForLoggedUser();

        Task<List<RoleResult>> GetFromUser(LoggedUser user);
    }
}
