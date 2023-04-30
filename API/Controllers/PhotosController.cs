using Application.Photos.Command.Create;
using Application.Photos.Command.Delete;
using Application.Photos.Queries.Get;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class PhotosController : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] IFormFile photo)
    {
        return HandleResult(await Mediator.Send(new CreatePhotoCommand{File = photo}));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeletePhotoCommand{Id = id}));
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await Mediator.Send(new GetPhotoQuery { Id = id });

        if (result.IsSuccess)
            return File(result.Value, "image/jpeg");
        
        return NotFound();
    }
}