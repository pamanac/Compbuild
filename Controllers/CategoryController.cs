using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Compbuild.Models;
using Compbuild.Data;

namespace Compbuild.Controllers{
    public class CategoryController : Controller{
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db){
            _db = db;
        }
        public IActionResult Index(){
            IEnumerable<Category> objList = _db.Category;
            return View(objList);
        }

        public IActionResult Create(){ 
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj){
            if(ModelState.IsValid){
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int? ID){
            if(ID == null || ID == 0)
                return NotFound();
            var obj = _db.Category.Find(ID); //obj_ID is primary key
            if(obj==null)
                return NotFound();
            return View(obj);
        }

        
        public IActionResult Edit(Category obj){
            if(ModelState.IsValid){
                _db.Category.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        [HttpGet]
        public IActionResult Delete(int? ID){
            if(ID == null || ID == 0)
                return NotFound();
            var obj = _db.Category.Find(ID); //obj_ID is primary key
            if(obj==null)
                return NotFound();
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? ID){
            var obj = _db.Category.Find(ID);
            if(obj == null)
                return NotFound();
            _db.Category.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}