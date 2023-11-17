using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tudora_Dragos_Lab2.Models;

namespace Tudora_Dragos_Lab2.Data
{
    public class Tudora_Dragos_Lab2Context : DbContext
    {
        public Tudora_Dragos_Lab2Context (DbContextOptions<Tudora_Dragos_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Tudora_Dragos_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Tudora_Dragos_Lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Tudora_Dragos_Lab2.Models.Author>? Author { get; set; }
    }
}
