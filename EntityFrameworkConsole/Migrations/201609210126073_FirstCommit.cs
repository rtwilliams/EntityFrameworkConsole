namespace EntityFrameworkConsole.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class FirstCommit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bands",
                c => new
                    {
                        BandId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BandId);
            
            CreateTable(
                "dbo.Musicians",
                c => new
                    {
                        MusicianId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Band_BandId = c.Int(),
                    })
                .PrimaryKey(t => t.MusicianId)
                .ForeignKey("dbo.Bands", t => t.Band_BandId)
                .Index(t => t.Band_BandId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Musicians", "Band_BandId", "dbo.Bands");
            DropIndex("dbo.Musicians", new[] { "Band_BandId" });
            DropTable("dbo.Musicians");
            DropTable("dbo.Bands");
        }
    }
}
