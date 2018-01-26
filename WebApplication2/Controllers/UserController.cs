using DataAccess.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        protected IUserRepo UserRepo;
        public UserController(IUserRepo _UserRepo)
        {
            UserRepo = _UserRepo;
        }

        // GET: User
        public ActionResult Index()
        {
            IList<Model.User> lstUser = UserRepo.GetAll();
            return View(lstUser);
        }

        // GET: User/Details/5
        public ActionResult Details(string id)
        {
            Model.User User = UserRepo.GetBy(x => x.ID == id);
            return View(User);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(Model.User collection)
        {
            try
            {
                // TODO: Add insert logic here
                UserRepo.BeginTransaction();
                UserRepo.Save(collection);
                UserRepo.Commit();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(string id)
        {
            Model.User User = UserRepo.GetBy(x => x.ID == id);
            return View(User);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Model.User collection)
        {
            try
            {
                // TODO: Add update logic here
                Model.User User = UserRepo.GetBy(x => x.ID == id);
                User.Name = collection.Name;
                User.Username = collection.Username;
                UserRepo.BeginTransaction();
                UserRepo.Update(User);
                UserRepo.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(string id)
        {
            Model.User User = UserRepo.GetBy(x => x.ID == id);
            return View(User);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, Model.User collection)
        {
            try
            {
                // TODO: Add delete logic here
                Model.User User = UserRepo.GetBy(x => x.ID == id);
                UserRepo.BeginTransaction();
                UserRepo.Delete(User);
                UserRepo.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
