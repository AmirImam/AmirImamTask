using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmirImamTask.DataServices.Migrations
{
    public partial class CreateTrigger_UpdateItemQuantityOnTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE  TRIGGER UpdateItemQuantityOnTransaction
ON TransactionDetail
FOR  Insert
AS
BEGIN
	SET NOCOUNT ON
	declare @TransactionId uniqueidentifier;
	
	
	declare @StoreId uniqueidentifier;
	set @StoreId = (SELECT StoreId FROM [Transaction] WHERE [Id] = (Select TransactionId FROM inserted));

	UPDATE ItemStore SET Quantity = (Quantity + (SELECT Quantity FROM inserted) * (SELECT TransactionFactor FROM inserted))
	WHERE StoreId = @StoreId AND ItemId = (SELECT ItemId FROM inserted)
END
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER UpdateItemQuantityOnTransaction");
        }
    }
}
