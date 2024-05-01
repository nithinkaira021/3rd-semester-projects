using Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services
{
    /// <summary>
    /// Stores the data used for the application.
    /// </summary>
    public class StorageService : IStorageService
    {
        /// <summary>
        /// Stores a list of products.
        /// </summary>
        public IList<Surfboard> Surfboards { get; private set; }

        /// <summary>
        /// Stores the shopping cart.        
        /// </summary>
        public ShoppingCart ShoppingCart { get; private set; }

        /// <summary>
        ///  Constructs a storage service.
        /// </summary>
        public StorageService()
        {
            Surfboards = new List<Surfboard>();
            ShoppingCart = new ShoppingCart();

            string hexValue = "20";
            int decimalValue = Convert.ToInt32(hexValue, 16);

            byte myByte = 10;
            byte[] byteArray = new byte[] { myByte };
            AddProduct(new Surfboard(2, "Name", 2.0, 4.0, 1.0, 2.5, "Longboard", decimalValue, "udstyr", "img.jpg", null, byteArray));
        }

        /// <summary>
        /// Adds a product to the storage.
        /// </summary>
        /// <param name="productModel">The <see cref="ProductModel"/> type to be added.</param>
        public void AddProduct(Surfboard surfboard)
        {
            if (!Surfboards.Any(p => p.Id == surfboard.Id))
            {
                Surfboards.Add(surfboard);
            }
        }
    }
}
