using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFYP.Core.Models
{
    public class Basket : BaseEntity
    {
        //Already have an ID from BaseEntity
        //Vitual ICollection will load basket items as well as basket in entity framework
        public virtual ICollection<BasketItem> BasketItems { get; set; }

        public Basket()
        {
            this.BasketItems = new List<BasketItem>();
        }
    }
}
