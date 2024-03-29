﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Identity.Infrastructure;

namespace Identity.Controllers
{
    //[RequireHttps]
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        private IExcerciserRepository repository;

        private AppMuscleDbContext __context;
        private IMuscleGroupRepository muscleRepository;



        private UserManager<AppUser> userManager;
        private IUserValidator<AppUser> userValidator;
        private IPasswordValidator<AppUser> passwordValidator;
        private IPasswordHasher<AppUser> passwordHasher;

        public HomeController(UserManager<AppUser> usrMgr,
        IUserValidator<AppUser> userValid,
        IPasswordValidator<AppUser> passValid,
        IPasswordHasher<AppUser> passwordHash, IExcerciserRepository repo, ApplicationDbContext context,
        AppMuscleDbContext mContext, IMuscleGroupRepository mRepo)
        {
            userManager = usrMgr;
            userValidator = userValid;
            passwordValidator = passValid;
            passwordHasher = passwordHash;
            repository = repo;
            _context = context;
            muscleRepository = mRepo;
            __context = mContext;


        }





        //[Authorize]
        public ViewResult Index() =>
        View(new Dictionary<string, object>
        { ["Placeholder"] = "Placeholder" });
        [Authorize(Roles = "Users")]

        public IActionResult OtherAction() => View("Index",
         GetData(nameof(OtherAction)));

        private Dictionary<string, object> GetData(string actionName) =>
        new Dictionary<string, object>
        {
            ["Action"] = actionName,
            ["User"] = HttpContext.User.Identity.Name,
            ["Authenticated"] = HttpContext.User.Identity.IsAuthenticated,
            ["Auth Type"] = HttpContext.User.Identity.AuthenticationType,
            ["In Users Role"] = HttpContext.User.IsInRole("Users")
        };
        [HttpGet]
        public ViewResult SignUp() => View();

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(CreateModel model, Excerciser excerciser)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.Name,
                    Email = model.Email,

                };
                //string name = user.UserName; Testing!
                //if(name.Contains(" "))
                //{
                //    ModelState.AddModelError(nameof(name),"No white spaces");
                //    return View("SignUp");
                //}
                //excerciser.UserName = name;
                //excerciser.Email = user.Email;
                //string newPassWord = model.Password;
                //excerciser.userPassword = Encrypt.CreateMD5(newPassWord);    
                //_context.Excerciser.Add(excerciser);
                //_context.SaveChanges();

                IdentityResult result
                = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                   
                    return RedirectToAction("Routines");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
        [Authorize]
        public ViewResult Routines()
        {
            return View();
        }
        public ViewResult Faq()
        {
            return View();
        }

        





    }
}
