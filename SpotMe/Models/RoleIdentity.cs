using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models
{
    public class RoleIdentity : IdentityRole
    {
        //Exists to inherit
        public RoleIdentity(string roleName) : base(roleName)
        {
        }

        public bool Succeeded { get; internal set; }

        public static implicit operator RoleIdentity(IdentityResult v)
        {
            throw new NotImplementedException();
        }
    }
}
