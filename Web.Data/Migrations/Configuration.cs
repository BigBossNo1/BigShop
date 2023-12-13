namespace Web.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Web.Models.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Web.Data.ToanLeeShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Web.Data.ToanLeeShopDbContext context)
        {
            // Gọi thực thi ở đây

            CreateProductCategotyExamble(context);
            createSlide(context);

        }

        private void createUser(ToanLeeShopDbContext context)
        {

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ToanLeeShopDbContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ToanLeeShopDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "ToanLee",
                Email = "toanlee03@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Le Van Toan"
            };

            manager.Create(user, "123456$");

            /// Nếu mà cái roleManager chưa tồn tại
            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("toanlvhe173348@fpt.edu.vn");
            // manager.AddToRole(adminUser.Id, new string [] { "Admin", "User" });
            string[] roles = { "Admin", "User" };
            foreach (string role in roles)
            {
                manager.AddToRole(adminUser.Id, role);
            }
        }
        private void CreateProductCategotyExamble(ToanLeeShopDbContext context)
        {
            if (context.ProductCategoryes.Count() == 0)
            {
                List<ProductCategorye> listProductCategory = new List<ProductCategorye>()
            {
                new ProductCategorye() {Name="Điện Thoại" , Alias="dien-thoai" , Status= true},
                new ProductCategorye() {Name="Máy Tính" , Alias="may-tinh" , Status= true},
                new ProductCategorye() {Name="Viễn Thông" , Alias="vien-thong" , Status= true},
                new ProductCategorye() {Name="Cáp Sạc" , Alias="cap-sac" , Status= true},
                new ProductCategorye() {Name="Phụ Kiện" , Alias="phu-kien" , Status= true}
            };
                context.ProductCategoryes.AddRange(listProductCategory);
                context.SaveChanges();
            }
        }

        private void createSlide(ToanLeeShopDbContext context)
        {
            if(context.Slides.Count() == 0)
            {
                List<Slide> listSlide = new List<Slide>()
                {
                    new Slide() {Name = "Slide 1 " ,
                        DisplayOrder = 1 , 
                        Status = true , 
                        URL = "#" , 
                        Image = "/Assets/client/images/bag.jpg",
                        Content = @"<h2>Giảm 50% </h2>
                                <label>Trong <b>Tháng Này</b> </label>
                                <p>Chương trình tri ân khách hàng của shop chúng tôi </ p >
                                < span class=""on-get"">Xem Ngay</span>"},
                    new Slide() {Name = "Slide 2 " ,
                        DisplayOrder = 2 ,
                        Status = true ,
                        URL = "#" , 
                        Image = "/Assets/client/images/bag1.jpg",
                        Content = @"<h2>Giảm 70% </h2>
                                <label>Cho Các Mặt Hàng <b>Phụ Kiện</b></label>
                                <p>Chương trình tri ân khách hàng của shop chúng tôi </ p >
                                < span class=""on-get"">Xem Ngay</span>"}
                };
                context.Slides.AddRange(listSlide);
                context.SaveChanges();
            }
        }
    }
}