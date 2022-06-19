using Leave.Data;

namespace Leave.Contracts
{
    public interface ILeaveTyperepository : IRepositoryBase<Leave_type>
    {
        ICollection<Leave_type> GetEmployeeByLeaveType(int id);


    }
}
