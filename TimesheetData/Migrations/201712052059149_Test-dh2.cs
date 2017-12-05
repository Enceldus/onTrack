namespace TimesheetData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Testdh2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TimeTrackers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProjectID = c.Long(nullable: false),
                        EmpID = c.Long(nullable: false),
                        WeekofTheYear = c.Int(nullable: false),
                        FromTodate = c.String(maxLength: 255, unicode: false),
                        TimeSheetStatus = c.String(maxLength: 255, unicode: false),
                        ApprovalID = c.Long(nullable: false),
                        CreatedByUserID = c.Long(),
                        CreatedDate = c.DateTime(),
                        DeletedByUserID = c.Long(),
                        DeletedDate = c.DateTime(),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedByUserID = c.Long(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ApprovalID, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.EmpID, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID)
                .Index(t => t.EmpID)
                .Index(t => t.ApprovalID);
            
            CreateTable(
                "dbo.TimeTrackerDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TimeTrackerID = c.Long(nullable: false),
                        Hours = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TrackingDate = c.DateTime(),
                        IsActive = c.Boolean(),
                        CreatedByUserID = c.Long(),
                        CreatedDate = c.DateTime(),
                        DeletedByUserID = c.Long(),
                        DeletedDate = c.DateTime(),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedByUserID = c.Long(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TimeTrackers", t => t.TimeTrackerID, cascadeDelete: true)
                .Index(t => t.TimeTrackerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeTrackerDetails", "TimeTrackerID", "dbo.TimeTrackers");
            DropForeignKey("dbo.TimeTrackers", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.TimeTrackers", "EmpID", "dbo.Users");
            DropForeignKey("dbo.TimeTrackers", "ApprovalID", "dbo.Users");
            DropIndex("dbo.TimeTrackerDetails", new[] { "TimeTrackerID" });
            DropIndex("dbo.TimeTrackers", new[] { "ApprovalID" });
            DropIndex("dbo.TimeTrackers", new[] { "EmpID" });
            DropIndex("dbo.TimeTrackers", new[] { "ProjectID" });
            DropTable("dbo.TimeTrackerDetails");
            DropTable("dbo.TimeTrackers");
        }
    }
}
