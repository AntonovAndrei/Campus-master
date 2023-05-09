using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Requests;

public class CreateRequestDto : IMapWith<Request>
{
    public Guid? Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public Guid TypeId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<RequestDto, Request>();
    }
}