using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IToversite.Models
{
    public class UserLogin
    {

        public int UserId { get; set; }

        public string Username { get; set; }

        public string UserRole { get; set; }

        public int RoleId { get; set; }

        public string Password { get; set; }


        public string Email { get; set; }



    }
}