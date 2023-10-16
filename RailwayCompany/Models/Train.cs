using System;
using System.Collections.Generic;

namespace RailwayCompany.Models;

public partial class Train
{
    public int TrainId { get; set; }

    public int TrainLength { get; set; }

    public int TrainRoute { get; set; }

    public bool TrainComfort { get; set; }

    public double TrainPriretyqoef { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual Route TrainRouteNavigation { get; set; } = null!;
}
