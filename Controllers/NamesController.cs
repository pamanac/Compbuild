using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Compbuild.Models;
using Compbuild.Data;

namespace Compbuild.Controllers
{
    public class NamesController : Controller {
        private readonly ApplicationDbContext _db;

        public NamesController(ApplicationDbContext db){
            _db = db;
        }

        public IActionResult Index(){
            IEnumerable<Names> names = _db.Names;
            return View(names);
        }

        public IActionResult Add(){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Names new_name){
            _db.Names.Add(new_name);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //edit & delete for names
        //GET EDIT
        [HttpGet]
        public IActionResult Edit(int? ID){
            if(ID == null || ID == 0)
                return NotFound();
            var obj = _db.Names.Find(ID);
            if(obj == null)
                return NotFound();
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Names obj){
            if(ModelState.IsValid){
                _db.Names.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(int? ID){
            if(ID == null || ID == 0)
                return NotFound();
            var obj = _db.Names.Find(ID);
            if(obj == null)
                return NotFound();
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Names obj){
            _db.Names.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}