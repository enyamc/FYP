using MyFYP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFYP.Core.Contracts
{
    public interface ICustomerService
    {
        List<Customer> GetCustomerList();
    }
}
