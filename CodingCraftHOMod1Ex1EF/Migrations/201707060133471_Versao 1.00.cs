namespace CodingCraftHOMod1Ex1EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao100 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Produtos", "TermoPesquisa", c => c.String());
            Sql("ALTER TABLE dbo.Produtos ADD TermoPesquisa AS Nome + ', ' + Descricao");
      
        }


        public override void Down()
        {
            //DropColumn("dbo.Produtos", "TermoPesquisa");
            Sql("ALTER TABLE dbo.Produtos drop column TermoPesquisa");

        }
    }
}
