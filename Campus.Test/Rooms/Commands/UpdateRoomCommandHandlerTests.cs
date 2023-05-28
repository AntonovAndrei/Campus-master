using Application.Rooms;
using Application.Rooms.Commands.Update;
using Campus.Test.Common;
using Microsoft.EntityFrameworkCore;

namespace Campus.Test.Rooms.Commands;

public class UpdateRoomCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task UpdateNoteCommandHandler_Success()
    {
        // Arrange
        var handler = new UpdateRoomCommandHandler(Context, Mapper);
        var updatedTitle = "new title";
        var roomDto = new RoomDto()
        {
            Id = CampusContextFactory.RoomIdForUpdate ,
            Block = 505,
            BlockCode = "b",
            RepairDate = DateTime.Now.AddYears(-10),
            RoomRating = 100,
            Remarks = "Идеальные студенты, никаких нареканий"
        };
        // Act
        await handler.Handle(new UpdateRoomCommand(){RoomDto = roomDto},CancellationToken.None);

        // Assert
        Assert.NotNull(await Context.Rooms.SingleOrDefaultAsync(room =>
            room.Id == CampusContextFactory.RoomIdForUpdate &&
            room.Remarks == roomDto.Remarks));
    }
}