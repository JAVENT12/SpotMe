using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models
{
    public class EFWorkOutsRepository : IWorkOutsRepository
    {
        private AppMuscleDbContext context;

        public EFWorkOutsRepository(AppMuscleDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<WorkOuts> WorkOut => context.WorkOuts;
    }
}
