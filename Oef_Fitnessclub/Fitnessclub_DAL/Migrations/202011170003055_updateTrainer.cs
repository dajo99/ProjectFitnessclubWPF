namespace Fitnessclub_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTrainer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Personen", "IsAdmin");
            RenameColumn(table: "dbo.Personen", name: "IsAdmin1", newName: "IsAdmin");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Personen", name: "IsAdmin", newName: "IsAdmin1");
            AddColumn("dbo.Personen", "IsAdmin", c => c.Boolean());
        }
    }
}
