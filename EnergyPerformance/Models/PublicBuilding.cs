using Newtonsoft.Json;

namespace EnergyPerformance.Models
{
    public class PublicBuilding
    {
        [JsonProperty(PropertyName = "lmk-key")]
        public string LmkKey { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string postcode { get; set; }
        [JsonProperty(PropertyName = "building-reference-number")]
        public string buildingReferenceNumber { get; set; }
        [JsonProperty(PropertyName = "current-energy-rating")]
        public string currentEnergyRating { get; set; }
        [JsonProperty(PropertyName = "potential-energy-rating")]
        public string potentialEnergyRating { get; set; }
        [JsonProperty(PropertyName = "current-energy-efficiency")]
        public string currentEnergyEfficiency { get; set; }
        [JsonProperty(PropertyName = "potential-energy-efficiency")]
        public string potentialEnergyEfficiency { get; set; }
        [JsonProperty(PropertyName = "property-type")]
        public string propertyType { get; set; }
        [JsonProperty(PropertyName = "built-form")]
        public string builtForm { get; set; }
        [JsonProperty(PropertyName = "inspection-date")]
        public DateTime inspectionDate { get; set; }
        public string constituency { get; set; }
        public string county { get; set; }
        [JsonProperty(PropertyName = "lodgement-date")]
        public DateTime lodgementDate { get; set; }
        public string address { get; set; }
        public string postTown { get; set; }
        [JsonProperty(PropertyName = "local-authority")]
        public string localAuthority { get; set; }
        [JsonProperty(PropertyName = "local-authority-label")]
        public string localAuthorityLabel { get; set; }
    }
}
