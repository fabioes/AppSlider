using System;

namespace AppSlider.Domain.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Struct, AllowMultiple = true)]
    public class CustomAuthorizeAttribute : Attribute
    {
        public String Role { get; set; }

        public CustomAuthorizeAttribute(String role)
        {
            Role = role;
        }        
    }
}
