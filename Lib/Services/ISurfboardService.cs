using Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services
{
    public interface ISurfboardService
    {
        /// <summary>
        /// Gets a product.
        /// </summary>
        /// <param name="sku">The unique sku reference.</param>
        /// <returns>A <see cref="ProductModel"/> type.</returns>
        Surfboard? Get(int id);

        /// <summary>
        /// Get a product by slug.
        /// </summary>
        /// <param name="slug">The slug of the product</param>
        /// <returns></returns>
        Task<Surfboard?> GetByIdAsync(int id);

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>A <see cref="IList<ProductModel>"/> type.</returns>
        Task<IList<Surfboard>> GetAllAsync();
        IList<Surfboard> GetAll();

    }
}
