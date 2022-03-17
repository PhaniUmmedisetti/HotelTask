using hotel.DTOs;

namespace hotel.Models;

public record Schedule
{
    public int ScheduleId { get; set; }
    public DateTimeOffset CheckIn { get; set; }
    public DateTimeOffset CheckOut { get; set; }
    public int GuestCount { get; set; }
    public double TotalPrice { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public int GuestId { get; set; }
    public int RoomId { get; set; }

    public ScheduleDTO asDto => new ScheduleDTO
    {
        ScheduleId = ScheduleId,
        TotalPrice = TotalPrice,
        GuestCount = GuestCount,
        CheckIn = CheckIn,
        CheckOut = CheckOut,
    };
}