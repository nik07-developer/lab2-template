using Common.Models.Enums;
using LibraryService.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.Storage.DbContexts;

public class PostgresContext(DbContextOptions<PostgresContext> options) : DbContext(options)
{
    public DbSet<Library> Libraries { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<LibraryBooks> LibraryBooks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LibraryBooks>()
            .HasKey(lb => new { lb.BookId, lb.LibraryId });

        modelBuilder.Entity<LibraryBooks>()
            .HasOne(lb => lb.Book)
            .WithMany(b => b.LibraryBooks)
            .HasForeignKey(lb => lb.BookId);

        modelBuilder.Entity<LibraryBooks>()
            .HasOne(lb => lb.Library)
            .WithMany(l => l.LibraryBooks)
            .HasForeignKey(lb => lb.LibraryId);

        modelBuilder.Entity<Book>()
            .Property(b => b.Condition)
            .HasConversion(
                x => x.ToString().ToUpper(),
                x => (BookCondition)Enum.Parse(typeof(BookCondition), x)
            );
        
        modelBuilder.Entity<Book>()
            .ToTable(t => t.HasCheckConstraint("CHK_Book_Condition", "\"Condition\" IN ('EXCELLENT', 'GOOD', 'BAD')"));

        modelBuilder.Entity<Library>().HasData(
            new Library()
            {
                Id = 1,
                LibraryUid = Guid.Parse("83575e12-7ce0-48ee-9931-51919ff3c9ee"),
                Name = "Библиотека имени 7 Непьющих",
                City = "Москва",
                Address = "2-я Бауманская ул., д.5, стр.1"
            }
        );
        
        modelBuilder.Entity<Book>().HasData(
            new Book()
            {
                Id = 1,
                BookUid = Guid.Parse("f7cdc58f-2caf-4b15-9727-f89dcc629b27"),
                Name = "Краткий курс C++ в 7 томах",
                Author = "Бьерн Страуструп",
                Genre = "Научная фантастика",
                Condition = BookCondition.EXCELLENT
            }
        );

        modelBuilder.Entity<LibraryBooks>().HasData(
            new LibraryBooks() { BookId = 1, LibraryId = 1, AvailableCount = 1}
        );
    }
}