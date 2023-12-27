using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Ticket
{
    public string TicketId { get; set; }

    public int Amount { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string Slot { get; set; }

    public int MovieId { get; set; }

    public string Seat { get; set; }

    public string Status { get; set; }

    public string AccountId { get; set; }

    public virtual Account Account { get; set; }

    public virtual Movie Movie { get; set; }
}
