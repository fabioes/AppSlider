using AppSlider.Application.Role.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Application.Role.Services.Get
{
    public interface IRoleGetService
    {
        Task<List<RoleResult>> GetAll();
    }
}
