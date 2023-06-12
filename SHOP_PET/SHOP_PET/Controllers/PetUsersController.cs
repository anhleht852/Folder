using SHOP_PET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SHOP_PET.Controllers
{
    public class PetUsersController : Controller
    {
        dbPetDataContext db = new dbPetDataContext();
        // GET: PetUsers
        public ActionResult Index()
        {
            var D_pet = from r in db.Pets select r;
            return View(D_pet);
        }
        public ActionResult Details(int id)
        {
            var st = db.Pets.Where(s => s.mapet == id).First();
            return View(st);
        }
    }
}