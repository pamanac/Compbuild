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
    public class ComputersController : Controller{
        private readonly ApplicationDbContext _db;

        public ComputersController(ApplicationDbContext db){
            _db = db;
        }

        public IActionResult Index(){
            IEnumerable<Computers> objList = _db.Computers;
            ViewBag.numberOfProducts = objList.Count();
            return View(objList);
        }

        [HttpGet]
        public IActionResult Details(int? ID){
            if(ID == null || ID == 0)
                return NotFound();
            var obj = _db.Computers.Find(ID); //obj_ID is primary key
            if(obj==null)
                return NotFound();
            return View(obj);
        }

        

    }
}