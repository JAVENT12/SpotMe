using Identity.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models
{
    public class EFRoutineRepository : IRoutineRepository
    {
        private RoutineDbContext context;

        public EFRoutineRepository(RoutineDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Routine> Routines => context.Routines;

    }
}
