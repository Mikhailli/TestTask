#nullable enable
using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public abstract class Entity : IEntity
{
    [Key]
    public virtual int Id { get; set; }
}
