using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaWebClase.Areas.Categoria.Models;
using SistemaWebClase.Areas.Curso.Models;
using SistemaWebClase.Areas.Trabajadores.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaWebClase.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TbCategoria> tbCategorias { get; set; }
        public DbSet<tbCurso> tbCursos { get; set; }
        public DbSet<tbTrabajador> tbTrabajadors { get; set; }
    }
}