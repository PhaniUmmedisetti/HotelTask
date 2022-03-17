using Dapper;
using hotel.Models;
using hotel.Utilities;

namespace hotel.Repositories;

public interface IScheduleRepository
{
    Task<Schedule> Create(Schedule Item);
    Task<bool> Update(Schedule Item);
    Task<bool> Delete(int ScheduleId);
    Task<List<Schedule>> GetList();
    Task<Schedule> GetById(int ScheduleId);
    Task<List<Schedule>> GetListByGuestId(int GuestId);
}

public class ScheduleRepository : BaseRepository, IScheduleRepository
{
    public ScheduleRepository(IConfiguration config) : base(config)
    {

    }

    public async Task<Schedule> Create(Schedule Item)
    {
        var query = $@"INSERT INTO {TableNames.schedule} 
        (check_in, check_out, guest_count, total_price,created_at,guest_id,room_id) 
        VALUES (@CheckIn, @CheckOut, @GuestCount, @TotalPrice, @CreatedAt, @GuestId, @RoomId) 
        RETURNING *";


        using (var con = NewConnection)
            return await con.QuerySingleAsync<Schedule>(query, Item);
    }

    public async Task<bool> Delete(int ScheduleId)
    {
        var query = $@"DELETE FROM {TableNames.schedule} WHERE schedule_id = @ScheduleId";

        using (var con = NewConnection)
            return await con.ExecuteAsync(query, new { ScheduleId }) > 0;
    }

    public async Task<Schedule> GetById(int ScheduleId)
    {
        var query = $@"SELECT * FROM {TableNames.schedule} WHERE schedule_id = @ScheduleId";

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Schedule>(query, new { ScheduleId });
    }

    public async Task<List<Schedule>> GetList()
    {
        var query = $@"SELECT * FROM {TableNames.schedule}";

        using (var con = NewConnection)
            return (await con.QueryAsync<Schedule>(query)).AsList();
    }

    public async Task<List<Schedule>> GetListByGuestId(int GuestId)
    {
        var query = $@"SELECT * FROM {TableNames.schedule} 
        WHERE guest_id = @GuestId";

        using (var con = NewConnection)
            return (await con.QueryAsync<Schedule>(query, new { GuestId })).AsList();
    }

    public async Task<bool> Update(Schedule Item)
    {
        var query = $@"UPDATE ""{TableNames.schedule}"" SET id = @Id, 
        check_in = @CheckIn,check_out = @CheckOut,guest_count = @GuestCount,total_price = @TotalPrice, 
        created_at=@CreatedAt,guest_id = @GuestId WHERE schedule_id = @ScheduleId";


        using (var con = NewConnection)
        {
            var rowCount = await con.ExecuteAsync(query, Item);

            return rowCount == 1;
        }
    }
}

