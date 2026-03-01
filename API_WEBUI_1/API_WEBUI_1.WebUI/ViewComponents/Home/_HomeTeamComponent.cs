using API_WEBUI_1.DTO.DTOs.SocialMediaDTOs;
using API_WEBUI_1.WebUI.DTOs.EmployeeDTOs;
using API_WEBUI_1.WebUI.Helpers;
using Microsoft.AspNetCore.Mvc;
using API_WEBUI_1.Entity.Entities;

namespace API_WEBUI_1.WebUI.ViewComponents.Home
{
    public class _HomeTeamComponent : ViewComponent
    {
        private readonly HttpClient _httpClient = HttpClientInstance.CreateClient();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var employee = await _httpClient.GetFromJsonAsync<List<ResultEmployeeDTO>>("Employee");
            var socials = await _httpClient.GetFromJsonAsync<List<ResultSocialMediaDTO>>("SocialMedia");
            var lookup = socials.GroupBy(s => s.EmployeeId).ToDictionary(g => g.Key, g => g.ToList());

            foreach (var emp in employee)
            {
                emp.SocialMedia = lookup.TryGetValue(emp.EmployeeId, out var list) ? list : new List<ResultSocialMediaDTO>();
            }

            return View(employee);
        }
    }
}
