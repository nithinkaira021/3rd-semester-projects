using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Models;

namespace Lib.Services
{
    public interface IStorageService
    {
        /// <summary>
        /// Stores a list of products.
        /// </summary>
        IList<Surfboard> Surfboards { get; }

        /// <summary>
        /// Stores the shopping cart.
        /// </summary>
        ShoppingCart ShoppingCart { get; }

    }
}
