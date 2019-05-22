using System;

namespace AppSlider.Application.User.Commands
{
    public class UserGetCommand
    {
        public Guid Id { get; private set; }

        public UserGetCommand(Guid id)
        {
            Id = id;
        }
       
    }
}
