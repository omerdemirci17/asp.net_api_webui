using API_WEBUI_1.Entity.Entities;
using API_WEBUI_1.WebUI.DTOs.UserDTOs;
using Microsoft.AspNetCore.Identity;

namespace API_WEBUI_1.WebUI.Services.UserServices
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(UserRegisterDTO userRegisterDTO);
        Task<string> LoginAsync(UserLoginDTO userRegisterDTO);
        Task<bool> LogoutAsync();
        Task<bool> CreateRoleAsync(UserRoleDTO userRoleDTO);
        Task<bool> AssignRoleAsync(List<AssignRoleDTO> assignRoleDTO);
        Task<List<AppUser>> GetAllUsersAsync();
        Task<AppUser> GetUserById(int id);
    }
}

