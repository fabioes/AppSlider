using AppSlider.Utils.Cripto;
using System;
using System.Collections.Generic;

namespace AppSlider.Application.User.Commands
{
    public class UserCreateCommand
    {
        public String Name { get; private set; }

        public String UserName { get; private set; }

        public String Password { get; private set; }

        public String Email { get; private set; }

        public String Profile { get; private set; }

        public List<String> Franchises { get; private set; }

        public List<String> Roles { get; private set; }

        public Boolean Active { get; private set; }

        public UserCreateCommand(String name, String username, String password, String email, String profile, List<String> franchises, List<String> roles, Boolean active)
        {
            Name = name;
            UserName = username;
            Password = !String.IsNullOrWhiteSpace(password) ? CriptoManager.CriptoSHA256(password) : "";
            Email = email;
            Profile = profile;
            Franchises = franchises;
            Roles = roles;
            Active = active;
        }
    }
}
