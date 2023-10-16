using System;
using System.Collections.Generic;

namespace RailwayCompany.Models;

public partial class Station
{
    public int StationId { get; set; }

    public string StationName { get; set; } = null!;

    public int StationWaitingtime { get; set; }

    public int StationRoute { get; set; }

    public virtual Route StationRouteNavigation { get; set; } = null!;
}
