using System;

namespace AppSlider.Application.Category.Commands
{
    public class CategoryUpdateCommand
    {
        public int Id { get; private set; }

        public String Name { get; private set; }

        public String Description { get; private set; }

        public CategoryUpdateCommand(int id, String name, String description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
