using AppSlider.Utils.Cripto;
using System;

namespace AppSlider.Application.User.Commands
{
    public class UserConfigCommand
    {
        public Guid Id { get; private set; }

        public String Password { get; private set; }

        public UserConfigCommand(Guid id, String password = null)
        {
            Id = id;
            Password = !String.IsNullOrWhiteSpace(password) ? CriptoManager.CriptoSHA256(password) : "";
        }
    }
}
