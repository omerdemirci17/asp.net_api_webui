using API_WEBUI_1.Entity.Entities;
using API_WEBUI_1.WebUI.DTOs.RoleDTOs;
using API_WEBUI_1.WebUI.Services.RoleServices;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_WEBUI_1.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]

    public class RoleController(IRoleService _roleService): Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _roleService.GetAllRolesAsync();
            return View(values);
        }

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDTO createRoleDTO)
        {
            await _roleService.CreateRoleAsync(createRoleDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            await _roleService.DeleteRoleAsync(id);
            return RedirectToAction("Index");
        }
     
    }
}
