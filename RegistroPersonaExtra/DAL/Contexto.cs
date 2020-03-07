using Microsoft.EntityFrameworkCore;
using RegistroPersonaExtra.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroPersonaExtra.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Personas> personas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Registro.db");
        }
    }
}
