namespace sql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLiczbaProjektow : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CzlonekZespolus",
                c => new
                    {
                        czlonekZespoluId = c.Int(nullable: false, identity: true),
                        zespolId = c.Int(nullable: false),
                        Funkcja = c.String(),
                        Nazwisko = c.String(),
                        Imie = c.String(),
                        DataUr = c.DateTime(nullable: false),
                        Plec = c.Int(nullable: false),
                        Pesel = c.String(),
                    })
                .PrimaryKey(t => t.czlonekZespoluId)
                .ForeignKey("dbo.Zespols", t => t.zespolId, cascadeDelete: true)
                .Index(t => t.zespolId);
            
            CreateTable(
                "dbo.Zespols",
                c => new
                    {
                        zespolId = c.Int(nullable: false, identity: true),
                        Liczbaczlonkow = c.Int(nullable: false),
                        Nazwa = c.String(),
                        kierownik_kierownikZespoluId = c.Int(),
                    })
                .PrimaryKey(t => t.zespolId)
                .ForeignKey("dbo.KierownikZespolus", t => t.kierownik_kierownikZespoluId)
                .Index(t => t.kierownik_kierownikZespoluId);
            
            CreateTable(
                "dbo.KierownikZespolus",
                c => new
                    {
                        kierownikZespoluId = c.Int(nullable: false, identity: true),
                        Doswiadczenie = c.Int(nullable: false),
                        liczbaProjektow = c.Int(nullable: false),
                        Nazwisko = c.String(),
                        Imie = c.String(),
                        DataUr = c.DateTime(nullable: false),
                        Plec = c.Int(nullable: false),
                        Pesel = c.String(),
                    })
                .PrimaryKey(t => t.kierownikZespoluId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Zespols", "kierownik_kierownikZespoluId", "dbo.KierownikZespolus");
            DropForeignKey("dbo.CzlonekZespolus", "zespolId", "dbo.Zespols");
            DropIndex("dbo.Zespols", new[] { "kierownik_kierownikZespoluId" });
            DropIndex("dbo.CzlonekZespolus", new[] { "zespolId" });
            DropTable("dbo.KierownikZespolus");
            DropTable("dbo.Zespols");
            DropTable("dbo.CzlonekZespolus");
        }
    }
}
