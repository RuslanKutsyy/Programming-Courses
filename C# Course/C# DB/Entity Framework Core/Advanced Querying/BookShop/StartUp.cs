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
            DbInitializer.ResetDatabase(db);

            Console.WriteLine(GetGoldenBooks(db));
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
    }
}
