using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GongChaWebAPI.Models;

namespace GongChaWebAPI.Data
{
    public class GongChaWebAPIContext : DbContext
    {
        public GongChaWebAPIContext (DbContextOptions<GongChaWebAPIContext> options)
            : base(options)
        {
        }
        //When add a new table, add an copy of following code and replace the name of table by the name of new table
        public DbSet<GongChaWebAPI.Models.Product> Product { get; set; } = default!;
        public DbSet<GongChaWebAPI.Models.ProductTypeSize> ProductTypeSize { get; set; } = default!;
        public DbSet<GongChaWebAPI.Models.Category> Category { get; set; } = default!;
        public DbSet<GongChaWebAPI.Models.Size> Size { get; set; } = default!;
        public DbSet<GongChaWebAPI.Models.Banner> Banner { get; set; } = default!;
        public DbSet<GongChaWebAPI.Models.Account> Account { get; set; } = default!;
    }
}
