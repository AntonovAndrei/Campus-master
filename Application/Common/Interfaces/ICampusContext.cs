using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface ICampusContext
{
    public DbSet<Assistance> Assistances {get; }    
    public DbSet<Campus> Campuses {get; }    
    public DbSet<CleaningSchedule> CleaningSchedules {get; }    
    public DbSet<Employee> Employees {get; }    
    public DbSet<LaundryAccounting> LaundryAccountings {get; }    
    public DbSet<News> News {get; }    
    public DbSet<Profession> Professions {get; }    
    public DbSet<Request> Requests {get; }    
    public DbSet<Resident> Residents {get; }   
    public DbSet<Room> Rooms {get; }
    public DbSet<Thing> Things {get; }
    public DbSet<Violation> Violations { get; }
    public DbSet<WashingMode> WashingModes { get; }
    public DbSet<RoomThing> RoomThings { get; }
    public DbSet<Photo> Photos { get; }
    public DbSet<Passport> Passports { get; }
    public DbSet<RequestType> RequestTypes { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}