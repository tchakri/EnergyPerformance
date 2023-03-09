using EnergyPerformance.Helpers;
using EnergyPerformance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace EnergyPerformance.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var pages = PageSize.GetPageSizes();

            var model = new HomeViewModel();
            model.PagesSelectList = new List<SelectListItem>();

            foreach (var page in pages)
            {
                model.PagesSelectList.Add(new SelectListItem { Text = page.Name, Value = page.Id });
            }

            return View(model);
        }

        [HttpPost]
        public async Task<PartialViewResult> Index(HomeViewModel model)
        {
            ModelState.Clear();

            var localAuthority = string.Empty;
            if (!string.IsNullOrEmpty(model.SelectedLocalAuthority))
            {
                localAuthority = LocalAuthorities.GetLocalAuthorities()
                .Where(u => u.Description == model.SelectedLocalAuthority)
                .Select(u => u.Code).First();
            }
            var data = await CallAPI($"https://epc.opendatacommunities.org/api/v1/domestic/search?size={model.SelectedPageSize}&from={model.CurrentPage * model.SelectedPageSize}&address={model.SelectedAddress}&postcode={model.SelectedPostcode}&local-authority={localAuthority}");

            var obj = JsonConvert.DeserializeObject<ResponseData<PublicBuilding>>(data);
            model.PublicBuildings = obj.Rows;

            return PartialView("_PublicBuilding", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<List<string>> SearchLocalAuthority()
        {
            string term = HttpContext.Request.Query["term"].ToString().ToLower();
            var localAuthorities = LocalAuthorities.GetLocalAuthorities()
                .Where(u => u.Description.ToLower().Contains(term))
                .Select(u => u.Description).ToList();
            return localAuthorities;
        }

        private async Task<string> CallAPI(string url)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", "dGFtYXRhbWNoYWtyaUBnbWFpbC5jb206MjY3OTNhNjQ2MDM5N2Q4MTE4OTUyYTNjYWM5YjdmN2UwMTZiODc1Yg==");

            var response = client.SendAsync(request).Result;
            return await response.Content.ReadAsStringAsync();
        }
    }
}