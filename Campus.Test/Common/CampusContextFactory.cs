using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using Persistence;

namespace Campus.Test.Common;

public class CampusContextFactory
{
    
    
    private static readonly Mock<IMediator> _mediator = new  Mock<IMediator>();
    public static Guid UserAId = Guid.NewGuid();
    public static Guid UserBId = Guid.NewGuid();

    public static Guid RoomIdForDelete = Guid.NewGuid();
    public static Guid RoomIdForUpdate = Guid.NewGuid();

    public static CampusContext Create()
    {
        var options = new DbContextOptionsBuilder<CampusContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var context = new CampusContext(options, _mediator.Object);
        context.Database.EnsureCreated();
        context.Rooms.AddRange(
            new Room()
            {
                Id = Guid.Parse("A6BB65BB-5AC2-4AFA-8A28-2616F675B825"),
                Block = 1216,
                BlockCode = "m",
                RepairDate = DateTime.Now.AddYears(-4),
                RoomRating = 65,
                Remarks = "Много захломленностей"
            },
            new Room()
            {
                Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084"),
                Block = 505,
                BlockCode = "b",
                RepairDate = DateTime.Now.AddYears(-10),
                RoomRating = 45,
                Remarks = "Часто шумят"
            },
            new Room()
            {
                Id = RoomIdForUpdate,
                Block = 710,
                BlockCode = "b",
                RepairDate = DateTime.Now.AddYears(-5),
                RoomRating = 90
            },
            new Room()
            {
                Id = RoomIdForDelete,
                Block = 1001,
                BlockCode = "m",
                RepairDate = DateTime.Now.AddYears(-2),
                RoomRating = 75
            }
        );
        context.SaveChanges();
        return context;
    }

    public static void Destroy(CampusContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}