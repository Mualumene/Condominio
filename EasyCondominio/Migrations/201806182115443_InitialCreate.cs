namespace EasyCondominio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blocoes",
                c => new
                    {
                        BlocoId = c.Int(nullable: false, identity: true),
                        NumBloco = c.String(),
                        QtdAptos = c.Int(nullable: false),
                        AreaTotal = c.Single(nullable: false),
                        CondominioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BlocoId)
                .ForeignKey("dbo.Condominios", t => t.CondominioId, cascadeDelete: true)
                .Index(t => t.CondominioId);
            
            CreateTable(
                "dbo.Condominios",
                c => new
                    {
                        CondominioId = c.Int(nullable: false, identity: true),
                        NomeCondominio = c.String(),
                        NumeroBlocos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CondominioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blocoes", "CondominioId", "dbo.Condominios");
            DropIndex("dbo.Blocoes", new[] { "CondominioId" });
            DropTable("dbo.Condominios");
            DropTable("dbo.Blocoes");
        }
    }
}
