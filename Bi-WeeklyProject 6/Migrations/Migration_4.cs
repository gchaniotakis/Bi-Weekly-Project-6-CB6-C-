﻿using System.Data.Entity.Migrations;

public partial class Migration_4 : DbMigration
{
    public override void Up()
    {
        CreateTable(
            "dbo.ManagerUsers",
            c => new
            {
                Id = c.Int(nullable: false, identity: true),
                Username = c.String(nullable: false),
                Password = c.String(nullable: false),
                Role = c.Int(nullable: false),
            })
            .PrimaryKey(t => t.Id);

    }

    public override void Down()
    {
        DropTable("dbo.ManagerUsers");
    }
}