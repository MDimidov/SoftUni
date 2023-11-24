﻿using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models.Interfaces;

namespace VaporStore.Data.Models;

public class Developer : IHasName
{
    public Developer()
    {
        Games = new HashSet<Game>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public virtual ICollection<Game> Games { get; set; }
}
