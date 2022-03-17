using System.Text.Json.Serialization;

namespace hotel.DTOs;

public record RoomDTO
{
    [JsonPropertyName("room_id")]
    public int RoomId { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("size")]
    public int Size { get; set; }

    [JsonPropertyName("price")]
    public double Price { get; set; }


    [JsonPropertyName("staff_name")]
    public string StaffName { get; set; }

    [JsonPropertyName("staff")]
    public List<StaffDTO> Staff { get; set; }
}

public record RoomUpdatedto
{
    [JsonPropertyName("price")]

    public int price { get; set; }
}