using Leave.Contracts;
using Leave.Data;

namespace Leave.Repository
{
    public class LeaveTypeRepository : ILeaveTyperepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(Leave_type entity)
        {
             _db.Leave_types.Add(entity);
            return Save();

        }

        public bool Delete(Leave_type entity)
        {
            _db.Leave_types.Remove(entity);
            return Save();
        }

        public ICollection<Leave_type> FindAll()
        {
            return _db.Leave_types.ToList();
        }

        public Leave_type FindById(int id)
        {
           return _db.Leave_types.Find(id);//there is also aother way  _db.Leave_types.FirstOrDefault()
            //possible to return null
        }

        public ICollection<Leave_type> GetEmployeeByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExists(int id)
        {
            var exist = _db.Leave_types.Any(q=>q.Id == id);
            return exist;
        }

        public bool Save()
        {
            return _db.SaveChanges()>0;             //how many records changed or saved
        }

        public bool Update(Leave_type entity)
        {
            _db.Leave_types.Update(entity);
            return Save();
        }
    }
}
