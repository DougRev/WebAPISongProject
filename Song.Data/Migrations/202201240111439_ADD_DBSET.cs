namespace Song.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADD_DBSET : DbMigration
    {
        public override void Up()
        {


            CreateTable(
                "dbo.Songy",
                c => new
                {
                    SongId = c.Int(nullable: false, identity: true),
                    OwnerId = c.Guid(nullable: false),
                    Title = c.String(nullable: false),
                    Artist = c.String(nullable: false),
                    Genre = c.String(),
                    RunTime = c.String(),
                    Lyrics = c.String(),
                    CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                })
                .PrimaryKey(t => t.SongId);
        }
            
            
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Songy");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
        }
    }
}
