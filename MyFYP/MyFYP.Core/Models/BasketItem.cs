using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFYP.Core.Models
{
    public class BasketItem : BaseEntity
    {
        //Referencing ID rather than copying details allows for item detail update
        public string BasketId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
