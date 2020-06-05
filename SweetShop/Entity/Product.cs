using Entity.Abstract;
using System.Collections.Generic;

namespace Entity
{
    public class Product: IEntity
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string Calori { get; set; }
        public string ProductImageUrl { get; set; }
        public bool HasPhoto { get; set; }
        public int Piece { get; set; }
        public int CategoryID { get; set; }
        public virtual Category ProductCategories { get; set; }

    }
}
