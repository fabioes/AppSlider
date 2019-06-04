using System;

namespace AppSlider.Application.TypeBusiness.Commands
{
    public class TypeBusinessCreateCommand
    {
        public String Name { get; private set; }

        public String Description { get; private set; }

        public TypeBusinessCreateCommand(String name, String description)
        {
            Name = name;
            Description = description;            
        }
    }
}
