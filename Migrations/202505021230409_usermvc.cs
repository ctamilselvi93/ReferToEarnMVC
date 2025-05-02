namespace ReferToEarnMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usermvc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        MobileNumber = c.String(nullable: false),
                        PasswordHash = c.String(nullable: false),
                        ReferralCode = c.String(),
                        ReferredBy = c.String(),
                        Points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
        }
    }
}
