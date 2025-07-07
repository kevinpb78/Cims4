using Cims4.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cims4.Infrastructure.Data
{
    public class CardinalDbContext : DbContext
    {
        public CardinalDbContext(DbContextOptions<CardinalDbContext> options) : base(options)
        {
        }

        // DbSets 
        public DbSet<Brokerage> Brokerages { get; set; }
        public DbSet<BrokerageBranch> BrokerageBranches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply soft delete filter globally
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType) || typeof(BaseMasterEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .HasQueryFilter(GetSoftDeleteFilter(entityType.ClrType));
                }
            }

            // Apply all configurations from assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CardinalDbContext).Assembly);
        }

        private static LambdaExpression GetSoftDeleteFilter(Type entityType)
        {
            var parameter = Expression.Parameter(entityType, "e");
            var property = Expression.Property(parameter, nameof(BaseEntity.IsDeleted));
            var condition = Expression.Equal(property, Expression.Constant(false));
            return Expression.Lambda(condition, parameter);
        }
    }
}
