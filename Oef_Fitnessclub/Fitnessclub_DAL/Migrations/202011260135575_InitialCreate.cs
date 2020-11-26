namespace Fitnessclub_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Log_Oefeningen",
                c => new
                    {
                        Log_OefeningID = c.Int(nullable: false, identity: true),
                        OefeningID = c.Int(nullable: false),
                        LogID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Log_OefeningID)
                .ForeignKey("dbo.Logs", t => t.LogID, cascadeDelete: true)
                .ForeignKey("dbo.Oefeningen", t => t.OefeningID, cascadeDelete: true)
                .Index(t => t.OefeningID)
                .Index(t => t.LogID);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        LogID = c.Int(nullable: false, identity: true),
                        KlantID = c.Int(nullable: false),
                        Review = c.String(),
                        Trainer = c.String(),
                        TrainerNodig = c.Boolean(nullable: false),
                        Datum = c.DateTime(nullable: false),
                        Klant_PersoonID = c.Int(),
                    })
                .PrimaryKey(t => t.LogID)
                .ForeignKey("dbo.Persoons", t => t.Klant_PersoonID)
                .Index(t => t.Klant_PersoonID);
            
            CreateTable(
                "dbo.Persoons",
                c => new
                    {
                        PersoonID = c.Int(nullable: false, identity: true),
                        Profielfoto = c.Binary(),
                        Voornaam = c.String(),
                        Achternaam = c.String(),
                        Wachtwoord = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Adres = c.String(),
                        Postcode = c.String(),
                        Gemeente = c.String(),
                        Land = c.String(),
                        KlantID = c.Int(),
                        Licentiecode = c.String(),
                        TrainerID = c.Int(),
                        Functie = c.String(),
                        Specialisatie = c.String(),
                        WerkgeverID = c.Int(),
                        IsAdmin = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PersoonID);
            
            CreateTable(
                "dbo.Oefeningen",
                c => new
                    {
                        OefeningID = c.Int(nullable: false, identity: true),
                        Videolink = c.String(),
                        Afbeelding = c.Binary(),
                        Naam = c.String(nullable: false),
                        Omschrijving = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OefeningID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Log_Oefeningen", "OefeningID", "dbo.Oefeningen");
            DropForeignKey("dbo.Log_Oefeningen", "LogID", "dbo.Logs");
            DropForeignKey("dbo.Logs", "Klant_PersoonID", "dbo.Persoons");
            DropIndex("dbo.Logs", new[] { "Klant_PersoonID" });
            DropIndex("dbo.Log_Oefeningen", new[] { "LogID" });
            DropIndex("dbo.Log_Oefeningen", new[] { "OefeningID" });
            DropTable("dbo.Oefeningen");
            DropTable("dbo.Persoons");
            DropTable("dbo.Logs");
            DropTable("dbo.Log_Oefeningen");
        }
    }
}
