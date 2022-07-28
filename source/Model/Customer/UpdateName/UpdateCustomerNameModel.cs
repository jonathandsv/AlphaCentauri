using System.Text.Json.Serialization;

namespace AlphaCentauri.Model;

public sealed record UpdateCustomerNameModel
{
    [JsonIgnore]
    public long Id { get; set; }

    public string Name { get; set; }
}
