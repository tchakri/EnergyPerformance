using EnergyPerformance.Models;

namespace EnergyPerformance.Helpers
{
    public static class PageSize
    {
        public static List<Page> GetPageSizes()
        {
            return new List<Page>
            {
                new Page { Id = "10", Name = "10"},
                new Page { Id = "25", Name = "25"},
                new Page { Id = "50", Name = "50"},
                new Page { Id = "100", Name = "100"},
                new Page { Id = "200", Name = "200"},
            };
        }
    }
}
