using System.Text.Json.Serialization;
using barbershop.Helpers;

namespace barbershop.Dtos
{
    public class FilterGroup
    {
        public string? @operator { get; set; }
        public List<FilterGroup>? filters { get; set; } // Nested filter groups
        public string? column { get; set; }
        public string? condition { get; set; }

        [JsonConverter(typeof(ValueConverter))]
        public object? value { get; set; }
    }
}
