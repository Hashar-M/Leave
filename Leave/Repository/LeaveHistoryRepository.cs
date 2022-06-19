using Leave.Contracts;
using Leave.Data;

namespace Leave.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveHistoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(Leave_history entity)
        {
            _db.Leave_histories.Add(entity);
            return Save();

        }

        public bool Delete(Leave_history entity)
        {
            _db.Leave_histories.Remove(entity);
            return Save();
        }

        public ICollection<Leave_history> FindAll()
        {
            return _db.Leave_histories.ToList();
        }

        public Leave_history FindById(int id)
        {
            return _db.Leave_histories.Find(id);//there is also aother way  _db.Leave_histories.FirstOrDefault()
            //possible to return null
        }

        public ICollection<Leave_history> GetEmployeeByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExists(int id)
        {
            var exist = _db.Leave_histories.Any(q => q.Id == id);
            return exist;
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;             //how many records changed or saved
        }

        public bool Update(Leave_history entity)
        {
            _db.Leave_histories.Update(entity);
            return Save();
        }
    }
}
