﻿using Microsoft.EntityFrameworkCore;
using MvcPruebExamenCripto.Models;

namespace MvcPruebExamenCripto.Data
{
    public class UsuariosContext : DbContext
    {
        public UsuariosContext(DbContextOptions<UsuariosContext> options) 
            : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
