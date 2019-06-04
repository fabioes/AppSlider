using System;

namespace AppSlider.Application.Category.Commands
{
    public class CategoryUpdateCommand
    {
        public Guid Id { get; private set; }

        public String Name { get; private set; }

        public String Description { get; private set; }

        public CategoryUpdateCommand(Guid id, String name, String description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
