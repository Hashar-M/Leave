using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Leave.Contracts;
using Leave.Controllers;
using AutoMapper;
using Leave.Data;
using Leave.Models;

namespace Leave.Controllers
{
    public class Leave_TypeController : Controller
    {
        private readonly ILeaveTyperepository _repo;
        private readonly IMapper _Mapper;


        public Leave_TypeController(ILeaveTyperepository repo, IMapper Mapper)
        {
            _repo = repo;
            _Mapper = Mapper;
                
        }

        // GET: Leave_TypeController
        public ActionResult Index()
        {
            var leave_typs = _repo.FindAll().ToList();
            var model=_Mapper.Map<List<Leave_type>,List<Leave_type_view_model> >(leave_typs);
            return View(model);
        }

        // GET: Leave_TypeController/Details/5
        public ActionResult Details(int id)     //check actually exist and then show
        {
            if(!_repo.isExists(id))
            {
                return NotFound();
            }
            var Leave_typs = _repo.FindById(id);
            var model = _Mapper.Map<Leave_type_view_model>(Leave_typs);
            return View(model);
        }

        // GET: Leave_TypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Leave_TypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]                          //works after entering the details
        public ActionResult Create(Leave_type_view_model model)
        {
            try
            {
                // checking validation what are criterias?
                if(!ModelState.IsValid)
                {
                    return View(model);
                }

                var leave_typs = _Mapper.Map<Leave_type>(model);            // maping model to leave_type
                leave_typs.Date_created=DateTime.Now;                       // settiing Date_created automatically

                var isSuccess=_repo.Create(leave_typs);                     //checking added or not
                if(!isSuccess)
                {
                    ModelState.AddModelError("", "Something Went Wrong...:( ");     //showing error Format:("key_value","message")
                    return View(model);             //returnig the entered data
                }

                return RedirectToAction(nameof(Index));             // iff all thing gone right go to index (shoe Leave_types)
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...:( ");
                return View();
            }
        }

        // GET: Leave_TypeController/Edit/5
        public ActionResult Edit(int id)
        {
            if(!_repo.isExists(id))
            {
                return NotFound();

            }
            var leave_typs = _repo.FindById(id);
            var model = _Mapper.Map<Leave_type_view_model>(leave_typs);
            return View(model);
        }

        // POST: Leave_TypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Leave_type_view_model model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var leave_typs = _Mapper.Map<Leave_type>(model);
                var isSuccess = _repo.Update(leave_typs);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something Went Wrong...:( ");     //showing error Format:("key_value","message")
                    return View(model);             //returnig the entered data
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...:( ");     //showing error Format:("key_value","message")
                return View(model);
                
            }
        }

        // GET: Leave_TypeController/Delete/5
        public ActionResult Delete(int id)                      //for conformation message
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            else
            {
                var leave_typs = _repo.FindById(id);
                var model = _Mapper.Map<Leave_type_view_model>(leave_typs);
                return View(model);
            }
        }

        // POST: Leave_TypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Leave_type_view_model model)
        {
            try
            {
                var leave_typs = _repo.FindById(id);
                if(leave_typs== null)
                {
                    return NoContent();
                }
                var isSucess = _repo.Delete(leave_typs);
                if(!isSucess)
                {
                    ModelState.AddModelError("","Something went wrong to delete....");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong to delete....");
                return View(model);
            }
        }
    }
}
