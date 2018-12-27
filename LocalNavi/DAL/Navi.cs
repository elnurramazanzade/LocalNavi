using LocalNavi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LocalNavi.DAL
{
    public class Navi : DbContext
    {
        public Navi() : base("NaviContext") { }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryService> CategoryServices { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentPhoto> CommentPhotos { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<PlacePhoto> PlacePhotos { get; set; }
        public DbSet<PlaceService> PlaceServices { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkHour> WorkHours { get; set; }
    }
}