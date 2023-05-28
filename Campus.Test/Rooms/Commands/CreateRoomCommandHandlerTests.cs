using Application.Common;
using Application.Rooms;
using Application.Rooms.Commands.Create;
using AutoMapper;
using Campus.Test.Common;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Campus.Test.Rooms.Commands;

public class CreateRoomCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task CreateRoomCommandHandler_Success()
    {
        // Arrange
        var handler = new CreateRoomCommandHandler(Context, Mapper);
        var roomDto = new RoomDto()
        {
            Block = 712,
            BlockCode = "m",
            RepairDate = DateTime.Now.AddYears(-7),
            RoomRating = 90
        };

        // Act
        var roomId = await handler.Handle(
            new CreateRoomCommand() { RoomDto = roomDto }, CancellationToken.None);

        // Assert
        Assert.NotNull(
            await Context.Rooms.SingleOrDefaultAsync(room =>
                room.Id == roomId.Value));
    }
    
    [Fact]
    public async Task CreateRoomCommandHandler_FailOnExistingBlockAndBlockCode()
    {
        // Arrange
        var handler = new CreateRoomCommandHandler(Context, Mapper);
        var expectedResult = Result<Guid>.Failure("Such a room already exists");
        var roomDto = new RoomDto()
        {
            Block = 710,
            BlockCode = "b",
            RepairDate = DateTime.Now.AddYears(-5),
            RoomRating = 90
        };

        // Act
        var result = await handler.Handle(
            new CreateRoomCommand() { RoomDto = roomDto }, CancellationToken.None);

        // Assert
        Assert.Equal(
            expectedResult.Error, result.Error);
    }
}