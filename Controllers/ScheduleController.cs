using Microsoft.AspNetCore.Mvc;
using hotel.Models;
using hotel.Repositories;
using hotel.DTOs;

namespace hotel.Controllers;

[ApiController]
[Route("api/schedule")]
public class ScheduleController : ControllerBase
{
    private readonly ILogger<ScheduleController> _logger;

    private readonly IScheduleRepository _schedule;

    private readonly IGuestRepository _guest;

    private readonly IRoomRepository _room;
    public ScheduleController(ILogger<ScheduleController> logger, IScheduleRepository schedule, IGuestRepository guest, IRoomRepository room)
    {
        _logger = logger;

        _schedule = schedule;

        _guest = guest;

        _room = room;
    }

    [HttpGet]
    public async Task<ActionResult<List<ScheduleDTO>>> GetList()
    {
        var res = await _schedule.GetList();

        return Ok(res.Select(x => x.asDto));
    }

    [HttpGet("{schedule_id}")]
    public async Task<ActionResult> GetById([FromRoute] int schedule_id)
    {
        var res = await _schedule.GetById(schedule_id);

        if (res is null)
            return NotFound();

        var dto = res.asDto;
        dto.Guests = (await _guest.GetListByScheduleId(schedule_id)).asDto;

        dto.Rooms = (await _room.GetScheduleRoomId(schedule_id)).asDto;

        return Ok(dto);
    }


    [HttpPost]
    public async Task<ActionResult> Create([FromBody] ScheduleCreatedto Data)
    {
        var toCreateSchedule = new Schedule
        {


            CheckIn = Data.CheckIn.UtcDateTime,
            CheckOut = Data.CheckOut.UtcDateTime,
            GuestCount = Data.GuestCount,
            TotalPrice = Data.TotalPrice,
            CreatedAt = Data.CreatedAt.UtcDateTime,
            GuestId = Data.GuestId,
            RoomId = Data.RoomId,

        };

        var res = await _schedule.Create(toCreateSchedule);

        return StatusCode(StatusCodes.Status201Created, res.asDto);

    }

    [HttpPut("{schedule_id}")]
    public async Task<ActionResult> UpdateUser([FromRoute] int schedule_id,
    [FromBody] ScheduleUpdatedto Data)
    {
        var existing = await _schedule.GetById(schedule_id);
        if (existing is null)
            return NotFound("No user found with given schedule id");

        var toUpdateUser = existing with
        {
            CheckIn = Data.CheckIn.UtcDateTime,
            CheckOut = Data.CheckOut.UtcDateTime,
            GuestCount = Data.GuestCount

        };

        var didUpdate = await _schedule.Update(toUpdateUser);

        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError, "Could not update user");

        return NoContent();
    }


    [HttpDelete("{schedule_id}")]
    public async Task<ActionResult> Delete([FromRoute] int schedule_id)
    {
        var existing = await _schedule.GetById(schedule_id);

        if (existing is null)
            return NotFound("No user found with given schedule id");

        var didDelete = await _schedule.Delete(schedule_id);

        return NoContent();

    }
}