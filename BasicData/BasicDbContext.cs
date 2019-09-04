using BasicCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData
{
    public class BasicDbContext : DbContext
    {
        public BasicDbContext(DbContextOptions<BasicDbContext> options)
            : base(options)
        {

        }

        public DbSet<Restaurante> restaurantes { get; set; }
    }
}
