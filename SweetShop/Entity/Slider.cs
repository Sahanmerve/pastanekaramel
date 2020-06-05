using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Slider: IEntity
    {
        public int ID { get; set; }
        public string ThumbnaiURL { get; set; }
        public string LargeImageUrl { get; set; }
    }
}
