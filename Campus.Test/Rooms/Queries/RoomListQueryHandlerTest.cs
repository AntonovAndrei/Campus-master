using Application.Common;
using Application.Common.Pagination;
using Application.Rooms;
using Application.Rooms.Queries.List;
using Campus.Test.Common;
using Shouldly;

namespace Campus.Test.Rooms.Queries;

public class RoomListQueryHandlerTest : TestCommandBase
{
    [Fact]
    public async Task GetNoteListQueryHandler_Success()
    {
        // Arrange
        var handler = new RoomListQueryHandler(Context, Mapper);

        // Act
        var result = await handler.Handle(
            new RoomListQuery
            {
                Params = new PagingParams()
            },
            CancellationToken.None);

        // Assert
        result.ShouldBeOfType<Result<PagedList<RoomDto>>>();
        result.Value.Count.ShouldBe(4);
    }
}