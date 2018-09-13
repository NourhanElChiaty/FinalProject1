using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject1.Models;
using MoviME.Models;

namespace FinalProject1.Controllers
{
    public class ClientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Clients

        public ActionResult Index()
        {
            return View(db.clients.ToList());
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(client clients)
        {
            if (ModelState.IsValid)
            {
                db.clients.Add(clients);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = clients.FirstName + " " + clients.LastName + " Successfuly registed.";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //login
        public ActionResult Login(client client)
        {

            var usr = db.clients.Single(u => u.UserName == client.UserName && u.Password == client.Password);
            if (usr.IsBlocked == false)
            {
                if (usr != null)
                {
                    Session["ID"] = usr.ID.ToString();
                    Session["UserName"] = usr.UserName.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("UserName", "userName and password is Wrong.");
                }
            }
            else
            {
                ModelState.AddModelError("UserName", "this user is blocked.");
            }

            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult LogouT()
        {
            return RedirectToAction("Login");
        }




        public ActionResult Filteration(string SearchingType, string color, string Model, string rentAmount)
        {

            var result = from c in db.cars
                         select c;
            // var result = _context.car.Include(b => b.Type);
            if (!string.IsNullOrEmpty(SearchingType))
            {
                result = db.cars.Where(x => x.CarType.Contains(SearchingType));

            }
            if (!string.IsNullOrEmpty(color))
            {
                result = db.cars.Where(x => x.CarColor == color);

            }
            if (!string.IsNullOrEmpty(Model))
            {
                result = db.cars.Where(x => x.CarModel == Model);

            }
            if (!string.IsNullOrEmpty(rentAmount))
            {
                result = db.cars.Where(x => x.RentAmountOfCar == rentAmount);

            }


            return View(result);

        }



        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(400);
            }
            car car = db.cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        public ActionResult RentCarForm()
        {

            return View();

        }
        [HttpPost]
        public ActionResult RentCarForm(car cars)
        {

            if (cars.Availability == true)
            {

                var car1 = db.cars.Single(a => a.ID == cars.ID);
                car1.From = cars.From;
                car1.To = cars.To;
                Email email = new Email();
                email.sendMail("Car rented");
                db.SaveChanges();
            }
            else
            {
                return RedirectToAction("Filteration");

            }
            return View();
        }
    }
}
        
          
/*                if (cr.Availability == false)
                {

                return View(car);
                }
                else
                {
                return RedirectToAction("RentCarForm");
 
                }
            
 */