namespace AppSlider.Infrastructure.EntityFrameworkDataAccess
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using AppSlider.Domain.Repositories;
    using AppSlider.Domain.Entities.Roles;

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
    }
}
