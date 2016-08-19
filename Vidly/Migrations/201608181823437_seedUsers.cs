namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a9eda45e-8656-437b-9c0d-56de4b0d45f7', N'Admin@vidly.com', 0, N'AINNQFGx+mY3EZfk6TEG1te2diexo2LGBcAu+3PkrvsOMiGFy8dCJH+/q/EVBfdfoA==', N'10e954a3-9c34-470d-a8e6-24521e837ed1', NULL, 0, 0, NULL, 1, 0, N'Admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e921dc5f-23d3-4647-844a-2668cc475a15', N'guest@vidly.com', 0, N'AJ97kNJIOtUghe7UI333C3HKS5LsNBtGulM/YX6NskhdMaMeZVR9i6sz/Va+rFOqOA==', N'ec77343f-96c7-4bb8-9371-e9736a002171', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'82d1444b-e375-4eba-bd64-eee5361b9169', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a9eda45e-8656-437b-9c0d-56de4b0d45f7', N'82d1444b-e375-4eba-bd64-eee5361b9169')

");
        }
        
        public override void Down()
        {
        }
    }
}
