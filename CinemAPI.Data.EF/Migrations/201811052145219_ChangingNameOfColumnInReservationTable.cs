namespace CinemAPI.Data.EF
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingNameOfColumnInReservationTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Guid", c => c.String(nullable: false));
            DropColumn("dbo.Reservations", "Gui");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "Gui", c => c.String(nullable: false));
            DropColumn("dbo.Reservations", "Guid");
        }
    }
}
