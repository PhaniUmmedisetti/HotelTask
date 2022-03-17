using Microsoft.AspNetCore.Mvc;
using hotel.Models;
using hotel.Repositories;
using hotel.DTOs;

namespace hotel.Controllers;

[ApiController]
[Route("api/room")]
public class RoomController : ControllerBase
{
    private readonly ILogger<RoomController> _logger;
    private readonly IRoomRepository _room;
    private readonly IStaffRepository _staff;

    public RoomController(ILogger<RoomController> logger, IRoomRepository _room, IStaffRepository staff)
    {
        _logger = logger;
        this._room = _room;
        _staff = staff;
    }

    [HttpGet]
    public async Task<ActionResult<List<RoomDTO>>> GetList()
    {
        var res = await _room.GetList();

        return Ok(res.Select(x => x.asDto));
    }


    [HttpGet("{room_id}")]
    public async Task<ActionResult<RoomDTO>> GetById([FromRoute] int room_id)
    {
        var res = await _room.GetById(room_id);

        if (res is null)
            return NotFound();
        var dto = res.asDto;
        dto.Staff = (await _staff.GetListByRoomId(room_id))
                        .Select(x => x.asDto).ToList();

        return Ok(dto);
    }

    [HttpPut("{room_id}")]
    public async Task<ActionResult> Update([FromRoute] int room_id, [FromBody] RoomUpdatedto Data)
    {
        var existingGuest = await _room.GetById(room_id);

        if (existingGuest == null)
            return NotFound();

        var toUpdateGuest = existingGuest with
        {
            Price = Data.price,
        };

        var didUpdate = await _room.Update(toUpdateGuest);

        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError);

        return NoContent();
    }
}