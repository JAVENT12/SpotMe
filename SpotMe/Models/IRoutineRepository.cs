﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models
{
    public interface IRoutineRepository
    {
        IQueryable<Routine> Routines { get; }
    }
}
