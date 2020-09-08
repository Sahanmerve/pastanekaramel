using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SweetShop.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : Customer
    {
       
        public static async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Customer> manager, Customer user)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    //{
    //    public ApplicationDbContext()
    //        : base("SweetShopContext", throwIfV1Schema: false)
    //    {
    //    }

    //    public static ApplicationDbContext Create()
    //    {
    //        return new ApplicationDbContext();
    //    }

    //    public System.Data.Entity.DbSet<Entity.Product> Products { get; set; }

    //    public System.Data.Entity.DbSet<Entity.Category> Categories { get; set; }

    //    public System.Data.Entity.DbSet<Entity.ShoppingCard> ShoppingCards { get; set; }

    //    //public System.Data.Entity.DbSet<Entity.Customer> Customers { get; set; }
    //}
}