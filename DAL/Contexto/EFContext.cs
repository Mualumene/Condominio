//using EasyCondominio.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BLL.Models;
using DAL.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DAL.Contexto
{
  public class EFContext : DbContext
  {
    public EFContext() : base("DB_EasyCondominio")
    {
      //Este é o inicializador válido após instalação do Migrations. Página 133
      Database.SetInitializer<EFContext>(new MigrateDatabaseToLatestVersion<EFContext, Configuration>());
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

      modelBuilder.Entity< IdentityUserLogin>().HasKey(c => c.UserId );
      modelBuilder.Entity<IdentityUserRole>().HasKey(IUR => new { IUR.UserId, IUR.RoleId });
    }

    public DbSet<Condominio> Condominios { get; set; }
    public DbSet<Bloco> Blocos { get; set; }
    public DbSet<Apartamento> Apartamentos { get; set; }
    public DbSet<Proprietario> Proprietarios { get; set; }
  }
}