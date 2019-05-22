using AppSlider.Domain.Contracts;
using AppSlider.Domain.Roles;
using System;
using System.Collections.Generic;

namespace AppSlider.Domain.Users
{
    public class User : Entity, IAggregateRoot
    {
        public virtual String Name { get; protected set; }
        public virtual String Username { get; protected set; }
        public virtual String Password { get; protected set; }
        public virtual String Profile { get; protected set; }
        public virtual String Email { get; protected set; }
        public virtual Boolean Active { get; protected set; }

        public User(String name, String username, String password, String profile, String email, Boolean active)
            : this()
        {
            Name = name;
            Username = username;
            Password = password;
            Profile = profile;
            Email = email;
            Active = active;
        }

        public User(Guid id, String name, String username, String password, String profile, String email, Boolean active)
            : this()
        {
            Id = id;
            Name = name;
            Username = username;
            Password = password;
            Profile = profile;
            Email = email;
            Active = active;
        }

        public User(Guid id, String name, String username, String profile, String email, Boolean active)
            : this()
        {
            Id = id;
            Name = name;
            Username = username;
            Password = null;
            Profile = profile;
            Email = email;
            Active = active;
        }

        public void SetPassword(string password)
        {
            Password = password;
        }

        public User()
        {
        }
    }
}
