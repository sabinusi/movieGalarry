using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class EmployeController : Controller
    {
        // GET: Employe
        public ActionResult Index()
        {
            return View();
        }
        public string User(string username,string password)
        {
            user us = new user();
            var m = us.ReturnUsers().Where(a => a.username == username && a.password == password).FirstOrDefault();
            HttpCookie ck = new HttpCookie("user", m.Id.ToString());
            ck.Expires.AddDays(10);
            HttpContext.Response.SetCookie(ck);
            HttpCookie rck = Request.Cookies["user"];
            return rck.Value;

        }
        public ActionResult Getdata()
        {
            using (DBmodels dbm = new DBmodels())
            {
                List<Employe> lem = dbm.Employes.ToList();
                return Json(new { data = lem }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult Save(int id)
        {
            using (DBmodels dm = new DBmodels())
            {
                var emp = dm.Employes.Where(a => a.EmployeID == id).FirstOrDefault();
                return View(emp);
            }
        }

        [HttpPost]
        public ActionResult Save(Employe emp)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (DBmodels dm = new DBmodels())
                {
                    if (emp.EmployeID > 0)
                    {
                        var v = dm.Employes.Where(a => a.EmployeID == emp.EmployeID).FirstOrDefault();
                        if (v != null)
                        {
                            //edit
                            v.Name = emp.Name;
                            v.Office = emp.Office;
                            v.Position = emp.Position;
                            v.Age = emp.Age;
                            v.Salary = emp.Salary;
                        }
                    }
                    else
                    {
                        dm.Employes.Add(emp);
                    }
                    dm.SaveChanges();
                    status = true;

                }

            }
            return Json(new { status = status });
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (DBmodels db = new DBmodels())
            {
                var v = db.Employes.Where(a => a.EmployeID == id).FirstOrDefault();
                if(v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteEmplyee(int id)
        {
            bool status = false;
            using(DBmodels dm= new DBmodels())
            {
                var v = dm.Employes.Where(a => a.EmployeID == id).FirstOrDefault();
                if(v != null)
                {
                    dm.Employes.Remove(v);
                    dm.SaveChanges();
                    status = true;
                }
            }
            return Json(new { status = status });
        }
            
    }
}
