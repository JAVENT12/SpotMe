using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotMe_.Models
{
    public interface IExcerciserRepository
    {
        IQueryable<Excerciser> Excercisers { get; }
    }
}
