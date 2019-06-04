using System;

namespace AppSlider.Application.TypeBusiness.Commands
{
    public class TypeBusinessUpdateCommand
    {
        public Guid Id { get; private set; }

        public String Name { get; private set; }

        public String Description { get; private set; }

        public TypeBusinessUpdateCommand(Guid id, String name, String description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
