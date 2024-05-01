using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Models
{
    public class Guest
    {
        public ICollection<Rental>? Rentals { get; set; }

        [DataType(DataType.EmailAddress), Key]
        public string Email { get; set; }

    }
}
