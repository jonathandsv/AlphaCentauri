using System.Text.Json.Serialization;

namespace AlphaCentauri.Model;

public sealed record UpdateCustomerModel
{
    [JsonIgnore]
    public long Id { get; set; }

    public string Name { get; set; }

    public DateTime Birthday { get; set; }
}
