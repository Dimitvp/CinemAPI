namespace CinemAPI.Data.EF
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingReservationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProjectionId = c.Long(nullable: false),
                        Gui = c.String(nullable: false),
                        ProjectionStartDate = c.DateTime(nullable: false),
                        MovieName = c.String(nullable: false),
                        CinemaName = c.String(nullable: false),
                        RoomNum = c.Int(nullable: false),
                        Row = c.Int(nullable: false),
                        Column = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projections", t => t.ProjectionId, cascadeDelete: true)
                .Index(t => t.ProjectionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "ProjectionId", "dbo.Projections");
            DropIndex("dbo.Reservations", new[] { "ProjectionId" });
            DropTable("dbo.Reservations");
        }
    }
}
