using System.Net.Mime;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Photos;

public class PhotoAccessor : IPhotoAccessor
{
    //отрефакторить введение логов и обработки ошибок
    private readonly string _folderPath = Directory.GetParent(Environment.CurrentDirectory).FullName + "/savedPhotos";
    private readonly ILogger<PhotoAccessor> _logger;

    public PhotoAccessor(ILogger<PhotoAccessor> logger)
    {
        if (!Directory.Exists(_folderPath))
            Directory.CreateDirectory(_folderPath);

        _logger = logger;
    }

    public async Task<Guid> AddPhotoAsync(IFormFile file)
    {
        if (file.Length <= 0) 
            return Guid.Empty;

        try
        {
            Guid fileId = Guid.NewGuid();
            string filePath = Path.Combine(_folderPath, fileId + ".jpeg");
            using (Stream fileStream = new FileStream(filePath, FileMode.Create)) {
                await file.CopyToAsync(fileStream);
            }
            
            return fileId;
        }
        catch(IOException ex)
        {
            _logger.LogError(ex.ToString());
            throw ex;
        }
    }

    public async Task<Guid> DeletePhotoAsync(Guid fileId)
    {
        try
        {
            File.Delete(Path.Combine(_folderPath, fileId + ".jpeg"));
            return fileId;
        }
        catch (IOException ex)
        {
            _logger.LogError(ex.ToString());
            throw ex;
        }
    }

    public async Task<byte[]> GetPhotoAsync(Guid fileId)
    {
        string filePath = Path.Combine(_folderPath, fileId + ".jpeg");
        try
        {
            return File.ReadAllBytes(filePath);
        }
        catch (IOException ex)
        {
            _logger.LogError(ex.ToString());
            throw ex;
        }
    }

    public bool IsPhotoExist(string fileId)
    {
        return File.Exists(Path.Combine(_folderPath, fileId + ".jpeg"));
    }
}