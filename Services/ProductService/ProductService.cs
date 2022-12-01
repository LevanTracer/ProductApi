using Microsoft.EntityFrameworkCore;

namespace ProductApi.ProductService
{
    public class ProductService : IProductService
    {

        List<Product> products = new List<Product>() {
            new Product()
            {
            Id=1,
            Name="Cola",
            Description="Good Cola",
            Price=2.5f
            },
            new Product()
            {
                Id=2,
                Name="Fanta",
                Description="Good Fanta",
                Price=3.5f
            },
            new Product()
            {
                Id =1,
                Name="Sprite",
                Description="Good Sprite",
                Price=4.5f
            }

         };


        private readonly DataContext _context;
        public ProductService(DataContext context)
        {
            _context = context;
        }


        public async Task<List<Product>?> DeleteProductById(int id)
        {
            var removeItem = await _context.Products.FindAsync(id);
            if (removeItem == null)
                return null;
            _context.Products.Remove(removeItem);
            await _context.SaveChangesAsync();

            return await _context.Products.ToListAsync();

        }

        public async Task<List<Product>?> GetAllList()
        {
            return await _context.Products.ToListAsync();

        }

        public async Task<Product?> GetProductById(int id)
        {
            var result = await _context.Products.FindAsync(id);
            if (result == null)
                return null;
            return result;
        }

        public async Task<List<Product>?> PostProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return await _context.Products.ToListAsync();
        }
          
            public async Task<List<Product>?> UpdateProduct(int id, Product product)
        {
            var updateItem = await _context.Products.FindAsync(id);
            if (updateItem == null)
                return null;
            updateItem.Description = product.Description;
            updateItem.Price = product.Price;
            updateItem.Name = product.Name;
            updateItem.Id = product.Id;
            await _context.SaveChangesAsync();
            return await _context.Products.ToListAsync();

        }
    }
}

      