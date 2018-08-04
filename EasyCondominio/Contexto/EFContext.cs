using EasyCondominio.Migrations;
using EasyCondominio.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EasyCondominio.Contexto
{
    public class EFContext : IdentityDbContext<Usuario>
    {
        public EFContext() : base("DB_EasyCondominio")
        {
            //Aqui diz que se houver alteração no modelo o banco de dados será deletado e criado novamente.
            //Database.SetInitializer<EFContext>(new DropCreateDatabaseIfModelChanges<EFContext>());

            //Este é o inicializador válido após instalação do Migrations. Página 133
            Database.SetInitializer<EFContext>(new MigrateDatabaseToLatestVersion<EFContext, Configuration>());
        }

        //Página 153 do Livro.
        static EFContext()
        {
            Database.SetInitializer<EFContext>(new IdentityDbInit());
        }

        public static EFContext Create()
        {
            return new EFContext();
        }

        public DbSet<Condominio> Condominios { get; set; }
        public DbSet<Bloco> Blocos { get; set; }
        public DbSet<Apartamento> Apartamentos { get; set; }
        public DbSet<Proprietario> Proprietarios { get; set; }
    }

    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<EFContext>
    {
    }
}