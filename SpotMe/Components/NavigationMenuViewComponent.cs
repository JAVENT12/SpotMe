using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Identity.Models;

namespace Identity.Components
{
    public class NavigationMenuViewComponent :ViewComponent
    {
        private IMuscleGroupRepository repository;
        public NavigationMenuViewComponent(IMuscleGroupRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.MuscleGroups
            .Select(x => x.muscleCategory)
            .Distinct()
            .OrderBy(x => x));
        }
    }
}
