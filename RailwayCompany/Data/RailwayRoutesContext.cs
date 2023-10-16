using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RailwayCompany.Models;

namespace RailwayCompany.Data;

public partial class RailwayRoutesContext : DbContext
{
    public RailwayRoutesContext()
    {
    }

    public RailwayRoutesContext(DbContextOptions<RailwayRoutesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Models.Route> Routes { get; set; }

    public virtual DbSet<Station> Stations { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Train> Trains { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=RailwayRoutes;Username=postgres;Password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pk");

            entity.ToTable("person");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.UserContacts)
                .HasMaxLength(255)
                .HasColumnName("user_contacts");
            entity.Property(e => e.UserDatebirth).HasColumnName("user_datebirth");
            entity.Property(e => e.UserFirstname)
                .HasMaxLength(255)
                .HasColumnName("user_firstname");
            entity.Property(e => e.UserLastname)
                .HasMaxLength(255)
                .HasColumnName("user_lastname");
            entity.Property(e => e.UserSale).HasColumnName("user_sale");
            entity.Property(e => e.UserSecondname)
                .HasMaxLength(255)
                .HasColumnName("user_secondname");
            entity.Property(e => e.UserTicket).HasColumnName("user_ticket");

            entity.HasOne(d => d.UserTicketNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.UserTicket)
                .HasConstraintName("user_fk0");
        });

        modelBuilder.Entity<Models.Route>(entity =>
        {
            entity.HasKey(e => e.RouteId).HasName("route_pk");

            entity.ToTable("route");

            entity.Property(e => e.RouteId).HasColumnName("route_id");
            entity.Property(e => e.RouteDeparture)
                .HasMaxLength(255)
                .HasColumnName("route_departure");
            entity.Property(e => e.RouteDestination)
                .HasMaxLength(255)
                .HasColumnName("route_destination");
            entity.Property(e => e.RouteTime).HasColumnName("route_time");
        });

        modelBuilder.Entity<Station>(entity =>
        {
            entity.HasKey(e => e.StationId).HasName("station_pk");

            entity.ToTable("station");

            entity.Property(e => e.StationId).HasColumnName("station_id");
            entity.Property(e => e.StationName)
                .HasMaxLength(255)
                .HasColumnName("station_name");
            entity.Property(e => e.StationRoute).HasColumnName("station_route");
            entity.Property(e => e.StationWaitingtime).HasColumnName("station_waitingtime");

            entity.HasOne(d => d.StationRouteNavigation).WithMany(p => p.Stations)
                .HasForeignKey(d => d.StationRoute)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("station_fk0");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("ticket_pk");

            entity.ToTable("ticket");

            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.TicketPrice).HasColumnName("ticket_price");
            entity.Property(e => e.TicketTrain).HasColumnName("ticket_train");

            entity.HasOne(d => d.TicketTrainNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TicketTrain)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ticket_fk0");
        });

        modelBuilder.Entity<Train>(entity =>
        {
            entity.HasKey(e => e.TrainId).HasName("train_pk");

            entity.ToTable("train");

            entity.Property(e => e.TrainId).HasColumnName("train_id");
            entity.Property(e => e.TrainComfort).HasColumnName("train_comfort");
            entity.Property(e => e.TrainLength).HasColumnName("train_length");
            entity.Property(e => e.TrainPriretyqoef).HasColumnName("train_priretyqoef");
            entity.Property(e => e.TrainRoute).HasColumnName("train_route");

            entity.HasOne(d => d.TrainRouteNavigation).WithMany(p => p.Trains)
                .HasForeignKey(d => d.TrainRoute)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("train_fk0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
