using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models
{
    public interface IExcerciserRepository
    {
        IQueryable<Excerciser> Excercisers { get; }
        Excerciser DeleteExcerciser(int ID);
    }
}
