using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectTask.Data;
using ProjectTask.Identity;
using ProjectTask.Repository.IRepository;

namespace ProjectTask.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        public UserRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> rolemanager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _rolemanager = rolemanager;
        }

        public async Task<ApplicationUser?> AuthenticateUser(string userName, string userPassword)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, userPassword, false, false);
            var userExist = await _userManager.FindByNameAsync(userName);
            userExist.PasswordHash = "";
            return userExist;           
        }

        public async Task<ApplicationUser?> CheckUserInDb(string userName)
        {
            var UserInDb = await _userManager.FindByIdAsync(userName);
            if (UserInDb == null) return null;
            var rolecheck = await _userManager.GetRolesAsync(UserInDb);
            UserInDb.Role = rolecheck?.FirstOrDefault();
            return UserInDb;
        }

        public async Task<bool> IsUnique(string userName)
        {
            var userExist = await _userManager.FindByNameAsync(userName);
            if (userExist == null) return true;
            var rolecheck = await _userManager.GetRolesAsync(userExist);
            userExist.Role = rolecheck?.FirstOrDefault();
            return false;
        }

        public async Task<bool> RegisterUser(ApplicationUser user)
        {
            if (await _rolemanager.FindByNameAsync(user.Role) == null) return false;
            //Admin role
            //if (user.Role == SD.role_Admin)
            //{
            //    var checkAdmin = await _userManager.GetUsersInRoleAsync(SD.role_Admin);
            //    if (checkAdmin.Count == 1) return false;
            //}
            var users = await _userManager.CreateAsync(user, user.PasswordHash);
            if (!users.Succeeded) return false;
            await _userManager.AddToRoleAsync(user, user.Role);
            return true;
        }
    }
}
