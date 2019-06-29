using AppSlider.Application.File.Results;
using AppSlider.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace AppSlider.Application.File.Services
{
    public interface IFileGetService
    {
        Task<FileResult> Process(Guid id);
    }

    public class FileGetService : IFileGetService    {

        private readonly IFileRepository fileRepository;

        public FileGetService(IFileRepository fileRepository)
        {
            this.fileRepository = fileRepository;
        }

        public async Task<FileResult> Process(Guid id)
        {
            var file = await fileRepository.Get(id);

            var returnFile = (FileResult)file;

            return returnFile;
        }
    }
}
