using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFYP.Core.Models
{
    //Adapted from -https://www.udemy.com/course/better-web-development-pro-techniques-for-success/learn/lecture/8533944?start=975#overview
    public class Product : BaseEntity
    {
        

        [StringLength(20)]
        [DisplayName("Product Name")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Range(0, 1000)]
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }

        

    }
}
