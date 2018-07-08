using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravPense.Models;
using TravPense.Models.DataBaseViewModels;

namespace TravPense.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> // this is the context class (bridge between domain classes and the underlying database)
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }


        /*What is an Entity in Entity Framework? 
         * An entity in Entity Framework is a class in the domain of your application which is included as a DbSet<TEntity> type property in the derived context class. 
         * EF API maps each entity to a table and each property of an entity to a column in the database. 
         */

        public DbSet<TravPense.Models.ApplicationUser> ApplicationUser { get; set; }

        public DbSet<TravPense.Models.DataBaseViewModels.HotelViewModel> HotelViewModel { get; set; }

        public DbSet<TravPense.Models.DataBaseViewModels.ActivityViewModel> ActivityViewModel { get; set; }
    }
}
