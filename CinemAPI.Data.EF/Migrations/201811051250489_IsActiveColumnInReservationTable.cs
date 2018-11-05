namespace CinemAPI.Data.EF
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsActiveColumnInReservationTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "IsActive");
        }
    }
}
