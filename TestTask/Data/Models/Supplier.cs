#nullable enable
using System.Text.Json.Serialization;

namespace API.Data.Models;

public class Supplier : Entity
{
    public string Name { get; set; } = null!;

    public bool IsObsolete { get; set; }

    [JsonIgnore]
    public virtual ICollection<Medicine> Medicines { get; set; } = null!;
}
