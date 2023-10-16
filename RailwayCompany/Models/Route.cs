using System;
using System.Collections.Generic;

namespace RailwayCompany.Models;

public partial class Route
{
    public int RouteId { get; set; }

    public string RouteDeparture { get; set; } = null!;

    public string RouteDestination { get; set; } = null!;

    public int RouteTime { get; set; }

    public virtual ICollection<Station> Stations { get; set; } = new List<Station>();

    public virtual ICollection<Train> Trains { get; set; } = new List<Train>();
}
