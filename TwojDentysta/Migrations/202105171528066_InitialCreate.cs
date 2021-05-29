namespace TwojDentysta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        PhysiciansID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        Booked = c.Boolean(nullable: false),
                        PatientFirstName = c.String(),
                        PatientLastName = c.String(),
                        PatientPhoneNumber = c.Int(nullable: false),
                        PatientEmail = c.String(),
                        Description = c.String(),
                        Physician_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Location", t => t.LocationID, cascadeDelete: true)
                .ForeignKey("dbo.Physician", t => t.Physician_ID)
                .Index(t => t.LocationID)
                .Index(t => t.Physician_ID);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ZipCode = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        Lat = c.Double(nullable: false),
                        Long = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Physician",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Title = c.String(),
                        Specialisation = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointment", "Physician_ID", "dbo.Physician");
            DropForeignKey("dbo.Appointment", "LocationID", "dbo.Location");
            DropIndex("dbo.Appointment", new[] { "Physician_ID" });
            DropIndex("dbo.Appointment", new[] { "LocationID" });
            DropTable("dbo.Physician");
            DropTable("dbo.Location");
            DropTable("dbo.Appointment");
        }
    }
}
