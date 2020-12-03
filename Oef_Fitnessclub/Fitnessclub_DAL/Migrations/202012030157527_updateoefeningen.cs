namespace Fitnessclub_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateoefeningen : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Log_Oefeningen", "OefeningID", "dbo.Oefeningen");
            DropIndex("dbo.Log_Oefeningen", new[] { "OefeningID" });
            RenameColumn(table: "dbo.Log_Oefeningen", name: "OefeningID", newName: "Oefening_OefeningID");
            AddColumn("dbo.Oefeningen", "Log_Oefening_Log_OefeningID", c => c.Int());
            AlterColumn("dbo.Log_Oefeningen", "Oefening_OefeningID", c => c.Int());
            CreateIndex("dbo.Log_Oefeningen", "Oefening_OefeningID");
            CreateIndex("dbo.Oefeningen", "Log_Oefening_Log_OefeningID");
            AddForeignKey("dbo.Oefeningen", "Log_Oefening_Log_OefeningID", "dbo.Log_Oefeningen", "Log_OefeningID");
            AddForeignKey("dbo.Log_Oefeningen", "Oefening_OefeningID", "dbo.Oefeningen", "OefeningID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Log_Oefeningen", "Oefening_OefeningID", "dbo.Oefeningen");
            DropForeignKey("dbo.Oefeningen", "Log_Oefening_Log_OefeningID", "dbo.Log_Oefeningen");
            DropIndex("dbo.Oefeningen", new[] { "Log_Oefening_Log_OefeningID" });
            DropIndex("dbo.Log_Oefeningen", new[] { "Oefening_OefeningID" });
            AlterColumn("dbo.Log_Oefeningen", "Oefening_OefeningID", c => c.Int(nullable: false));
            DropColumn("dbo.Oefeningen", "Log_Oefening_Log_OefeningID");
            RenameColumn(table: "dbo.Log_Oefeningen", name: "Oefening_OefeningID", newName: "OefeningID");
            CreateIndex("dbo.Log_Oefeningen", "OefeningID");
            AddForeignKey("dbo.Log_Oefeningen", "OefeningID", "dbo.Oefeningen", "OefeningID", cascadeDelete: true);
        }
    }
}
