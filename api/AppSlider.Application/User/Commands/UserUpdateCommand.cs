using AppSlider.Utils.Cripto;
using System;
using System.Collections.Generic;

namespace AppSlider.Application.User.Commands
{
    public class UserUpdateCommand
    {
        public Guid Id { get; private set; }

        public String Name { get; private set; }

        public String UserName { get; private set; }

        public String Password { get; private set; }

        public String Email { get; private set; }

        public String Profile { get; private set; }

        public Boolean Active { get; private set; }

        public UserUpdateCommand(Guid id, String name, String username, String password, String email, String profile, Boolean active)
        {
            Id = id;
            Name = name;
            UserName = username;
            Password = !String.IsNullOrWhiteSpace(password) ? CriptoManager.CriptoSHA256(password) : "";
            Email = email;
            Profile = profile;
            Active = active;
        }
    }
}
