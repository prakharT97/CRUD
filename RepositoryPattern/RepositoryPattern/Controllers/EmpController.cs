using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepositoryPattern.Repository;
using RepositoryPattern.Models;

namespace RepositoryPattern.Controllers
{
    public class EmpController : Controller
    {
        private Iemployee iemp;
       

        public EmpController(Iemployee iemp) {
            
            this.iemp = iemp;

        }
        // GET: Emp
        public ActionResult Index()
        {
            var emplist = iemp.getStudent().ToList();
            return View(emplist);
        }

        // GET: Emp/Details/5
        public ActionResult Details(int id)
        {
            var getemp = iemp.getStudentByID(id);
            var empdisplay = new student();
            empdisplay.id = getemp.id;
            empdisplay.name = getemp.name;
            empdisplay.gender = getemp.gender;
            empdisplay.age = getemp.age;
            empdisplay.standar = getemp.standar;
            return View(empdisplay);
        }

        // GET: Emp/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new student());
        }

        // POST: Emp/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, student empinsert)
        {
            try
            {
                // TODO: Add insert logic here
                var addemp = new student();
                addemp.name = empinsert.name;
                addemp.gender = empinsert.gender;
                addemp.age = empinsert.age;
                addemp.standar = empinsert.standar;
                iemp.InsertEmpRecord(addemp);
                Session["message"] = "Student "+empinsert.name +" record created";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Emp/Edit/5
        public ActionResult Edit(int id)
        {
            var getemp = iemp.getStudentByID(id);
            var empdisplay = new student();           
            empdisplay.name = getemp.name;
            empdisplay.gender = getemp.gender;
            empdisplay.age = getemp.age;
            empdisplay.standar = getemp.standar;
            return View(empdisplay);
        }

        // POST: Emp/Edit/5
        [HttpPost]
        public ActionResult Edit(student empupdate, FormCollection collection)
        {
            try
            {

                iemp.updateStudent(empupdate);
                Session["message"] = "Student " + empupdate.name+ " record edited";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Emp/Delete/5
        public ActionResult Delete(int id)
        {
            var empdel = iemp.getStudentByID(id);
            return View(empdel);
        }

        // POST: Emp/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                iemp.deleteStudent(id);
                Session["message"] = "Student id = " + id + " record deleted";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
