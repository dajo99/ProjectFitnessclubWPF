namespace Fitnessclub_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personen",
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
                    })
                .PrimaryKey(t => t.PersoonID);
            
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
                        klant_PersoonID = c.Int(),
                    })
                .PrimaryKey(t => t.LogID)
                .ForeignKey("dbo.Klanten", t => t.klant_PersoonID)
                .Index(t => t.klant_PersoonID);
            
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
            
            CreateTable(
                "dbo.Klanten",
                c => new
                    {
                        PersoonID = c.Int(nullable: false),
                        KlantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersoonID)
                .ForeignKey("dbo.Personen", t => t.PersoonID)
                .Index(t => t.PersoonID);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        PersoonID = c.Int(nullable: false),
                        TrainerID = c.Int(nullable: false),
                        Functie = c.String(nullable: false),
                        Specialisatie = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PersoonID)
                .ForeignKey("dbo.Personen", t => t.PersoonID)
                .Index(t => t.PersoonID);
            
            CreateTable(
                "dbo.Werkgevers",
                c => new
                    {
                        PersoonID = c.Int(nullable: false),
                        WerkgeverID = c.Int(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersoonID)
                .ForeignKey("dbo.Personen", t => t.PersoonID)
                .Index(t => t.PersoonID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Werkgevers", "PersoonID", "dbo.Personen");
            DropForeignKey("dbo.Trainers", "PersoonID", "dbo.Personen");
            DropForeignKey("dbo.Klanten", "PersoonID", "dbo.Personen");
            DropForeignKey("dbo.Log_Oefeningen", "OefeningID", "dbo.Oefeningen");
            DropForeignKey("dbo.Log_Oefeningen", "LogID", "dbo.Logs");
            DropForeignKey("dbo.Logs", "klant_PersoonID", "dbo.Klanten");
            DropIndex("dbo.Werkgevers", new[] { "PersoonID" });
            DropIndex("dbo.Trainers", new[] { "PersoonID" });
            DropIndex("dbo.Klanten", new[] { "PersoonID" });
            DropIndex("dbo.Log_Oefeningen", new[] { "LogID" });
            DropIndex("dbo.Log_Oefeningen", new[] { "OefeningID" });
            DropIndex("dbo.Logs", new[] { "klant_PersoonID" });
            DropTable("dbo.Werkgevers");
            DropTable("dbo.Trainers");
            DropTable("dbo.Klanten");
            DropTable("dbo.Oefeningen");
            DropTable("dbo.Log_Oefeningen");
            DropTable("dbo.Logs");
            DropTable("dbo.Personen");
        }
    }
}
