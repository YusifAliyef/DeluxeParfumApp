﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Features.Commands.Products.Update
{
    public class UpdateAddressCommand:IRequest
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
    }
}
