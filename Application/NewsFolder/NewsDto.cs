﻿using Application.Common.Mappings;
using Application.Users.Employees;
using AutoMapper;
using Domain;
using Domain.Entities;

namespace Application.NewsFolder;

public class NewsDto : IMapWith<News>
{
    public Guid? Id { get; set; }
    public DateTime? CreateDate { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public LookupEmployeeDto CreatedBy { get; set; }
    public List<string>? PhotoIds { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<News, News>();
        profile.CreateMap<NewsDto, News>().
            ForMember(d=>d.PhotoIds,opt => opt.Ignore());
        profile.CreateMap<News, NewsDto>();
    }
}