using BaseDatos.Models;
using BaseDatos.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BaseDatos.DAL
{
    public class ModelContext : DbContext
    {
        public ModelContext() : base("ModelContext")
        { }

        //public DbSet<Usuario> usuarioList { get; set; }
        //public DbSet<Coche> cocheList { get; set; }
        //public DbSet<Departamento> departamentoList { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Modelo> Modelo { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Coche> Coche { get; set; }
       
        //public DbSet<Join> join { get; set; }
   


        //public System.Data.Entity.DbSet<BaseDatos.Models.ViewModel.Join> join { get; set; }



    }
  
}