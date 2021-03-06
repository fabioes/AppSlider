using System;

namespace AppSlider.Application.TypeBusiness.Commands
{
    public class TypeBusinessUpdateCommand
    {
        public int Id { get; private set; }

        public String Name { get; private set; }

        public String Description { get; private set; }

        public TypeBusinessUpdateCommand(int id, String name, String description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
