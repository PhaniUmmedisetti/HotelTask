using Microsoft.AspNetCore.Mvc;
using hotel.Models;
using hotel.Repositories;
using hotel.DTOs;

namespace hotel.Controllers;

[ApiController]
[Route("api/staff")]
public class StaffController : ControllerBase
{
    private readonly ILogger<StaffController> _logger;

    private readonly IStaffRepository _staff;

    private readonly IRoomRepository _room;


    public StaffController(ILogger<StaffController> logger, IStaffRepository staff, IRoomRepository room)
    {
        _logger = logger;
        _staff = staff;
        _room = room;
    }

    [HttpGet]
    public async Task<ActionResult<List<StaffDTO>>> GetList()
    {
        var res = await _staff.GetList();

        return Ok(res.Select(x => x.asDto));
    }

    [HttpGet("{staff_id}")]
    public async Task<ActionResult> GetById([FromRoute] int staff_id)
    {
        var res = await _staff.GetById(staff_id);

        if (res is null)
            return NotFound();

        var dto = res.asDto;

        dto.Rooms = (await _room.GetListByStaffId(staff_id)).asDto;

        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] StaffCreatedto Data)
    {
        var toCreateStaff = new Staff
        {


            Name = Data.Name,
            DateOfBirth = Data.DateOfBirth,
            Gender = Data.Gender,
            Mobile = Data.Mobile,
            Shift = Data.Shift,

        };

        var res = await _staff.Create(toCreateStaff);

        return StatusCode(StatusCodes.Status201Created, res.asDto);

    }




    [HttpPut("{staff_id}")]
    public async Task<ActionResult> UpdateUser([FromRoute] int staff_id,
    [FromBody] StaffUpdatedto Data)
    {
        var existing = await _staff.GetById(staff_id);
        if (existing is null)
            return NotFound("No user found with given schedule id");

        var toUpdateUser = existing with
        {

            Mobile = Data.Mobile,
            Shift = Data.Shift

        };

        var didUpdate = await _staff.Update(toUpdateUser);

        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError, "Could not update user");

        return NoContent();
    }


    [HttpDelete("{staff_id}")]
    public async Task<ActionResult> Delete([FromRoute] int staff_id)
    {
        var existing = await _staff.GetById(staff_id);

        if (existing is null)
            return NotFound("No user found with given staff id");

        var didDelete = await _staff.Delete(staff_id);

        return NoContent();

    }

}