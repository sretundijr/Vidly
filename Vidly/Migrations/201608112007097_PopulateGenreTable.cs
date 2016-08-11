namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MovieGenres(Id, Genre) VALUES (1, 'Comedy')");
            Sql("INSERT INTO MovieGenres(Id, Genre) VALUES (2, 'Action')");
            Sql("INSERT INTO MovieGenres(Id, Genre) VALUES (3, 'Family')");
            Sql("INSERT INTO MovieGenres(Id, Genre) VALUES (4, 'Romance')");
            Sql("INSERT INTO MovieGenres(Id, Genre) VALUES (5, 'Horror')");
            Sql("INSERT INTO MovieGenres(Id, Genre) VALUES (6, 'Crime')");
        }
        
        public override void Down()
        {
        }
    }
}
