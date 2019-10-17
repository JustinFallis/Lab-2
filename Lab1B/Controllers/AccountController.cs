// I, Justin Fallis, 000398973, certify that this material is my
// original work. No other person's work has been used without due
// acknowledgement and I have not made my work available to anyone else.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab1B.Data;
using Lab1B.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lab1B.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManger;

        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManger = roleManager;
        }

        public async Task<IActionResult> SeedRoles()
        {
            ApplicationUser user1 = new ApplicationUser
            {
                Email = "Justin2@hotmail.com",
                UserName = "Justin2@hotmail.com",
                FirstName = "Justin",
                LastName = "Hill",
                BirthDate = DateTimeOffset.Now
            };
            ApplicationUser user2 = new ApplicationUser
            {
                Email = "Devon2@hotmail.com",
                UserName = "Devon2@hotmail.com",
                FirstName = "Devon",
                LastName = "Laslo",
                BirthDate = DateTimeOffset.Now
            };

            IdentityResult result = await _userManager.CreateAsync(user1, "Mohawk1!");
            if (!result.Succeeded)
            {
                return View("Error");
            }
            result = await _userManager.CreateAsync(user2, "Mohawk2!");
            if (!result.Succeeded)
            {
                return View("Error");
            }

            result = await _roleManger.CreateAsync(new IdentityRole("Supervisor"));
            if (!result.Succeeded)
            {
                return View("Error");
            }
            result = await _roleManger.CreateAsync(new IdentityRole("Employee"));
            if (!result.Succeeded)
            {
                return View("Error");
            }

            result = await _userManager.AddToRoleAsync(user1, "Employee");
            if (!result.Succeeded)
            {
                return View("Error");
            }

            result = await _userManager.AddToRoleAsync(user2, "Supervisor");
            if (!result.Succeeded)
            {
                return View("Error");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}