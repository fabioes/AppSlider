using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace AppSlider.Domain.Authentication
{
    public class SigningConfigurations
    {
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public SigningConfigurations(String key)
        {
            Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}