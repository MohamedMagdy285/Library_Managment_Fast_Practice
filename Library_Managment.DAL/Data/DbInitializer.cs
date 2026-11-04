using Library_Managment.DAL.Context;
using Library_Managment.DAL.Models;

namespace Library_Managment.DAL.Data
{
    public static class DbInitializer
    {
        public static void Seed(Library_ManagmentDbContext context)
        {
            if (context.Authors.Any())
                return;

            context.Authors.AddRange(
                new Author
                {
                    Name = "Naguib Mahfouz",
                    Biography = "Egyptian novelist",
                    BirthDate = new DateTime(1911, 12, 11)
                },
                new Author
                {
                    Name = "Ahmed Khaled Tawfik",
                    Biography = "Egyptian writer",
                    BirthDate = new DateTime(1962, 6, 10)
                },
                new Author
                {
                    Name = "Agatha Christie",
                    Biography = "Mystery writer",
                    BirthDate = new DateTime(1890, 9, 15)
                },
                new Author
                {
                    Name = "George Orwell",
                    Biography = "English novelist",
                    BirthDate = new DateTime(1903, 6, 25)
                },
                new Author
                {
                    Name = "J. K. Rowling",
                    Biography = "British author",
                    BirthDate = new DateTime(1965, 7, 31)
                }
            );

            context.SaveChanges();
        }
    }
}