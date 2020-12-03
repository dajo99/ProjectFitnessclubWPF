namespace Fitnessclub_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateoefeningen1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Oefeningen", "Log_Oefening_Log_OefeningID", "dbo.Log_Oefeningen");
            DropForeignKey("dbo.Log_Oefeningen", "Oefening_OefeningID", "dbo.Oefeningen");
            DropIndex("dbo.Log_Oefeningen", new[] { "Oefening_OefeningID" });
            DropIndex("dbo.Oefeningen", new[] { "Log_Oefening_Log_OefeningID" });
            RenameColumn(table: "dbo.Log_Oefeningen", name: "Oefening_OefeningID", newName: "OefeningID");
            AlterColumn("dbo.Log_Oefeningen", "OefeningID", c => c.Int(nullable: false));
            CreateIndex("dbo.Log_Oefeningen", "OefeningID");
            AddForeignKey("dbo.Log_Oefeningen", "OefeningID", "dbo.Oefeningen", "OefeningID", cascadeDelete: true);
            DropColumn("dbo.Oefeningen", "Log_Oefening_Log_OefeningID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Oefeningen", "Log_Oefening_Log_OefeningID", c => c.Int());
            DropForeignKey("dbo.Log_Oefeningen", "OefeningID", "dbo.Oefeningen");
            DropIndex("dbo.Log_Oefeningen", new[] { "OefeningID" });
            AlterColumn("dbo.Log_Oefeningen", "OefeningID", c => c.Int());
            RenameColumn(table: "dbo.Log_Oefeningen", name: "OefeningID", newName: "Oefening_OefeningID");
            CreateIndex("dbo.Oefeningen", "Log_Oefening_Log_OefeningID");
            CreateIndex("dbo.Log_Oefeningen", "Oefening_OefeningID");
            AddForeignKey("dbo.Log_Oefeningen", "Oefening_OefeningID", "dbo.Oefeningen", "OefeningID");
            AddForeignKey("dbo.Oefeningen", "Log_Oefening_Log_OefeningID", "dbo.Log_Oefeningen", "Log_OefeningID");
        }
    }
}
