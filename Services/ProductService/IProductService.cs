namespace ProductApi.ProductService
{
    public interface IProductService
    {
        Task<List<Product>?> GetAllList();        
        Task<Product?> GetProductById(int id);
        Task<List<Product>?> PostProduct(Product product);
        Task<List<Product>?> DeleteProductById(int id);
        Task<List<Product>?> UpdateProduct(int id, Product product);

    }
}
