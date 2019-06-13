using AppSlider.Application.Role.Results;
using AppSlider.Application.User.Results;
using AppSlider.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSlider.Application.Role.Services.Get
{
    public class RoleGetService : IRoleGetService
    {
        private readonly IRoleRepository roleRepository;

        public RoleGetService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }
       
        public async Task<List<RoleResult>> GetAll()
        {
            var roles = await roleRepository.GetAll();

            var returnUsers = roles.Select(s => (RoleResult)s).OrderBy(o => o.Name)?.ToList();
            
            return returnUsers;
        }
    }
}
