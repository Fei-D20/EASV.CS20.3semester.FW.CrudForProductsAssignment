using EASV.CS20._3semester.FW.CrudForProductsAssignment.Database.Entities;

namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.Database
{
    public class DbSeeder
    {
        private readonly ApplicationContext _context;

        public DbSeeder(ApplicationContext context)
        {
            _context = context;
        }

        public void SeedDevelopment()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _context.Products.Add(new ProductEntity() { Id = 1, Name = "Product001" });
            _context.Products.Add(new ProductEntity() { Id = 2, Name = "Product002" });
            _context.Products.Add(new ProductEntity() { Id = 3, Name = "Product003" });
            _context.Products.Add(new ProductEntity() { Id = 4, Name = "Product004" });
            _context.SaveChanges();
        }
    }
}