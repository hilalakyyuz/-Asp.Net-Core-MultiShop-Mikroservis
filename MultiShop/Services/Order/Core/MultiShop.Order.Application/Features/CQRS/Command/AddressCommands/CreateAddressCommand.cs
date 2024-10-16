using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Command.AddressCommand
{
    public class CreateAddressCommand
    {
        public String UserID { get; set; }
        public String District { get; set; }
        public String City { get; set; }
        public String Detail { get; set; }
    }
}
