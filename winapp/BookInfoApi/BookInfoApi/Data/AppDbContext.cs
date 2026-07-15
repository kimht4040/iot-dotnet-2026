using Microsoft.EntityFrameworkCore;
using BookInfoApi.Models; // CS0105 경고: 이 줄이 두 번 적혀 있어서 난 경고였습니다. 하나만 남겨주세요!

namespace BookInfoApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}