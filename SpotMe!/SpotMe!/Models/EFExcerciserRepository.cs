using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotMe_.Models
{
    public class EFExcerciserRepository : IExcerciserRepository
    {
        private ApplicationDbContext context;

        public EFExcerciserRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Excerciser> Excercisers => context.Excerciser;
    
       
    }
}
