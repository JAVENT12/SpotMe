using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models
{
    public interface IMuscleGroupRepository
    {
        IQueryable<MuscleGroup> MuscleGroups { get; }
        MuscleGroup DeleteMuscle (int muscleGroupID);
    }
}
