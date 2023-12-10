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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Borrowing)
                .WithOne(b => b.Book)
                .HasForeignKey<Borrowing>(b => b.BookID);

            // Add other configurations as needed
        }
        public DbSet<Tudora_Dragos_Lab2.Models.Member>? Member { get; set; }
        public DbSet<Tudora_Dragos_Lab2.Models.Borrowing>? Borrowing { get; set; }
    }
}
