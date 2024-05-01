using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Models
{
    public class ShoppingCart
    {
        /// <summary>
        /// A list of all the items stored in the shopping cart.
        /// </summary>
        public IList<ShoppingCartItem> Items { get; }

        /// <summary>
        /// Constructs a new shopping cart.
        /// </summary>
        public ShoppingCart()
        {
            Items = new List<ShoppingCartItem>();
        }
    }
}