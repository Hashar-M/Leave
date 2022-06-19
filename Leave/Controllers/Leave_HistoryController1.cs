using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Leave.Contracts;
using AutoMapper;
using Leave.Data;
using Leave.Models;

namespace Leave.Controllers
{
    public class Leave_HistoryController1 : Controller
    {
        public readonly ILeaveHistoryRepository _repo;
        public readonly IMapper _Mapper;
        public Leave_HistoryController1(ILeaveHistoryRepository repo, IMapper Mapper)
        {
            _repo = repo;
            _Mapper = Mapper;
        }
        // GET: Leave_HistoryController1
        public ActionResult Index()
        {
            var Leave_histry = _repo.FindAll().ToList();
            var model = _Mapper.Map<List<Leave_history>, List<leave_history_view_model>>(Leave_histry);

            return View(model);
        }

        // GET: Leave_HistoryController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Leave_HistoryController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Leave_HistoryController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Leave_HistoryController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Leave_HistoryController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Leave_HistoryController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Leave_HistoryController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
