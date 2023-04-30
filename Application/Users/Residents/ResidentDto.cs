using Application.Users.CommonDtos;

namespace Application.Users.Residents;

public class ResidentDto : UserDto
{
    public string Room { get; set; }
    public string Campus { get; set; }
}