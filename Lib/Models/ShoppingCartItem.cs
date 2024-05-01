namespace Lib.Models
{
    /// <summary>
    /// Stores a shopping cart item.
    /// </summary>
    public class ShoppingCartItem
    {
        /// <summary>
        /// Product type.
        /// </summary>
        public Surfboard Surfboard { get; }

        /// <summary>
        /// Price of the product.
        /// </summary>
        public decimal Price { get; protected set; }

        /// <summary>
        /// Quantity of the product.
        /// </summary>
        public int Quantity { get; protected set; }

        /// <summary>
        /// Get the total price of the product.
        /// </summary>
        public decimal TotalPrice
        {
            get
            {
                return Price * Quantity;
            }
        }

        /// <summary>
        /// Constructs a new shopping cart item.
        /// </summary>
        /// <param name="product">Product type.</param>
        /// <param name="quantity">Quantity of the product.</param>
        public ShoppingCartItem(Surfboard surfboard, int quantity)
        {
            Surfboard = surfboard;
            Price = surfboard.Price;
            Quantity = quantity;
        }

        /// <summary>
        /// Updates the quantity and the price.
        /// </summary>
        /// <param name="product">Product type.</param>
        /// <param name="quantity">Quantity of the product.</param>
        public void UpdateQuantity(Surfboard surfboard, int quantity)
        {
            Price = surfboard.Price;
            Quantity += quantity;
        }
    }
}
