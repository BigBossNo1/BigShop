using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Web.Models.Models;

namespace Web.Data
{
    public class ToanLeeShopDbContext : IdentityDbContext<ApplicationUser>
    {
        public ToanLeeShopDbContext() : base("ToanLeeShopDbContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            // load bảng cha không ảnh gưởng đến bảng con 
        }

        public DbSet<Footer> Footers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuGroup> MenuGroups { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Pages> Pages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategorie> PostCategories { get; set; }
        public DbSet<PostTag> postTags { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategorye> ProductCategoryes { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<SupportOnline> SupportOnlines { get; set; }
        public DbSet<SystemConfig> SystemConfigs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<VisitorStatic> VisitorStatics { get; set; }
        public DbSet<Error> Errors { get; set; }
        public static ToanLeeShopDbContext Create()
        {
            return new ToanLeeShopDbContext();
        }
        // Câu lệnh để có thể thao  tác được Identity
        // Note : copy từ bên Project mẫu
        // Ghi đè để chạy đc entity framework
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId , i.RoleId});
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId);
        }
    }
}