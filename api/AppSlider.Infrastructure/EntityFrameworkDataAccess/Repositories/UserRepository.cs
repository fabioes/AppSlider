namespace AppSlider.Infrastructure.EntityFrameworkDataAccess
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using AppSlider.Domain.Repositories;
    using AppSlider.Domain.Entities.Users;
    using System.Linq;
    using AppSlider.Infrastructure.DataAccess;

    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> Delete(User user)
        {
            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<User> Get(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            return user;
        }

        public async Task<ICollection<User>> GetAll()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        public async Task<User> GetByUsername(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(f => f.Username == username);
            return user;
        }

        public async Task<User> Update(User user)
        {

            if (user.Password == null)
            {
                var actualUser = await _context.Users.FindAsync(user.Id);
                user.SetPassword(actualUser?.Password);
                var local = _context.Set<User>().Local.FirstOrDefault(e => e.Id == user.Id);

                if (local == null) local = user;

                _context.Entry(local).State = local == null ? EntityState.Modified : EntityState.Detached;
            }

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public void DetachUser(User user)
        {
            _context.Entry(user).State = EntityState.Detached;
        }
    }
}
