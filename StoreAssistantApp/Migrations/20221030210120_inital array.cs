using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreAssistantApp.Migrations
{
    public partial class initalarray : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoveHistories_Nomenclatures_NomenclatureId",
                table: "MoveHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_MoveHistories_Warehouses_FromWarehouseId",
                table: "MoveHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_MoveHistories_Warehouses_ToWarehouseId",
                table: "MoveHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreHouses_Nomenclatures_NomenclatureId",
                table: "StoreHouses");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreHouses_Warehouses_WarehouseId",
                table: "StoreHouses");

            migrationBuilder.DropIndex(
                name: "IX_StoreHouses_NomenclatureId",
                table: "StoreHouses");

            migrationBuilder.DropIndex(
                name: "IX_StoreHouses_WarehouseId",
                table: "StoreHouses");

            migrationBuilder.DropIndex(
                name: "IX_MoveHistories_FromWarehouseId",
                table: "MoveHistories");

            migrationBuilder.DropIndex(
                name: "IX_MoveHistories_NomenclatureId",
                table: "MoveHistories");

            migrationBuilder.DropIndex(
                name: "IX_MoveHistories_ToWarehouseId",
                table: "MoveHistories");

            migrationBuilder.DropColumn(
                name: "FromWarehouseId",
                table: "MoveHistories");

            migrationBuilder.DropColumn(
                name: "NomenclatureId",
                table: "MoveHistories");

            migrationBuilder.DropColumn(
                name: "ToWarehouseId",
                table: "MoveHistories");

            migrationBuilder.RenameColumn(
                name: "WarehouseId",
                table: "StoreHouses",
                newName: "Warehouse");

            migrationBuilder.RenameColumn(
                name: "NomenclatureId",
                table: "StoreHouses",
                newName: "Nomenclature");

            migrationBuilder.AddColumn<int>(
                name: "FromWarehouse",
                table: "MoveHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Nomenclature",
                table: "MoveHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToWarehouse",
                table: "MoveHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromWarehouse",
                table: "MoveHistories");

            migrationBuilder.DropColumn(
                name: "Nomenclature",
                table: "MoveHistories");

            migrationBuilder.DropColumn(
                name: "ToWarehouse",
                table: "MoveHistories");

            migrationBuilder.RenameColumn(
                name: "Warehouse",
                table: "StoreHouses",
                newName: "WarehouseId");

            migrationBuilder.RenameColumn(
                name: "Nomenclature",
                table: "StoreHouses",
                newName: "NomenclatureId");

            migrationBuilder.AddColumn<int>(
                name: "FromWarehouseId",
                table: "MoveHistories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NomenclatureId",
                table: "MoveHistories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToWarehouseId",
                table: "MoveHistories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreHouses_NomenclatureId",
                table: "StoreHouses",
                column: "NomenclatureId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreHouses_WarehouseId",
                table: "StoreHouses",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_MoveHistories_FromWarehouseId",
                table: "MoveHistories",
                column: "FromWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_MoveHistories_NomenclatureId",
                table: "MoveHistories",
                column: "NomenclatureId");

            migrationBuilder.CreateIndex(
                name: "IX_MoveHistories_ToWarehouseId",
                table: "MoveHistories",
                column: "ToWarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_MoveHistories_Nomenclatures_NomenclatureId",
                table: "MoveHistories",
                column: "NomenclatureId",
                principalTable: "Nomenclatures",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MoveHistories_Warehouses_FromWarehouseId",
                table: "MoveHistories",
                column: "FromWarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MoveHistories_Warehouses_ToWarehouseId",
                table: "MoveHistories",
                column: "ToWarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreHouses_Nomenclatures_NomenclatureId",
                table: "StoreHouses",
                column: "NomenclatureId",
                principalTable: "Nomenclatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreHouses_Warehouses_WarehouseId",
                table: "StoreHouses",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
