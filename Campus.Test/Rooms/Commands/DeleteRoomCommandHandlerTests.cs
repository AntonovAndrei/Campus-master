using Application.Common;
using Application.Rooms.Commands.Delete;
using Campus.Test.Common;
using MediatR;

namespace Campus.Test.Rooms.Commands;

public class DeleteRoomCommandHandlerTests  : TestCommandBase
{
    [Fact]
    public async Task DeleteRoomCommandHandler_Success()
    {
        // Arrange
        var handler = new DeleteRoomCommandHandler(Context);

        // Act
        await handler.Handle(new DeleteRoomCommand
        {
            Id = CampusContextFactory.RoomIdForDelete,
        }, CancellationToken.None);

        // Assert
        Assert.Null(Context.Rooms.SingleOrDefault(room =>
            room.Id == CampusContextFactory.RoomIdForDelete));
    }
    
    [Fact]
    public async Task DeleteRoomCommandHandler_FailOnWrongId()
    {
        // Arrange
        var handler = new DeleteRoomCommandHandler(Context);
        var expectedResult = Result<Unit>.Failure("Failed to delete the room");
        
        // Act
        var result = await handler.Handle(
            new DeleteRoomCommand
            {
                Id = Guid.NewGuid(),
            },
            CancellationToken.None);
        
        // Assert
        Assert.Null(result);
    }
}