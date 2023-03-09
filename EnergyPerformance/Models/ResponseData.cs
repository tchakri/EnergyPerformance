using Newtonsoft.Json;

namespace EnergyPerformance.Models
{
    public class ResponseData<T>
    {
        [JsonProperty(PropertyName="column-names")]
        public string[] ColumnNames { get; set; }
        public List<T> Rows { get; set; }
    }
}
