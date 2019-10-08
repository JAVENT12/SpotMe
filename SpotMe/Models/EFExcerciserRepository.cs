using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models
{
    public class EFExcerciserRepository : IExcerciserRepository
    {
        private ApplicationDbContext context;

        public EFExcerciserRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Excerciser> Excercisers => context.Excerciser;
        public Excerciser DeleteExcerciser(int ID)
        {
            Excerciser dbEntry = context.Excerciser
            .FirstOrDefault(p => p.ID == ID);
            if (dbEntry != null)
            {
                context.Excerciser.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
