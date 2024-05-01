using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Models
{
    public interface IProductAddToCart
    {
        // An instance of the product
        Surfboard? Surfboard { get; set; }

        // The quantity wishing to be added to the cart
        int? Quantity { get; set; }

        /// <summary>
        /// The method to add a product to cart
        /// </summary>
        void AddToCart();
    }
}
