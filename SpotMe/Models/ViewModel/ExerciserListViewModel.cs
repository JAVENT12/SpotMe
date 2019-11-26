using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models.ViewModel
{
    public class ExerciserListViewModel
    {
        public IEnumerable<Excerciser>  Excercisers{ get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
