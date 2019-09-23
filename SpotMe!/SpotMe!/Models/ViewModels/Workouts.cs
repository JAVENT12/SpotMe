using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpotMe_.Models
{
    public class Workouts
    {
        [Key]
        public int WorkOutsID { get; set; }
        [Key]
        [ForeignKey("MuscleGroup")]
        public int muscleGroupID { get; set; }
        public string title { get; set; }
    }
}
