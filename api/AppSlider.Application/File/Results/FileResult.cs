using System;

namespace AppSlider.Application.File.Results
{
    public class FileResult
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public Byte[] Data { get; set; }
        public String ContentType { get; set; }
        public Int64 Size { get; set; }

        public static explicit operator FileResult(Domain.Entities.Files.File file)
        {
            return file == null ? null : new FileResult
            {
                ContentType = file.MineType,
                Data = file.Data,
                Id = file.Id,
                Name = file.Name,
                Size = file.Size
            };
        }
    }
}