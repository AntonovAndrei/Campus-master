using Microsoft.AspNetCore.Http;

namespace Application.Interfaces;

public interface IPhotoAccessor
{
    Task<Guid> AddPhotoAsync(IFormFile file);
    Task<Guid> DeletePhotoAsync(Guid fileId);
    Task<byte[]> GetPhotoAsync(Guid fileId);
    bool IsPhotoExist(string fileId);
}