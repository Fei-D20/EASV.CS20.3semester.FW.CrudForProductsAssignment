using EASV.CS20._3semester.FW.CrudForProductsAssignment.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.Database
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> opt): base(opt)
        {
        }
        
        public virtual DbSet<ProductEntity> Products { get; set; }
    }
}