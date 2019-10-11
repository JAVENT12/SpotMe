using Identity.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace Identity.Infrastructure
{
    public class CustomRemoteValidation : RemoteAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            AppMuscleDbContext db = new AppMuscleDbContext();

            //Take the additional field property name and value
            PropertyInfo additionalPropertyName =
            validationContext.ObjectInstance.GetType().GetProperty(AdditionalFields);
            object additionalPropertyValue =
            additionalPropertyName.GetValue(validationContext.ObjectInstance, null);

            bool validateName = db.MuscleGroup.Any
            (x => x.name == (string)value && x.muscleGroupID != (int)additionalPropertyValue);
            if (validateName == true)
            {
                return new ValidationResult
                ("The muscle already exist", new string[] { "muscle" });
            }
            return ValidationResult.Success;
        }

        public CustomRemoteValidation(string routeName)
            : base(routeName)
        {
        }

        public CustomRemoteValidation(string action, string controller)
            : base(action, controller)
        {
        }

        public CustomRemoteValidation(string action, string controller,
            string areaName) : base(action, controller, areaName)
        {
        }
    }
}
