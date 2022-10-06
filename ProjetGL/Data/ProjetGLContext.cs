using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetGL.Models;

    public class ProjetGLContext : DbContext
    {
        public ProjetGLContext (DbContextOptions<ProjetGLContext> options)
            : base(options)
        {
        }

        public DbSet<Equipe> Equipe { get; set; }
        public DbSet<Joueur> Joueur { get; set; }
        public DbSet<Match> Match { get; set; }
        
      
        
        

       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           modelBuilder.Entity<Joueur>().ToTable("Joueur");
           modelBuilder.Entity<Match>().ToTable("Match");
           modelBuilder.Entity<Equipe>().ToTable("Equipe");
           
       }
        

       

       
    }
