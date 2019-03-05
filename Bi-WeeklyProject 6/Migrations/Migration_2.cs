using System.Data.Entity.Migrations;

public partial class Migration_2 : DbMigration
{
    public override void Up()
    {
        CreateTable(
            "dbo.Task",
            c => new
            {
                Id = c.Int(nullable: false, identity: true),
                Name = c.String(nullable: false),
                Text = c.String(nullable: false),
                Role = c.Int(nullable: false),
                UserID = c.Int(nullable: false),
            })
            .PrimaryKey(t => t.Id)
            .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
            .Index(t => t.UserID);

    }

    public override void Down()
    {
        DropForeignKey("dbo.Task", "UserID", "dbo.Users");
        DropIndex("dbo.Task", new[] { "UserID" });
        DropTable("dbo.Task");
    }
}