namespace AppSlider.Domain.Repositories
{
    using AppSlider.Domain.Entities.Files;
    using System;
    using System.Threading.Tasks;

    public interface IFileRepository
    {
        Task<File> Get(Guid id);
        Task<File> Add(File file);
        Task<Boolean> Delete(File file);        
    }
}
