using Library_Managment.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Managment.DAL.Context
{
    public class Library_ManagmentDbContext :DbContext
    {
        //Ctor
        public Library_ManagmentDbContext(DbContextOptions<Library_ManagmentDbContext> options) :base(options)
        {
            //Di
            //=> Connection string in appsettings.json
        }
        //Dbset
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        //Override
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Fluent Api
        }
    }
}
