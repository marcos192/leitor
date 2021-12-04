namespace Leitor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.leitors",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                        Cpf = c.String(),
                        Data_Nascimento = c.String(),
                        Endereco = c.String(),
                        Cep = c.String(),
                        Cidade = c.String(),
                        Uf = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.leitors");
        }
    }
}
