using System;

namespace AppSlider.Domain.Entities.Files
{
    public class File: Entity, IAggregateRoot
    {
        public virtual String Name { get; protected set; }
        public virtual Byte[] Data { get; protected set; }
        public virtual String MineType { get; set; }
        public virtual String Size { get; set; }

        public File(Guid id, string name, byte[] data, string mineType, string size): this()
        {
            Id = id;
            Name = name;
            Data = data;
            MineType = mineType;
            Size = size;
        }

        public File(string name, byte[] data, string mineType, string size) : this()
        {
            Name = name;
            Data = data;
            MineType = mineType;
            Size = size;
        }

        public File() { }
    }
}
