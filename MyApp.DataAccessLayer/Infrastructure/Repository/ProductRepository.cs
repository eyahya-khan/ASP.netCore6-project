using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyAppModels;

namespace MyApp.DataAccessLayer.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public object GetT(int? id)
        {
            throw new NotImplementedException();
        }
        public void Update(Product product)
        {
           var productDB = _context.Products.FirstOrDefault(x => x.Id == product.Id);
            if (productDB != null)
            {
                productDB.Name = product.Name;
                productDB.Description = product.Description;
                productDB.Price = product.Price;
                productDB.Quantity = product.Quantity;
                if(product.ImageUrl != null)
                {
                productDB.ImageUrl = product.ImageUrl;
                }
            }
        }
    }
}
