using Leitor.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Leitor.Context
    {

    public class EFContext : DbContext

        {
            public EFContext() : base("Projeto") { }

            public DbSet<leitor> clientes { get; set; }

            public DbSet<Livro> livros { get; set; }

        }
    }