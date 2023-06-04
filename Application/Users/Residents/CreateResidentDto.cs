using Application.Users.CommonDtos;
using AutoMapper;
using Domain;
using Domain.Entities;

namespace Application.Users.Residents;

public class CreateResidentDto : UpdateResidentDto
{
    public string Password { get; set; }
}