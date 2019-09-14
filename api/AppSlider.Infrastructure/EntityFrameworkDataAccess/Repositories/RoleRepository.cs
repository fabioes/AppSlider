namespace AppSlider.Infrastructure.EntityFrameworkDataAccess
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using AppSlider.Domain.Repositories;
    using AppSlider.Domain.Entities.Roles;
    using AppSlider.Domain.Entities.Users;
    using System.Linq;
    using AppSlider.Domain.Authentication;

    public class RoleRepository : IRoleRepository
    {
        private readonly Context _context;

        public RoleRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
       
        public async Task<ICollection<Role>> GetAll()
        {
            var roles = await _context.Roles.ToListAsync();

            return roles;
        }

        public async Task<ICollection<Role>> GetForLoggedUser(LoggedUser loggedUser)
        {
            var ids = loggedUser.Roles?.Select(s => Guid.Parse(s))?.ToList();

            var roles = await _context.Roles.Where(w => loggedUser.Profile == "sa" || w.Name == "AppSlider.Read.Business").ToListAsync();

            return roles;
        }
    }
}
