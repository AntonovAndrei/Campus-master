using Application.Common.Mappings;
using Application.Requests.RequestTypes;
using Application.Users.Employees;
using Application.Users.Residents;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.Requests;

public class RequestDto : IMapWith<Request>
{
    public Guid? Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ClosedDate { get; set; }
    public Guid TypeId { get; set; }
    
    public RequestStatus RequestStatus { get; set; }
    public LookupEmployeeDto Employee { get; set; }
    public LookupResidentDto Resident { get; set; }
    public RequestTypeDto RequestType { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Request, RequestDto>()
            .ForMember(r => r.Resident, o => o.MapFrom(s => s.Resident))
            .ForMember(r => r.Employee, o => o.MapFrom(s => s.Employee))
            .ForMember(d => d.RequestType, opt => opt.MapFrom(s => s.Type));
    }
}