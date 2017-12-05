namespace TimesheetData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stratingscript : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.App_logs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Method_Name = c.String(maxLength: 255, unicode: false),
                        Description = c.String(maxLength: 255, unicode: false),
                        CreatedByUserID = c.Long(),
                        CreatedDate = c.DateTime(),
                        DeletedByUserID = c.Long(),
                        DeletedDate = c.DateTime(),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedByUserID = c.Long(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Client_Name = c.String(maxLength: 255, unicode: false),
                        Address = c.String(maxLength: 255, unicode: false),
                        City = c.String(maxLength: 255, unicode: false),
                        State = c.String(maxLength: 255, unicode: false),
                        ZipCode = c.Int(nullable: false),
                        IsActive = c.Boolean(),
                        CreatedByUserID = c.Long(),
                        CreatedDate = c.DateTime(),
                        DeletedByUserID = c.Long(),
                        DeletedDate = c.DateTime(),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedByUserID = c.Long(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LookupItems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Key = c.String(maxLength: 255, unicode: false),
                        Description = c.String(maxLength: 255, unicode: false),
                        CreatedByUserID = c.Long(),
                        CreatedDate = c.DateTime(),
                        DeletedByUserID = c.Long(),
                        DeletedDate = c.DateTime(),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedByUserID = c.Long(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectAndUserMappings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Project_ID = c.Long(),
                        User_ID = c.Long(),
                        CreatedByUserID = c.Long(),
                        CreatedDate = c.DateTime(),
                        DeletedByUserID = c.Long(),
                        DeletedDate = c.DateTime(),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedByUserID = c.Long(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.Project_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Client_ID = c.Long(),
                        Project_Name = c.String(maxLength: 255, unicode: false),
                        Description = c.String(maxLength: 255, unicode: false),
                        StartDate = c.DateTime(),
                        EndEnd = c.DateTime(),
                        CreatedByUserID = c.Long(),
                        CreatedDate = c.DateTime(),
                        DeletedByUserID = c.Long(),
                        DeletedDate = c.DateTime(),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedByUserID = c.Long(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_ID)
                .Index(t => t.Client_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FullName = c.String(maxLength: 255, unicode: false),
                        EmailID = c.String(maxLength: 255, unicode: false),
                        RoleIDLookupID = c.Long(nullable: false),
                        isSuperAdmin = c.Boolean(nullable: false),
                        isApprover = c.Boolean(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        CreatedByUserID = c.Long(),
                        CreatedDate = c.DateTime(),
                        DeletedByUserID = c.Long(),
                        DeletedDate = c.DateTime(),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedByUserID = c.Long(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectAndUserMappings", "User_ID", "dbo.Users");
            DropForeignKey("dbo.ProjectAndUserMappings", "Project_ID", "dbo.Projects");
            DropForeignKey("dbo.Projects", "Client_ID", "dbo.Clients");
            DropIndex("dbo.Projects", new[] { "Client_ID" });
            DropIndex("dbo.ProjectAndUserMappings", new[] { "User_ID" });
            DropIndex("dbo.ProjectAndUserMappings", new[] { "Project_ID" });
            DropTable("dbo.Users");
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectAndUserMappings");
            DropTable("dbo.LookupItems");
            DropTable("dbo.Clients");
            DropTable("dbo.App_logs");
        }
    }
}
