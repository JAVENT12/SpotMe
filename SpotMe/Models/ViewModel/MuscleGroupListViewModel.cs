using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models.ViewModel
{
    public class MuscleGroupListViewModel
    {
        public IEnumerable<MuscleGroup> MuscleGroups { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
