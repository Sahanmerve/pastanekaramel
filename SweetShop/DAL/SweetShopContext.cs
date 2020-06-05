using Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;

namespace DAL
{
    public class SweetShopContext:IdentityDbContext<Customer>
    {
        #if (DEBUG)
        public SweetShopContext():base("SweetShopContext")
        {

        }
#else

 public SweetShopContext():base("KaramelPastanesi")
        {

        }
#endif

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<HomeSlider> HomeSliders { get; set; }


        public static SweetShopContext Create()
        {
            return new SweetShopContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
#region TableConfiguration
            modelBuilder.Entity<Product>().HasKey(x => x.ID).Property<int>(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Category>().HasKey(x => x.ID);
            modelBuilder.Entity<Slider>().HasKey(x => x.ID);
            modelBuilder.Entity<HomeSlider>().HasKey(x => x.ID);
            
            //modelBuilder.Entity<Category>().HasOptional(x => x.ParentCategory).WithMany(x => x.SubCategories).HasForeignKey(x => x.ParentID);
#endregion

#region Relations
            modelBuilder.Entity<Product>().HasRequired(x => x.ProductCategories).WithMany(x => x.CategoryProducts);
#endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
