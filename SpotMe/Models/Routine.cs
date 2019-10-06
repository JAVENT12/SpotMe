using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Models
{
    public class Routine
    {
        [Key]
        public int routineID { get; set; }
        [Key]
        [ForeignKey("Excerciser")]
        public int excerciserID { get; set; }
        [Key]
        [ForeignKey("WorkOuts")]
        public int WorkOutsID { get; set; }
        [Key]
        [ForeignKey("MuscleGroup")]
        public int muscleGroupID { get; set; }
        public string details { get; set; }

    }
}
