namespace CodingCraftHOMod1Ex1EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao200 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.AspNetUsers", "TermoPesquisa", c => c.String());
            Sql("ALTER TABLE dbo.AspNetUsers ADD TermoPesquisa AS UserName + ', ' + Email");
        }
        
        public override void Down()
        {
            //DropColumn("dbo.AspNetUsers", "TermoPesquisa");
            Sql("ALTER TABLE dbo.AspNetUsers drop column TermoPesquisa");
        }
    }
}
