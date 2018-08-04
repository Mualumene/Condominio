namespace EasyCondominio.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EasyCondominio.Contexto.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

            //Esta configuração, se habilitada, faz com que os dados possam ser perdidos durante a atualização. Página 135
            AutomaticMigrationDataLossAllowed = true;

            ContextKey = "EasyCondominio.Contexto.EFContext";
        }

        protected override void Seed(EasyCondominio.Contexto.EFContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
