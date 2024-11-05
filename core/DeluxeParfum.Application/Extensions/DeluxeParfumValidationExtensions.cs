using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Extentions
{
    public class DeluxeParfumValidationExtensions:ApplicationException
    {
        public DeluxeParfumValidationExtensions(string message)
          : base($"Deluxe Parfum project exception: {message} ")
        {

        }
    }
}
