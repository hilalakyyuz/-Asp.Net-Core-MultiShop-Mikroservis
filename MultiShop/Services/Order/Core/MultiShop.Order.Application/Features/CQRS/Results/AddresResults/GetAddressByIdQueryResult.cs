﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Results.AddresResults
{
    public class GetAddressByIdQueryResult
    {
        public int AddressID { get; set; }
        public String UserID { get; set; }
        public String District { get; set; }
        public String City { get; set; }
        public String Detail { get; set; }
    }
}
