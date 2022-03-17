
using hotel.DTOs;

namespace hotel.Models;

public enum Gender
{
    Female = 1,
    Male = 2,
}

public record Guest
{
    public int GuestId { get; set; }

    public string Name { get; set; }

    public long Mobile { get; set; }
    public string Email { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    public string Address { get; set; }
    public Gender Gender { get; set; }

    public GuestDTO asDto => new GuestDTO
    {
        GuestId = GuestId,
        Name = Name,
        Mobile = Mobile,
        Email = Email,
    };
}
