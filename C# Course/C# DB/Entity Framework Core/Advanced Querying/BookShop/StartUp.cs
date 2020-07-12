namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            int year = int.Parse(Console.ReadLine());
            Console.WriteLine(GetBooksNotReleasedIn(db, year));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();
            var restrictionRate = Enum.Parse<AgeRestriction>(command, true);
            context.Books.Where(x => x.AgeRestriction == restrictionRate)
                .OrderBy(x => x.Title)
                .Select(x => new
                {
                    x.Title
                }).ToList().ForEach(x => sb.AppendLine(x.Title));

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            context.Books.Where(x => x.EditionType == EditionType.Gold && x.Copies < 5000)
                .OrderBy(x => x.BookId).Select(x => new
                {
                    x.Title
                })
                .ToList().ForEach(x => sb.AppendLine(x.Title));

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            context.Books.Where(x => x.Price > 40)
                .OrderByDescending(x => x.Price)
                .Select(x => new
                {
                    x.Title,
                    x.Price
                }).ToList().ForEach(x => sb.AppendLine($"{x.Title} - ${x.Price:F2}"));

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();

            context.Books.Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId).Select(x => new
                {
                    x.Title
                }).ToList().ForEach(x => sb.AppendLine(x.Title));

            return sb.ToString().TrimEnd();
        }
    }
}
