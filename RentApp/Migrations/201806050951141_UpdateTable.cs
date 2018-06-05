namespace RentApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AppUsers", "Type_Id", "dbo.UserTypes");
            DropForeignKey("dbo.PricelistItems", "VehicleItem_Id", "dbo.Vehicles");
            DropForeignKey("dbo.PricelistItems", "VehiclePricelist_Id", "dbo.Pricelists");
            DropForeignKey("dbo.Pricelists", "PricelistService_Id", "dbo.Services");
            DropForeignKey("dbo.Branches", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.Reservations", "EndBranch_Id", "dbo.Branches");
            DropForeignKey("dbo.Reservations", "ReservedVehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.Reservations", "StartingBranch_Id", "dbo.Branches");
            DropForeignKey("dbo.Reservations", "User_Id", "dbo.AppUsers");
            DropForeignKey("dbo.UserFeedbacks", "RatedService_Id", "dbo.Services");
            DropForeignKey("dbo.UserFeedbacks", "User_Id", "dbo.AppUsers");
            DropIndex("dbo.AppUsers", new[] { "Type_Id" });
            DropIndex("dbo.Branches", new[] { "Service_Id" });
            DropIndex("dbo.PricelistItems", new[] { "VehicleItem_Id" });
            DropIndex("dbo.PricelistItems", new[] { "VehiclePricelist_Id" });
            DropIndex("dbo.Pricelists", new[] { "PricelistService_Id" });
            DropIndex("dbo.Reservations", new[] { "EndBranch_Id" });
            DropIndex("dbo.Reservations", new[] { "ReservedVehicle_Id" });
            DropIndex("dbo.Reservations", new[] { "StartingBranch_Id" });
            DropIndex("dbo.Reservations", new[] { "User_Id" });
            DropIndex("dbo.UserFeedbacks", new[] { "RatedService_Id" });
            DropIndex("dbo.UserFeedbacks", new[] { "User_Id" });
            RenameColumn(table: "dbo.PricelistItems", name: "VehicleItem_Id", newName: "VehicleItemId");
            RenameColumn(table: "dbo.PricelistItems", name: "VehiclePricelist_Id", newName: "VehiclePricelistId");
            RenameColumn(table: "dbo.Pricelists", name: "PricelistService_Id", newName: "PricelistServiceId");
            RenameColumn(table: "dbo.Branches", name: "Service_Id", newName: "ServiceId");
            RenameColumn(table: "dbo.Reservations", name: "EndBranch_Id", newName: "EndBranchId");
            RenameColumn(table: "dbo.Reservations", name: "ReservedVehicle_Id", newName: "ReservedVehicleId");
            RenameColumn(table: "dbo.Reservations", name: "StartingBranch_Id", newName: "StartingBranchId");
            RenameColumn(table: "dbo.Reservations", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.UserFeedbacks", name: "RatedService_Id", newName: "RatedServiceId");
            RenameColumn(table: "dbo.UserFeedbacks", name: "User_Id", newName: "UserId");
            AddColumn("dbo.Services", "Email", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.AppUsers", "FullName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Branches", "Address", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Branches", "ServiceId", c => c.Int(nullable: false));
            AlterColumn("dbo.PricelistItems", "VehicleItemId", c => c.Int(nullable: false));
            AlterColumn("dbo.PricelistItems", "VehiclePricelistId", c => c.Int(nullable: false));
            AlterColumn("dbo.Vehicles", "VehicleModel", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Vehicles", "Manufacturer", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Vehicles", "VehiclePicture", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Pricelists", "PricelistServiceId", c => c.Int(nullable: false));
            AlterColumn("dbo.Services", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Services", "Logo", c => c.String(nullable: false));
            AlterColumn("dbo.Services", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Reservations", "EndBranchId", c => c.Int(nullable: false));
            AlterColumn("dbo.Reservations", "ReservedVehicleId", c => c.Int(nullable: false));
            AlterColumn("dbo.Reservations", "StartingBranchId", c => c.Int(nullable: false));
            AlterColumn("dbo.Reservations", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserFeedbacks", "RatedServiceId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserFeedbacks", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Branches", "ServiceId");
            CreateIndex("dbo.Reservations", "UserId");
            CreateIndex("dbo.Reservations", "ReservedVehicleId");
            CreateIndex("dbo.Reservations", "StartingBranchId");
            CreateIndex("dbo.Reservations", "EndBranchId");
            CreateIndex("dbo.PricelistItems", "VehicleItemId");
            CreateIndex("dbo.PricelistItems", "VehiclePricelistId");
            CreateIndex("dbo.Pricelists", "PricelistServiceId");
            CreateIndex("dbo.UserFeedbacks", "RatedServiceId");
            CreateIndex("dbo.UserFeedbacks", "UserId");
            AddForeignKey("dbo.PricelistItems", "VehicleItemId", "dbo.Vehicles", "Id", cascadeDelete: false);
            AddForeignKey("dbo.PricelistItems", "VehiclePricelistId", "dbo.Pricelists", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Pricelists", "PricelistServiceId", "dbo.Services", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Branches", "ServiceId", "dbo.Services", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Reservations", "EndBranchId", "dbo.Branches", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Reservations", "ReservedVehicleId", "dbo.Vehicles", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Reservations", "StartingBranchId", "dbo.Branches", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Reservations", "UserId", "dbo.AppUsers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.UserFeedbacks", "RatedServiceId", "dbo.Services", "Id", cascadeDelete: false);
            AddForeignKey("dbo.UserFeedbacks", "UserId", "dbo.AppUsers", "Id", cascadeDelete: false);
            DropColumn("dbo.AppUsers", "Type_Id");
            DropTable("dbo.UserTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AppUsers", "Type_Id", c => c.Int());
            DropForeignKey("dbo.UserFeedbacks", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.UserFeedbacks", "RatedServiceId", "dbo.Services");
            DropForeignKey("dbo.Reservations", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.Reservations", "StartingBranchId", "dbo.Branches");
            DropForeignKey("dbo.Reservations", "ReservedVehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Reservations", "EndBranchId", "dbo.Branches");
            DropForeignKey("dbo.Branches", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.Pricelists", "PricelistServiceId", "dbo.Services");
            DropForeignKey("dbo.PricelistItems", "VehiclePricelistId", "dbo.Pricelists");
            DropForeignKey("dbo.PricelistItems", "VehicleItemId", "dbo.Vehicles");
            DropIndex("dbo.UserFeedbacks", new[] { "UserId" });
            DropIndex("dbo.UserFeedbacks", new[] { "RatedServiceId" });
            DropIndex("dbo.Pricelists", new[] { "PricelistServiceId" });
            DropIndex("dbo.PricelistItems", new[] { "VehiclePricelistId" });
            DropIndex("dbo.PricelistItems", new[] { "VehicleItemId" });
            DropIndex("dbo.Reservations", new[] { "EndBranchId" });
            DropIndex("dbo.Reservations", new[] { "StartingBranchId" });
            DropIndex("dbo.Reservations", new[] { "ReservedVehicleId" });
            DropIndex("dbo.Reservations", new[] { "UserId" });
            DropIndex("dbo.Branches", new[] { "ServiceId" });
            AlterColumn("dbo.UserFeedbacks", "UserId", c => c.Int());
            AlterColumn("dbo.UserFeedbacks", "RatedServiceId", c => c.Int());
            AlterColumn("dbo.Reservations", "UserId", c => c.Int());
            AlterColumn("dbo.Reservations", "StartingBranchId", c => c.Int());
            AlterColumn("dbo.Reservations", "ReservedVehicleId", c => c.Int());
            AlterColumn("dbo.Reservations", "EndBranchId", c => c.Int());
            AlterColumn("dbo.Services", "Description", c => c.String());
            AlterColumn("dbo.Services", "Logo", c => c.String());
            AlterColumn("dbo.Services", "Name", c => c.String());
            AlterColumn("dbo.Pricelists", "PricelistServiceId", c => c.Int());
            AlterColumn("dbo.Vehicles", "Description", c => c.String());
            AlterColumn("dbo.Vehicles", "VehiclePicture", c => c.String());
            AlterColumn("dbo.Vehicles", "Manufacturer", c => c.String());
            AlterColumn("dbo.Vehicles", "VehicleModel", c => c.String());
            AlterColumn("dbo.PricelistItems", "VehiclePricelistId", c => c.Int());
            AlterColumn("dbo.PricelistItems", "VehicleItemId", c => c.Int());
            AlterColumn("dbo.Branches", "ServiceId", c => c.Int());
            AlterColumn("dbo.Branches", "Address", c => c.String());
            AlterColumn("dbo.AppUsers", "FullName", c => c.String());
            DropColumn("dbo.Services", "Email");
            RenameColumn(table: "dbo.UserFeedbacks", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.UserFeedbacks", name: "RatedServiceId", newName: "RatedService_Id");
            RenameColumn(table: "dbo.Reservations", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Reservations", name: "StartingBranchId", newName: "StartingBranch_Id");
            RenameColumn(table: "dbo.Reservations", name: "ReservedVehicleId", newName: "ReservedVehicle_Id");
            RenameColumn(table: "dbo.Reservations", name: "EndBranchId", newName: "EndBranch_Id");
            RenameColumn(table: "dbo.Branches", name: "ServiceId", newName: "Service_Id");
            RenameColumn(table: "dbo.Pricelists", name: "PricelistServiceId", newName: "PricelistService_Id");
            RenameColumn(table: "dbo.PricelistItems", name: "VehiclePricelistId", newName: "VehiclePricelist_Id");
            RenameColumn(table: "dbo.PricelistItems", name: "VehicleItemId", newName: "VehicleItem_Id");
            CreateIndex("dbo.UserFeedbacks", "User_Id");
            CreateIndex("dbo.UserFeedbacks", "RatedService_Id");
            CreateIndex("dbo.Reservations", "User_Id");
            CreateIndex("dbo.Reservations", "StartingBranch_Id");
            CreateIndex("dbo.Reservations", "ReservedVehicle_Id");
            CreateIndex("dbo.Reservations", "EndBranch_Id");
            CreateIndex("dbo.Pricelists", "PricelistService_Id");
            CreateIndex("dbo.PricelistItems", "VehiclePricelist_Id");
            CreateIndex("dbo.PricelistItems", "VehicleItem_Id");
            CreateIndex("dbo.Branches", "Service_Id");
            CreateIndex("dbo.AppUsers", "Type_Id");
            AddForeignKey("dbo.UserFeedbacks", "User_Id", "dbo.AppUsers", "Id");
            AddForeignKey("dbo.UserFeedbacks", "RatedService_Id", "dbo.Services", "Id");
            AddForeignKey("dbo.Reservations", "User_Id", "dbo.AppUsers", "Id");
            AddForeignKey("dbo.Reservations", "StartingBranch_Id", "dbo.Branches", "Id");
            AddForeignKey("dbo.Reservations", "ReservedVehicle_Id", "dbo.Vehicles", "Id");
            AddForeignKey("dbo.Reservations", "EndBranch_Id", "dbo.Branches", "Id");
            AddForeignKey("dbo.Branches", "Service_Id", "dbo.Services", "Id");
            AddForeignKey("dbo.Pricelists", "PricelistService_Id", "dbo.Services", "Id");
            AddForeignKey("dbo.PricelistItems", "VehiclePricelist_Id", "dbo.Pricelists", "Id");
            AddForeignKey("dbo.PricelistItems", "VehicleItem_Id", "dbo.Vehicles", "Id");
            AddForeignKey("dbo.AppUsers", "Type_Id", "dbo.UserTypes", "Id");
        }
    }
}
