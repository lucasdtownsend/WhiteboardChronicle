using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Whiteboard.Models;

namespace Whiteboard.DAL
{
    public class WhiteboardContext : DbContext
    {
        public WhiteboardContext() : base("WhiteboardContext")
        { }

        public DbSet<WhiteboardItem> WhiteboardItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TaggedWhiteboard> TaggedWhiteboards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}