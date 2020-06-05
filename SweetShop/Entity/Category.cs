using Entity.Abstract;
using System.Collections.Generic;

namespace Entity
{
    public class Category:IEntity
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImageURL { get; set; }
        //public int? ParentID { get; set; }
        //public virtual Category ParentCategory { get; set; }
        //public virtual List<Category> SubCategories { get; set; }
        public virtual List<Product> CategoryProducts { get; set; }
    }
}
