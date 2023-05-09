using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Requests.RequestTypes;

public class RequestTypeDto : IMapWith<RequestType>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<RequestTypeDto, RequestType>()
            .ForMember(i => i.Id, opt => opt.Ignore());
        profile.CreateMap<RequestType, RequestTypeDto>();
    }
}