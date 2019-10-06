using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Models
{
    public class WorkOuts
    {
        [Key]
        public int WorkOutsID { get; set; }
        [Key]
        [ForeignKey("MuscleGroup")]
        public int muscleGroupID { get; set; }
        public string title { get; set; }
    }
}