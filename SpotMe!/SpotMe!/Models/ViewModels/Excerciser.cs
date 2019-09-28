using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SpotMe_.Models
{
    public class Excerciser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int excerciserID { get; set; }
        [Required(ErrorMessage = "Please enter your first name")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "Please enter your  username")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+",
            ErrorMessage = "Please enter a valid email address")]
        public string email { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        public string userPassword { get; set; }
    }
}
