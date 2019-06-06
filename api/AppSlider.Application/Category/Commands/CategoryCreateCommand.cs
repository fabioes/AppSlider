using System;

namespace AppSlider.Application.Category.Commands
{
    public class CategoryCreateCommand
    {
        public String Name { get; private set; }

        public String Description { get; private set; }

        public CategoryCreateCommand(String name, String description)
        {
            Name = name;
            Description = description;            
        }
    }
}
