﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Features.Commands.Products.Delete
{
    public class DeleteCustomerCommand : IRequest
    {
        public int Id { get; set; }
    }
}
