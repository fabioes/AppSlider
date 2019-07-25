using System;

namespace AppSlider.Domain.Entities.Files
{
    public class File: Entity<Guid>, IAggregateRoot
    {
        public virtual string Name { get; protected set; }
        public virtual byte[] Data { get; protected set; }
        public virtual string MineType { get; set; }
        public virtual long Size { get; set; }

        public File(Guid id, string name, byte[] data, string mineType, long size): this()
        {
            Id = id;
            Name = name;
            Data = data;
            MineType = mineType;
            Size = size;
        }

        public File(string name, byte[] data, string mineType, long size) : this()
        {
            Name = name;
            Data = data;
            MineType = mineType;
            Size = size;
        }

        public File() { }
    }
}
