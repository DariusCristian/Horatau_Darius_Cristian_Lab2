using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Horatau_Darius_Cristian_Lab2.Models;

namespace Horatau_Darius_Cristian_Lab2.Data
{
    public class Horatau_Darius_Cristian_Lab2Context : DbContext
    {
        public Horatau_Darius_Cristian_Lab2Context (DbContextOptions<Horatau_Darius_Cristian_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Horatau_Darius_Cristian_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Horatau_Darius_Cristian_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Horatau_Darius_Cristian_Lab2.Models.Author> Author { get; set; } = default!;
        public DbSet<Horatau_Darius_Cristian_Lab2.Models.Category> Category { get; set; } = default!;
    }
}
