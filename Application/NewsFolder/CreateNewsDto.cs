using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.NewsFolder;

public class CreateNewsDto : IMapWith<News>
{
    public Guid? Id { get; set; }
    public DateTime? CreateDate { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid CreatedUserId { get; set; }
    public List<string>? PhotoIds { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateNewsDto, News>();
    }
}