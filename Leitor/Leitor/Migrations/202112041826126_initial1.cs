namespace Leitor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Livroes",
                c => new
                    {
                        LivroId = c.Long(nullable: false, identity: true),
                        Nome_Autor = c.String(),
                        Nome_Livro = c.String(),
                    })
                .PrimaryKey(t => t.LivroId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Livroes");
        }
    }
}
