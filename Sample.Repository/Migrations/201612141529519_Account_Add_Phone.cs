namespace Sample.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Account_Add_Phone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Account", "Phone", c => c.String(nullable: false, maxLength: 32));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Account", "Phone");
        }
    }
}
