using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models;

    public class StoreContext : DbContext
    {
        public StoreContext (DbContextOptions<StoreContext> options)
            : base(options)
        {
        }

        public DbSet<BackEnd.Models.Product> Products { get; set; } = default!;
        public DbSet<BackEnd.Models.Order> Orders { get; set; } = default!;
        public DbSet<BackEnd.Models.Cart> Carts { get; set; } = default!;
    }
