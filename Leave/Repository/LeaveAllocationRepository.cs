using Leave.Contracts;
using Leave.Data;

namespace Leave.Repository
{
    public class LeaveAllocationRepository : ILeaveAloocationRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveAllocationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(Leave_allocation entity)
        {
            _db.Leave_Allocations.Add(entity);
            return Save();

        }

        public bool Delete(Leave_allocation entity)
        {
            _db.Leave_Allocations.Remove(entity);
            return Save();
        }

        public ICollection<Leave_allocation> FindAll()
        {
            return _db.Leave_Allocations.ToList();
        }

        public Leave_allocation FindById(int id)
        {
            return _db.Leave_Allocations.Find(id);//there is also aother way  _db.Leave_Allocations.FirstOrDefault()
            //possible to return null
        }

        public ICollection<Leave_allocation> GetEmployeeByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExists(int id)
        {
            var exist = _db.Leave_Allocations.Any(q=> q.Id==id);
            return exist;
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;             //how many records changed or saved
        }

        public bool Update(Leave_allocation entity)
        {
            _db.Leave_Allocations.Update(entity);
            return Save();
        }
    }
}
