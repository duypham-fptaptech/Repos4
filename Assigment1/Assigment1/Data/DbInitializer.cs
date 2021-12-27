using Assigment1.Models;

namespace Assigment1.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {

            context.Database.EnsureCreated();
            // Look for any students.
            if (context.Category.Any())
            {
                return;   // DB has been seeded
            }
            var categories = new Category[]
{
            new Category{CatName="Book"},
            new Category{CatName="Toy"},
};
            foreach (Category c in categories)
            {
                context.Category.Add(c);
            }
            context.SaveChanges();

            var products = new Product[]
            {
            new Product{ProductName="One Piece", Price=100, Unit=1, Status=1},
            new Product{ProductName="One Piece", Price=200, Unit=2, Status=1},
            new Product{ProductName="One Piece", Price=300, Unit=3, Status=1},
            new Product{ProductName="One Piece Toy", Price=400, Unit=1, Status=1},
            new Product{ProductName="One Piece Toy", Price=500, Unit=2, Status=1},
            new Product{ProductName="One Piece Toy", Price=600, Unit=3, Status=1},
            };
            foreach (Product s in products)
            {
                context.Product.Add(s);
            }
            context.SaveChanges();
        }
    }
}
