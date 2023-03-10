using Newtonsoft.Json;

namespace EnergyPerformance.Models
{
    public class Recommendation
    {
        [JsonProperty(PropertyName = "lmk-key")] public string LmkKey { get; set; }
        [JsonProperty(PropertyName = "improvement-item")] public string ImprovementItem { get; set; }
        [JsonProperty(PropertyName = "improvement-summary-text")] public string ImprovementSummaryText { get; set; }
        [JsonProperty(PropertyName = "improvement-descr-text")] public string ImprovementDescrText { get; set; }
        [JsonProperty(PropertyName = "improvement-id")] public string ImprovementId { get; set; }
        [JsonProperty(PropertyName = "improvement-id-text")] public string ImprovementIdText { get; set; }
        [JsonProperty(PropertyName = "indicative-cost")] public string IndicativeCost { get; set; }
    }
}
