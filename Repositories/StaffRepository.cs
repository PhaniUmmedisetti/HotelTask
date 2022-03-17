
using Dapper;
using hotel.Models;
using hotel.Utilities;

namespace hotel.Repositories;

public interface IStaffRepository
{
    Task<Staff> Create(Staff Item);
    Task<bool> Update(Staff Item);
    Task<bool> Delete(int StaffId);
    Task<List<Staff>> GetList();
    Task<Staff> GetById(int StaffId);
    Task<List<Staff>> GetListByRoomId(int StaffId);
}

public class StaffRepository : BaseRepository, IStaffRepository
{
    public StaffRepository(IConfiguration config) : base(config)
    {

    }

    public async Task<Staff> Create(Staff Item)
    {
        var query = $@"INSERT INTO {TableNames.staff} 
        (name, date_of_birth, gender,mobile,shift) 
        VALUES (@Name,@DateOfBirth,@Gender,@Mobile,@Shift) 
        RETURNING *";

        using (var con = NewConnection)
            return await con.QuerySingleAsync<Staff>(query, Item);
    }

    public async Task<bool> Delete(int StaffId)
    {
        var query = $@"DELETE FROM {TableNames.staff} WHERE staff_id = @StaffId";

        using (var con = NewConnection)
            return await con.ExecuteAsync(query, new { StaffId }) > 0;
    }

    public async Task<List<Staff>> GetList()
    {
        var query = $@"SELECT * FROM {TableNames.staff}";

        using (var con = NewConnection)
            return (await con.QueryAsync<Staff>(query)).AsList();

    }

    public async Task<Staff> GetById(int StaffId)
    {
        var query = $@"SELECT * FROM {TableNames.staff} WHERE staff_id = @StaffId";

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Staff>(query, new { StaffId });
    }

    public async Task<bool> Update(Staff Item)
    {
        var query = $@"UPDATE ""{TableNames.staff}"" SET mobile=@Mobile, 
        shift=@Shift WHERE staff_id = @StaffId";


        using (var con = NewConnection)
        {
            var rowCount = await con.ExecuteAsync(query, Item);

            return rowCount == 1;
        }
    }

    public async Task<List<Staff>> GetListByRoomId(int StaffId)
    {
        var query = $@"SELECT * FROM ""{TableNames.staff}"" WHERE staff_id = @Staffid";
        using (var con = NewConnection)
            return (await con.QueryAsync<Staff>(query, new { StaffId })).AsList();


    }
}