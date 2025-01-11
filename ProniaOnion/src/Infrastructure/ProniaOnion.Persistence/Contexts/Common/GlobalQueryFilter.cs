using Microsoft.EntityFrameworkCore;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Persistence.Contexts.Common
{
    public static class GlobalQueryFilter
    {
        public static void ApplyFilter<T>(this ModelBuilder modelBuilder) where T : BaseEntity, new()
        {
            modelBuilder.Entity<T>().HasQueryFilter(c => c.IsDeleted == false);
        }


        public static void ApplyAllFilters(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyFilter<Category>();
            modelBuilder.ApplyFilter<Product>();
            modelBuilder.ApplyFilter<Size>();
            modelBuilder.ApplyFilter<Color>();
            modelBuilder.ApplyFilter<Tag>();
            modelBuilder.ApplyFilter<Genre>();
            modelBuilder.ApplyFilter<Author>();
            modelBuilder.ApplyFilter<Blog>();


        }
    }
}
