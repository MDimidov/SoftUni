﻿using System.ComponentModel.DataAnnotations;
using Theatre.Common;
using Theatre.Data.Models.Enums;

namespace Theatre.Data.Models;

public class Play
{
    public Play()
    {
        Tickets = new HashSet<Ticket>();
        Casts = new HashSet<Cast>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.PlayTitleMaxLength)]
    public string Title { get; set; } = null!;

    [Required]
    public TimeSpan Duration { get; set; }

    public float Rating { get; set; }

    public Genre Genre { get; set; }

    [Required]
    [MaxLength(ValidationConstants.PlayDescriptionMaxLength)]
    public string Description { get; set; } = null!;

    [Required]
    [MaxLength(ValidationConstants.PlayScreenwriterMaxLength)]
    public string Screenwriter { get; set; } = null!;

    public virtual ICollection<Cast> Casts { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; }
}
