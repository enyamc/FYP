using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFYP.Core.Models
{
    public class Donation
    {
        public string Id { get; set; }

        [StringLength (20)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }

        public Donation()
        {
            //Generated ID for each donation
            this.Id = Guid.NewGuid().ToString();
        }

    }
}
