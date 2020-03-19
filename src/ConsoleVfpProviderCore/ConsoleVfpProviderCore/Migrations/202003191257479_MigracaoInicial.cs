namespace ConsoleVFPCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracaoInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TabelaTestes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TabelaTestes");
        }
    }
}
