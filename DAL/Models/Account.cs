using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Account
{
    public string AccountId { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public int AccoutRole { get; set; }

    public string Status { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
