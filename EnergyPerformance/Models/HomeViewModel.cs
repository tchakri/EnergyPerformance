using Microsoft.AspNetCore.Mvc.Rendering;

namespace EnergyPerformance.Models
{
    public class HomeViewModel
    {
        public int CurrentPage { get; set; } = 1;
        public int SelectedPageSize { get; set; }
        public string SelectedAddress { get; set; } = string.Empty;
        public string SelectedPostcode { get; set; } = string.Empty;
        public string SelectedLocalAuthority { get; set;} = string.Empty;
        public List<SelectListItem> PagesSelectList { get; set; } = new List<SelectListItem>();
        public List<PublicBuilding> PublicBuildings { get; set; } = new List<PublicBuilding>();
    }
}
