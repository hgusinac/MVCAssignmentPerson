using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Database
{
    public class DbInitializer
    {
        public static void Initialize(
          PeopleDbContext context, //Database
          RoleManager<IdentityRole> roleManager, //Role
          UserManager<AppUser> AppUser)//User
        {
            //context.Database.EnsureCreated();//If not using EF migrations
            context.Database.Migrate();


            if (context.Roles.Any())//letar efter roller i databasen
            {
                return;//
            }

            //----------Seed into database --------------------------------------



            string[] rolesToSeed = new string[] { "Admin", "User" };

            foreach (var roleName in rolesToSeed)
            {

                IdentityRole role = new IdentityRole(roleName);

                var result = roleManager.CreateAsync(role).Result;

                if (!result.Succeeded)
                {
                    throw new Exception("Faild to create Role" + roleName);
                }
            }

            AppUser user = new AppUser()
            {
                UserName = "AdminPower",
                FirstName = "Admin",
                LastName = "Admin",
                BirthDate= "2020",
                Email = "a@a.a",
                PhoneNumber = "123456789"
            };
            IdentityResult resultUser = AppUser.CreateAsync(user, "Qwer1234!").Result;

            if (!resultUser.Succeeded)
            {
                throw new Exception("Faild to create Admin Acc: AdminPower");
            }

            IdentityResult resultAssign = AppUser.AddToRoleAsync(user, rolesToSeed[0]).Result;

            if (!resultAssign.Succeeded)
            {
                throw new Exception($"Faild to grant Admin {rolesToSeed[0]} to AdminPower");
            }
        }
    }
}
    

