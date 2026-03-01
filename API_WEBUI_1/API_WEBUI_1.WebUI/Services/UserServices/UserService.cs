using API_WEBUI_1.Entity.Entities;
using API_WEBUI_1.WebUI.DTOs.UserDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace API_WEBUI_1.WebUI.Services.UserServices
{
    public class UserService(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager) : IUserService
    {
        public async Task<bool> AssignRoleAsync(List<AssignRoleDTO> assignRoleDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateRoleAsync(UserRoleDTO userRoleDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> CreateUserAsync(UserRegisterDTO userRegisterDTO)
        {
            var user = new AppUser
            {
                FirstName = userRegisterDTO.FirstName,
                LastName = userRegisterDTO.LastName,
                UserName = userRegisterDTO.UserName,
                Email = userRegisterDTO.Email,
            };
            if (userRegisterDTO.Password != userRegisterDTO.ConfirmPassword)
            {
                return new IdentityResult();

            }
            var result = await _userManager.CreateAsync(user, userRegisterDTO.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Customer");
                return result;
            }
            return result;
        }

        public async Task<List<AppUser>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<AppUser> GetUserById(int id)
        {
            return await _userManager.Users.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<string> LoginAsync(UserLoginDTO userLoginDTO)
        {
            var user = await _userManager.FindByEmailAsync(userLoginDTO.Email);

            if (user == null)
            {
                return null;
            }

            var result = await _signInManager.PasswordSignInAsync(user, userLoginDTO.Password, false, false);
            if (!result.Succeeded)
            {
                return null;
            }
            else
            {
                var IsAdmin = await _userManager.IsInRoleAsync(user, "Admin");
                if (IsAdmin) { return "Admin"; }

                var IsCustomer = await _userManager.IsInRoleAsync(user, "Customer");
                if (IsCustomer) { return "Customer"; }

                var IsEmployee = await _userManager.IsInRoleAsync(user, "Employee");
                if (IsEmployee) { return "Employee"; }
            }

            return null;
        }

        public Task<bool> LogoutAsync()
        {
            throw new NotImplementedException();
        }

    }
}
