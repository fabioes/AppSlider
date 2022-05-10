namespace AppSlider.Infrastructure.EntityFrameworkDataAccess
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using AppSlider.Domain.Repositories;
    using AppSlider.Domain.Entities.Files;
    using AppSlider.Infrastructure.DataAccess;

    public class FileRepository : IFileRepository
    {
        private readonly Context _context;

        public FileRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<File> Add(File file)
        {
            await _context.Files.AddAsync(file);
            await _context.SaveChangesAsync();

            return file;
        }

        public async Task<bool> Delete(File file)
        {
            _context.Files.Remove(file);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<File> Get(Guid id)
        {
            var file = await _context.Files.FindAsync(id);

            return file;
        }

    }
}
