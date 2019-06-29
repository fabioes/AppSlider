using System;
using System.Collections.Generic;
using System.Text;

namespace AppSlider.Domain.Authentication
{
    public class LoggedUser
    {
        public Guid Id { get; set; }
        public String UserName { get; set; }
        public String Login { get; set; }
        public String Profile { get; set; }
        public List<String> Roles { get; set; }
        public List<String> Franchises { get; set; }
    }
}
