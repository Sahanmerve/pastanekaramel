using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UnitOfWork
    {
        public SweetShopContext db;
        public UnitOfWork()
        {
            object oylesine = "";
            if (db == null)
            {
                lock (oylesine)
                {
                    if (db == null)
                    {
                        db = new SweetShopContext();
                    }
                }
            }
            Products = new BaseRepoSitory<Product>(db);
            Categories = new BaseRepoSitory<Category>(db);
           

        }
        public static SweetShopContext Create()
        {
            return new SweetShopContext();
        }

        public bool Complete()
        {
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }


        }

        public BaseRepoSitory<Product> Products;
        public BaseRepoSitory<Category> Categories;
     
    }
}
