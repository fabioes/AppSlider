using System;

namespace AppSlider.Domain.Entities.Users
{
    public class User : Entity<Guid>, IAggregateRoot
    {
        public virtual string Name { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Profile { get; set; }
        public virtual string Franchises { get; set; }
        public virtual string Roles { get; set; }
        public virtual string Email { get; set; }
        public virtual bool Active { get; set; }
        public virtual bool Blocked { get; set; }

        public User(string name, String username, String password, String profile, String email, String franchises, String roles, Boolean active, Boolean blocked)
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

        public User(Guid id, string name, string username, string password, string profile, string email, string franchises, string roles, bool active, bool blocked)
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

        public User(Guid id, string name, string username, string profile, string email, string franchises, string roles, bool active, bool blocked)
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
