using BasicCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData
{
    class BasicDbContext : DbContext
    {
        public DbSet<Restaurante> restaurantes { get; set; }
    }
}
