using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFYP.Core.Models
{
    public class StoreRegistration : BaseEntity
    {
        public string StoreID { get; set; }
        public string StoreName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Eircode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

   
    }
}
