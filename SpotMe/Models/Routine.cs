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
        public int ID { get; set; }
        [Key]
        [ForeignKey("WorkOuts")]
        public int WorkOutsID { get; set; }
        [Key]
        [ForeignKey("MuscleGroup")]
        public int muscleGroupID { get; set; }
        public string details { get; set; }
        public string UserName { get; set; }

        private List<Regiment> workoutCollection = new List<Regiment>();

        public virtual void AddExercise(MuscleGroup muscleGroup, int quantity)
        {
            Regiment line = workoutCollection
            .Where(m => m.MuscleGroup.muscleGroupID == muscleGroup.muscleGroupID)
            .FirstOrDefault();

            if(line == null)
            {
                workoutCollection.Add(new Regiment
                {
                    MuscleGroup = muscleGroup,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(MuscleGroup muscleGroup) =>
            workoutCollection.RemoveAll(l => l.MuscleGroup.muscleGroupID == muscleGroup.muscleGroupID);
            public virtual void Clear() => workoutCollection.Clear();
        public virtual IEnumerable<Regiment> Lines => workoutCollection;

    }
    public class Regiment
    {
        public int RegimentID { get; set; }
        public MuscleGroup MuscleGroup { get; set; }
        public int Quantity { get; set; }
    }
}
