using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models
{
      public  interface IAppUserRepository
      {
        IQueryable<AppUser> AppUsers { get; set; }
      }
}
