using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject1.Models;
using System.IO;
using FinalProject1.report;
using MoviME.Models;

namespace FinalProject1.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult IndexUser()
        {
            return View(db.clients.ToList());
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(admin admin)
        {

            var adm = db.admins.Single(u => u.UserName == admin.UserName && u.Password == admin.Password);
            if (adm != null)
            {
                Session["ID"] = adm.ID.ToString();
                Session["UserName"] = adm.UserName.ToString();
                return RedirectToAction("LoggedIn");
            }
            else
            {
                ModelState.AddModelError(" ", "userName and password is Wrong.");
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

        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(client clients)
        {
            db.clients.Add(clients);
            db.SaveChanges();
            
            return RedirectToAction("IndexUser");
        }

        public ActionResult UpdateUser(int id)
        {
            return View(db.clients.Where(c => c.ID.Equals(id)).SingleOrDefault());
        }
        [HttpPost]
        public ActionResult UpdateUser(client cl)
        {
            db.Entry<client>(cl).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("IndexUSer");
        }

        public ActionResult Delete(int id)
        {
            var cl = db.clients.Where(c => c.ID.Equals(id)).SingleOrDefault();
            db.clients.Remove(cl);
            db.SaveChanges();
            return RedirectToAction("IndexUser");
        }


        public ActionResult IndexCar()
        {
            return View(db.cars.ToList());
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

        public ActionResult AddCar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCar(car cars, HttpPostedFileBase upload)
        {
            String path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
            upload.SaveAs(path);
            cars.CarImage = upload.FileName;
            db.cars.Add(cars);
            Email email = new Email();
            email.sendMail("Your favourite Car is Added");
            db.SaveChanges();
            

            
            
            return RedirectToAction("IndexCar");
        }

        public ActionResult UpdateImage(int id)
        {
            return View(db.cars.Where(c => c.ID.Equals(id)).SingleOrDefault());
        }
        [HttpPost]
        public ActionResult UpdateImage(car cars, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                String path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                upload.SaveAs(path);
                cars.CarImage = upload.FileName;
                var car1 = db.cars.Single(a => a.ID == cars.ID);
                car1.CarImage = cars.CarImage;
                db.SaveChanges();

                return RedirectToAction("IndexCar");
            }

            return View();
        }


        public ActionResult UpdateCar(int id)
        {
            return View(db.cars.Where(c => c.ID.Equals(id)).SingleOrDefault());
        }
        [HttpPost]
        public ActionResult UpdateCar(car cars)
        {
            db.Entry<car>(cars).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("IndexCar");
        }

        public ActionResult DeleteCar(int id)
        {
            var car = db.cars.Where(c => c.ID.Equals(id)).SingleOrDefault();
            db.cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("IndexCar");
        }

        public ActionResult Report()
        {
            return View(db.cars.ToList());
        }
        public ActionResult report_pdf(car car)
        {
            carreport Car_report = new carreport();
            byte[] abytes = Car_report.PrepareReport(db.cars.ToList());
            return File(abytes, "application/pdf");
        }
      
    }
}