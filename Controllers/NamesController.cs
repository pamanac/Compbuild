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
        public IActionResult Add(Names new_name){
            _db.Names.Add(new_name);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}