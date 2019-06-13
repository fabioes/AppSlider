namespace AppSlider.Domain.Repositories
{
    using AppSlider.Domain.Entities.Roles;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRoleRepository
    {
        Task<ICollection<Role>> GetAll();     
    }
}
