using Domain;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Common;

namespace Persistence;

public class CampusContext : IdentityDbContext<User>
{
    private readonly IMediator _mediator;
    public CampusContext(DbContextOptions options, IMediator mediator) : base(options)
    {
        _mediator = mediator;
    }
    
    public DbSet<Assistance> Assistances {get; set; }    
    public DbSet<Campus> Campuses {get; set; }    
    public DbSet<CleaningSchedule> CleaningSchedules {get; set; }    
    public DbSet<Employee> Employees {get; set; }    
    public DbSet<LaundryAccounting> LaundryAccountings {get; set; }    
    public DbSet<News> News {get; set; }    
    public DbSet<Profession> Professions {get; set; }    
    public DbSet<Request> Requests {get; set; }    
    public DbSet<Resident> Residents {get; set; }   
    public DbSet<Room> Rooms {get; set; }
    public DbSet<Thing> Things {get; set; }
    public DbSet<Violation> Violations { get; set; }
    public DbSet<WashingMode> WashingModes { get; set; }
    public DbSet<RoomThing> RoomThings { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<Passport> Passports { get; set; }
    public DbSet<RequestType> RequestTypes { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<User>()
            .HasOne(u => u.Passport)
            .WithOne(r => r.User)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<User>()
            .HasOne(u => u.Resident)
            .WithOne(r => r.User)
            .HasForeignKey<Resident>(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<User>()
            .HasOne(u => u.Employee)
            .WithOne(r => r.User)
            .HasForeignKey<Employee>(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<User>()
            .HasOne(u => u.Photo)
            .WithOne(r => r.User)
            .HasForeignKey<Photo>(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Assistance>()
            .HasOne(a => a.Employee)
            .WithMany(e => e.Assistances)
            .HasForeignKey(a => a.EmployeeId);
        builder.Entity<Assistance>()
            .HasOne(a => a.Resident)
            .WithMany(e => e.Assistances)
            .HasForeignKey(a => a.ResidentId);

        builder.Entity<Employee>()
            .HasMany(e => e.Professions)
            .WithMany(p => p.Employees);
        builder.Entity<Employee>()
            .HasMany(e => e.ResponsibleFor)
            .WithMany(p => p.Responsible);
        builder.Entity<Employee>()
            .HasMany(e => e.Campuses)
            .WithMany(p => p.Employees);
        
        
        builder.Entity<Resident>()
            .HasOne(e => e.Campus)
            .WithMany(p => p.Residents)
            .HasForeignKey(e => e.CampusId);
        builder.Entity<Resident>()
            .HasOne(e => e.Room)
            .WithMany(p => p.Residents)
            .HasForeignKey(e => e.RoomId);
        
        builder.Entity<Request>()
            .HasOne(r => r.Type)
            .WithMany(s => s.Requests)
            .HasForeignKey(e => e.TypeId);
        builder.Entity<Request>()
            .HasOne(r => r.Employee)
            .WithMany(s => s.Requests)
            .HasForeignKey(e => e.ExecutorEmployeeId);
        builder.Entity<Request>()
            .HasOne(r => r.Resident)
            .WithMany(s => s.Requests)
            .HasForeignKey(e => e.CreatorResidentId);
        
        builder.Entity<RoomThing>()
            .HasOne(r => r.Room)
            .WithMany(s => s.RoomThings)
            .HasForeignKey(e => e.RoomId);
        builder.Entity<RoomThing>()
            .HasOne(r => r.Thing)
            .WithMany(s => s.RoomThings)
            .HasForeignKey(e => e.ThingId);
        
        builder.Entity<News>()
            .HasOne(r => r.Employee)
            .WithMany(s => s.News)
            .HasForeignKey(e => e.CreatedEmployeeId);
        builder.Entity<News>()
            .HasMany(e => e.PhotoIds)
            .WithMany(p => p.News);
        
        
        builder.Entity<News>().Property(f => f.CreateDate).HasColumnType("date");
        builder.Entity<Passport>().Property(f => f.IssuedDate).HasColumnType("date");
        builder.Entity<Passport>().Property(f => f.BirthDate).HasColumnType("date");
        builder.Entity<Passport>().Property(f => f.PassportSeries).HasMaxLength(4).IsFixedLength();
        builder.Entity<Passport>().Property(f => f.PassportNumber).HasMaxLength(6).IsFixedLength();
        builder.Entity<Resident>().Property(f => f.GraduationDate).HasColumnType("date");
        builder.Entity<Employee>().Property(f => f.EmploymentDate).HasColumnType("date");
        builder.Entity<Room>().Property(f => f.RepairDate).HasColumnType("date");
        builder.Entity<User>().Property(f => f.BirthDate).HasColumnType("date");
    }
}