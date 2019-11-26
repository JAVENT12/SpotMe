using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Models;

namespace Identity.Models.ViewModel
{
    public class AppUserListViewModel
    {
        public IEnumerable<AppUser> AppUsers { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
