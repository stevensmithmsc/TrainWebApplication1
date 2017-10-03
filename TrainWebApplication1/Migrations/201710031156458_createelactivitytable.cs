namespace TrainWebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createelactivitytable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.elresults",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        personid = c.Int(nullable: false),
                        personname = c.String(),
                        courseid = c.Int(nullable: false),
                        coursedesc = c.String(),
                        score = c.Int(nullable: false),
                        maxscore = c.Int(nullable: false),
                        passfail = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.elresults");
        }
    }
}
