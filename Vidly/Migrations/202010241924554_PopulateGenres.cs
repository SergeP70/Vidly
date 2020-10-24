namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Animation')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Detective')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Drama')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Fantasy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7, 'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (8, 'Musical')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (9, 'Romance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (10, 'Science Fiction')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (11, 'Thriller')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (12, 'Western')");

        }

        public override void Down()
        {
        }
    }
}
