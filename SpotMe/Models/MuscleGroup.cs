using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Identity.Infrastructure;

namespace Identity.Models
{
    public class MuscleGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int muscleGroupID { get; set; }
        //[Key]
        //[ForeignKey("WorkOuts")]
        public int WorkoutsID { get; set; }

        [Required(ErrorMessage = "Please enter a muscle")]
        public string name { get; set; }

    }
}
