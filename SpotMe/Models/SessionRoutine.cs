using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Identity.Infrastructure;

namespace Identity.Models
{
    public class SessionRoutine : Routine
    {
        public static Routine GetRoutine(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
            .HttpContext.Session;
            SessionRoutine routine = session?.GetJson<SessionRoutine>("Routine")
            ?? new SessionRoutine();
            routine.Session = session;
            return routine;
        }
        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddExercise(MuscleGroup muscleGroup, int quantity)
        {
            base.AddExercise(muscleGroup, quantity);
            Session.SetJson("Routine", this);
        }
        public override void RemoveLine(MuscleGroup muscleGroup)
        {
            base.RemoveLine(muscleGroup);
            Session.SetJson("Routine", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Routine");
        }
    }
}
