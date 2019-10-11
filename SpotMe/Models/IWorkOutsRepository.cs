using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models
{
    public interface IWorkOutsRepository
    {
        IQueryable<WorkOuts> WorkOut { get; }

    }
}
