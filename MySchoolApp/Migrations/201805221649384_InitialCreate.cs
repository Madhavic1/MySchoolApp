namespace MySchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Father_Name = c.String(nullable: false),
                        StudentGrade = c.Int(nullable: false),
                        ArtSubjectTaken = c.Int(nullable: false),
                        FeesPaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FeeTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Totalsalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalaryEarned = c.Int(nullable: false),
                        ContactNumber = c.Long(nullable: false),
                        Address = c.String(nullable: false),
                        Grade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
        }
    }
}
