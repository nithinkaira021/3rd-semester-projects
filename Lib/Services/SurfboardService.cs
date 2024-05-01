using Lib.Models;

namespace Lib.Services
{
    public class SurfboardService : ISurfboardService
    {
        /// <summary>
        /// A private reference to the storage service from the DI container.
        /// </summary>
        private readonly IStorageService _storageService;
        private readonly WebApiService _apiService;

        /// <summary>
        /// Constructs a product service.
        /// </summary>
        /// <param name="storageService">A reference to the storage service from the DI container.</param>
        public SurfboardService(IStorageService storageService, WebApiService apiService)
        {
            _storageService = storageService;
            _apiService = apiService;
        }

        /// <summary>
        /// Gets a product.
        /// </summary>
        /// <param name="sku">The unique sku reference.</param>
        /// <returns>A <see cref="ProductModel"/> type.</returns>
        public async Task<Surfboard?> GetByIdAsync(int id)
        {
            return await _apiService.GetSurfboardByIdAsync(id);
        }

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>A <see cref="IList<ProductModel>"/> type.</returns>
        public IList<Surfboard> GetAll()
        {
            return _storageService.Surfboards.ToList();
        }

        public async Task<IList<Surfboard>> GetAllAsync()
        {
            return await _apiService.GetSurfboardsAsync("2.0");
        }

        public Surfboard? Get(int id)
        {
            return _storageService.Surfboards.FirstOrDefault(p => p.Id == id);
        }
    }
}
