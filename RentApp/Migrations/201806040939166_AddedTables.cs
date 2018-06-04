namespace RentApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BranchPicture = c.String(),
                        Address = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Service_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.Service_Id)
                .Index(t => t.Service_Id);
            
            CreateTable(
                "dbo.PricelistItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehiclePrice = c.Double(nullable: false),
                        VehicleItem_Id = c.Int(),
                        VehiclePricelist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.VehicleItem_Id)
                .ForeignKey("dbo.Pricelists", t => t.VehiclePricelist_Id)
                .Index(t => t.VehicleItem_Id)
                .Index(t => t.VehiclePricelist_Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleModel = c.String(),
                        Manufacturer = c.String(),
                        VehiclePicture = c.String(),
                        Description = c.String(),
                        Service_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.Service_Id)
                .Index(t => t.Service_Id);
            
            CreateTable(
                "dbo.Pricelists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeOfValidity = c.DateTime(nullable: false),
                        PricelistService_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.PricelistService_Id)
                .Index(t => t.PricelistService_Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TakeOverTime = c.DateTime(nullable: false),
                        ReturnTime = c.DateTime(nullable: false),
                        EndBranch_Id = c.Int(),
                        ReservedVehicle_Id = c.Int(),
                        StartingBranch_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.EndBranch_Id)
                .ForeignKey("dbo.Vehicles", t => t.ReservedVehicle_Id)
                .ForeignKey("dbo.Branches", t => t.StartingBranch_Id)
                .ForeignKey("dbo.AppUsers", t => t.User_Id)
                .Index(t => t.EndBranch_Id)
                .Index(t => t.ReservedVehicle_Id)
                .Index(t => t.StartingBranch_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UserFeedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserRating = c.Int(nullable: false),
                        UserComment = c.String(),
                        RatedService_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.RatedService_Id)
                .ForeignKey("dbo.AppUsers", t => t.User_Id)
                .Index(t => t.RatedService_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.AppUsers", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.AppUsers", "UserPicture", c => c.String());
            AddColumn("dbo.AppUsers", "Type_Id", c => c.Int());
            AddColumn("dbo.Services", "Logo", c => c.String());
            AddColumn("dbo.Services", "Description", c => c.String());
            AddColumn("dbo.Services", "AverageRating", c => c.Double(nullable: false));
            CreateIndex("dbo.AppUsers", "Type_Id");
            AddForeignKey("dbo.AppUsers", "Type_Id", "dbo.UserTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserFeedbacks", "User_Id", "dbo.AppUsers");
            DropForeignKey("dbo.UserFeedbacks", "RatedService_Id", "dbo.Services");
            DropForeignKey("dbo.Reservations", "User_Id", "dbo.AppUsers");
            DropForeignKey("dbo.Reservations", "StartingBranch_Id", "dbo.Branches");
            DropForeignKey("dbo.Reservations", "ReservedVehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.Reservations", "EndBranch_Id", "dbo.Branches");
            DropForeignKey("dbo.PricelistItems", "VehiclePricelist_Id", "dbo.Pricelists");
            DropForeignKey("dbo.Pricelists", "PricelistService_Id", "dbo.Services");
            DropForeignKey("dbo.Vehicles", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.Branches", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.PricelistItems", "VehicleItem_Id", "dbo.Vehicles");
            DropForeignKey("dbo.AppUsers", "Type_Id", "dbo.UserTypes");
            DropIndex("dbo.UserFeedbacks", new[] { "User_Id" });
            DropIndex("dbo.UserFeedbacks", new[] { "RatedService_Id" });
            DropIndex("dbo.Reservations", new[] { "User_Id" });
            DropIndex("dbo.Reservations", new[] { "StartingBranch_Id" });
            DropIndex("dbo.Reservations", new[] { "ReservedVehicle_Id" });
            DropIndex("dbo.Reservations", new[] { "EndBranch_Id" });
            DropIndex("dbo.Pricelists", new[] { "PricelistService_Id" });
            DropIndex("dbo.Vehicles", new[] { "Service_Id" });
            DropIndex("dbo.PricelistItems", new[] { "VehiclePricelist_Id" });
            DropIndex("dbo.PricelistItems", new[] { "VehicleItem_Id" });
            DropIndex("dbo.Branches", new[] { "Service_Id" });
            DropIndex("dbo.AppUsers", new[] { "Type_Id" });
            DropColumn("dbo.Services", "AverageRating");
            DropColumn("dbo.Services", "Description");
            DropColumn("dbo.Services", "Logo");
            DropColumn("dbo.AppUsers", "Type_Id");
            DropColumn("dbo.AppUsers", "UserPicture");
            DropColumn("dbo.AppUsers", "DateOfBirth");
            DropTable("dbo.UserFeedbacks");
            DropTable("dbo.Reservations");
            DropTable("dbo.Pricelists");
            DropTable("dbo.Vehicles");
            DropTable("dbo.PricelistItems");
            DropTable("dbo.Branches");
            DropTable("dbo.UserTypes");
        }
    }
}
