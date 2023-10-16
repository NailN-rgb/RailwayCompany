using System;
using System.Collections.Generic;

namespace RailwayCompany.Models;

public partial class Person
{
    public int Id { get; set; }

    public string UserFirstname { get; set; } = null!;

    public string UserSecondname { get; set; } = null!;

    public string UserLastname { get; set; } = null!;

    public DateOnly UserDatebirth { get; set; }

    public int UserSale { get; set; }

    public string UserContacts { get; set; } = null!;

    public int? UserTicket { get; set; }

    public virtual Ticket? UserTicketNavigation { get; set; }
}
