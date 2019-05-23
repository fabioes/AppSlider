namespace AppSlider.Domain.Repositories
{
    using AppSlider.Domain.Users;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserRepository
    {
        Task<User> Get(Guid id);
        Task<ICollection<User>> GetAll();
        Task<User> GetByUsername(String username);
        Task<User> Add(User user);
        Task<User> Update(User user);
        Task<Boolean> Delete(User id);
        void DetachUser(User user);
    }
}
