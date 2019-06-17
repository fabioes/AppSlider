﻿using System;

namespace AppSlider.Domain.Entities.Users
{
    public class User : Entity, IAggregateRoot
    {
        public virtual String Name { get; protected set; }
        public virtual String Username { get; protected set; }
        public virtual String Password { get; protected set; }
        public virtual String Profile { get; protected set; }
        public virtual String Franchises { get; protected set; }
        public virtual String Roles { get; protected set; }
        public virtual String Email { get; protected set; }
        public virtual Boolean Active { get; protected set; }
        public virtual Boolean Blocked { get; protected set; }

        public User(String name, String username, String password, String profile, String email, String franchises, String roles, Boolean active, Boolean blocked)
            : this()
        {
            Name = name;
            Username = username;
            Password = password;
            Profile = profile;
            Email = email;
            Franchises = franchises;
            Roles = roles;
            Active = active;
            Blocked = blocked;
        }

        public User(Guid id, String name, String username, String password, String profile, String email, String franchises, String roles, Boolean active, Boolean blocked)
            : this()
        {
            Id = id;
            Name = name;
            Username = username;
            Password = password;
            Profile = profile;
            Email = email;
            Franchises = franchises;
            Roles = roles;
            Active = active;
            Blocked = blocked;
        }

        public User(Guid id, String name, String username, String profile, String email, String franchises, String roles, Boolean active, Boolean blocked)
            : this()
        {
            Id = id;
            Name = name;
            Username = username;
            Password = null;
            Profile = profile;
            Email = email;
            Franchises = franchises;
            Roles = roles;
            Active = active;
            Blocked = blocked;
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
