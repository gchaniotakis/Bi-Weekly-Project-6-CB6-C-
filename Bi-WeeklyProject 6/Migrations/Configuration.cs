﻿using System.Data.Entity.Migrations;

internal sealed class Configuration : DbMigrationsConfiguration<Bi_WeeklyProject_6.Models.Database>
{
    public Configuration()
    {
        AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(Bi_WeeklyProject_6.Models.Database context)
    {
        //  This method will be called after migrating to the latest version.

        //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //  to avoid creating duplicate seed data.
    }
}