using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Models
{
    public class MuscleGroup
    {
        [Key]
        public int muscleGroupID { get; set; }
        [Key]
        [ForeignKey("WorkOuts")]
        public int WorkoutsID { get; set; }
        public string muscle { get; set; }
    }
}
