using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CopaDoMundo.Models
{
    public class CopaDoMundoContext : DbContext
    {
        public DbSet<Selecao> Selecoes { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }

        public CopaDoMundoContext() : base("CopaDoMundo")
        {

        }
    }
}