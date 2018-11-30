using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whiteboard.Models;

namespace Whiteboard.DAL
{
    public class WhiteboardInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<WhiteboardContext>
    {
        protected override void Seed(WhiteboardContext context)
        {
            var teams = new List<Team>
            {
                new Team{TeamName="TNG",Organization="ST"},
                new Team{TeamName="DS9",Organization="ST"},
                new Team{TeamName="VOY",Organization="ST"},
                new Team{TeamName="ENT",Organization="ST"}
            };
            teams.ForEach(s => context.Teams.Add(s));
            context.SaveChanges();

            var users = new List<User>
            {
                new User{UserName="BeverlyC",TeamID=1},
                new User{UserName="KiraN",TeamID=1},
                new User{UserName="HKim",TeamID=1},
                new User{UserName="JArcher",TeamID=1}
            };
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var whiteboards = new List<WhiteboardItem>
            {
                new WhiteboardItem{ImageURL="Test1",UserID = 0},
                new WhiteboardItem{ImageURL="Test2",UserID = 3},
                new WhiteboardItem{ImageURL="Test3",UserID = 1},
                new WhiteboardItem{ImageURL="Test4",UserID = 3}
            };
            whiteboards.ForEach(s => context.WhiteboardItems.Add(s));
            context.SaveChanges();

            var tags = new List<Tag>
            {
                new Tag{TagName="Ops"},
                new Tag{TagName="Medical"},
                new Tag{TagName="Astrometrics"},
                new Tag{TagName="Engineering"}
            };
            tags.ForEach(s => context.Tags.Add(s));
            context.SaveChanges();

            var taggedWhiteboards = new List<TaggedWhiteboard>
            {
                new TaggedWhiteboard{TagID=0,WhiteboardItemID=0},
                new TaggedWhiteboard{TagID=1,WhiteboardItemID=1},
                new TaggedWhiteboard{TagID=0,WhiteboardItemID=3},
                new TaggedWhiteboard{TagID=2,WhiteboardItemID=2}
            };
            taggedWhiteboards.ForEach(s => context.TaggedWhiteboards.Add(s));
            context.SaveChanges();
        }
    }
}