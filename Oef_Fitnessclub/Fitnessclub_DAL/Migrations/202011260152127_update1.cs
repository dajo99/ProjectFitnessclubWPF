namespace Fitnessclub_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Persoons", "Licentiecode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Persoons", "Licentiecode", c => c.String());
        }
    }
}
