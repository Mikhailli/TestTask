﻿#nullable enable
using System.Text.Json.Serialization;

namespace Data.Models;

public class Supplier : Entity
{
    public string Name { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Medicine> Medicines { get; set; } = null!;
}
