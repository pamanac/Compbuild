using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Compbuild.Models;
using Microsoft.EntityFrameworkCore;


namespace Compbuild.Data{
    public class ApplicationDbContext : DbContext{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Category { get; set; } //Convention is to make this plural (ex. Categories)
    }
}