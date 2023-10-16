using System;
using System.Collections.Generic;

namespace RailwayCompany.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int TicketPrice { get; set; }

    public int TicketTrain { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();

    public virtual Train TicketTrainNavigation { get; set; } = null!;
}
