using hotel.DTOs;
namespace hotel.Models;

public enum RoomType
{
    Regular = 1,
    Double = 2,
    Suite = 3,
    deluxSuite = 4,
}

public record Room
{
    public int RoomId { get; set; }
    public RoomType Type { get; set; }
    public int Size { get; set; }
    public double Price { get; set; }
    public int StaffId { get; set; }
    public string StaffName { get; set; }

    public RoomDTO asDto => new RoomDTO
    {
        RoomId = RoomId,
        StaffName = StaffName,
        Type = Type.ToString(),
        Size = Size,
    };
}