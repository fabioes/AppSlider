using System;

namespace AppSlider.Application.User.Commands
{
    public class UserDeleteCommand
    {
        public Guid? Id { get; private set; }
        
        public UserDeleteCommand(Guid? id)
        {
            Id = id;
        }
    }
}
