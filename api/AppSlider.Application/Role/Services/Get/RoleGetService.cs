using AppSlider.Application.Business.Services.Get;
using AppSlider.Application.Role.Results;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSlider.Application.Role.Services.Get
{
    public class RoleGetService : IRoleGetService
    {
        private readonly IRoleRepository roleRepository;
        private readonly LoggedUser loggedUser;

        public RoleGetService(IRoleRepository roleRepository,[FromServices]LoggedUser loggedUser)
        {
            this.roleRepository = roleRepository;
            this.loggedUser = loggedUser;
        }
       
        public async Task<List<RoleResult>> GetAll()
        {
            var roles = await roleRepository.GetAll();

            var returnRoles = roles.Select(s => (RoleResult)s).OrderBy(o => o.Name)?.ToList();
            
            return returnRoles;
        }

        public async Task<List<RoleResult>> GetForLoggedUser()
        {
            var roles = await roleRepository.GetForLoggedUser(loggedUser);

            var returnRoles = roles.Select(s => (RoleResult)s).OrderBy(o => o.Name)?.ToList();

            return returnRoles;
        }

        public async Task<List<RoleResult>> GetFromUser(LoggedUser user)
        {
            var roles = await roleRepository.GetForLoggedUser(user);

            var returnRoles = roles.Select(s => (RoleResult)s).OrderBy(o => o.Name)?.ToList();

            return returnRoles;
        }
    }
}
