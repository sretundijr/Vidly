namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateMembershipTable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Pay as You Go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Quartly' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET name = 'Annually' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
