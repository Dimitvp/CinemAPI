namespace CinemAPI.Data.EF
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingNewTableForBoughtTickets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProjectionId = c.Long(nullable: false),
                        Guid = c.String(),
                        ProjectionStartDate = c.DateTime(nullable: false),
                        MovieName = c.String(),
                        CinemaName = c.String(),
                        RoomNum = c.Int(nullable: false),
                        Row = c.Int(nullable: false),
                        Column = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tickets");
        }
    }
}
