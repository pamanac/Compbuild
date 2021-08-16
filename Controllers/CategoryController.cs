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
    }
}