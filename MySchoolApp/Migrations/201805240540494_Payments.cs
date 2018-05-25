namespace MySchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Payments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StudentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "StudentID", "dbo.Students");
            DropIndex("dbo.Payments", new[] { "StudentID" });
            DropTable("dbo.Payments");
        }
    }
}
