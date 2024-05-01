﻿using Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services
{
    /// <summary>
    /// Used for shopping cart methods.
    /// </summary>
    public interface IShoppingCartService
    {
        /// <summary>
        /// Gets the shopping cart.
        /// </summary>
        /// <returns>The shopping cart as a <see cref="ShoppingCartModel"/> type.</returns>
        /// <exception cref="Exception">Returns an exception if the shopping cart cannot be found.</exception>
        ShoppingCart Get();

        /// <summary>
        /// Adds a product to the current shopping cart.
        /// </summary>
        /// <param name="product">An instance of the product</param>
        /// <param name="quantity">The quantity they wish to add.</param>
        void AddProduct(Surfboard surfboard, int quantity);

        /// <summary>
        /// Deletes a product from the shopping cart
        /// </summary>
        /// <param name="item">An instance of the shopping cart item</param>
        void DeleteProduct(ShoppingCartItem item);

        /// <summary>
        /// Gets the number of items added to the current shopping cart.
        /// </summary>
        /// <returns>The total number of items.</returns>
        int Count();

        /// <summary>
        /// Has a product been added to the shopping cart?
        /// </summary>
        /// <param name="sku">The unique identifier of the product.</param>
        /// <returns>A <see cref="bool"/> type which determines whether the product has been added to the shopping cart.</returns>
        bool HasProduct(int id);
    }
}
