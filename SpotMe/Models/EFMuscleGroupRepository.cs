using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models
{
    public class EFMuscleGroupRepository : IMuscleGroupRepository
    {
        private AppMuscleDbContext context;

        public EFMuscleGroupRepository(AppMuscleDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<MuscleGroup> MuscleGroups => context.MuscleGroup;

        public MuscleGroup DeleteMuscle(int muscleGroupID)
        {
            MuscleGroup dbEntry = context.MuscleGroup
            .FirstOrDefault(p => p.muscleGroupID == muscleGroupID);
            if (dbEntry != null)
            {
                context.MuscleGroup.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}

