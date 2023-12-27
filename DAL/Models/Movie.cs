using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public string MovieName { get; set; }

    public string ActorName { get; set; }

    public int Duration { get; set; }

    public string DirectorName { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
