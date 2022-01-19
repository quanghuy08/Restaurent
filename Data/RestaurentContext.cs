#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurent.Models;
using Restaurent.Views.Home;

namespace Restaurent.Data
{
    public class RestaurentContext : DbContext
    {
        public RestaurentContext (DbContextOptions<RestaurentContext> options)
            : base(options)
        {
        }

        public DbSet<Restaurent.Models.AdminAccount> AdminAccount { get; set; }

        public DbSet<Restaurent.Models.BookATable> BookATable { get; set; }

        public DbSet<Restaurent.Views.Home.Feedback> Feedback { get; set; }

        public DbSet<Restaurent.Models.UserAccount> UserAccount { get; set; }
    }
}
