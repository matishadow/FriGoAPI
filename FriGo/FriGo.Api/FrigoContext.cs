using System.Data.Entity;
using FriGo.Db.EntityConfigurations;
using FriGo.Db.Models.Ingredients;
using FriGo.Interfaces.Dependencies;

namespace FriGo.Api
{
    public class FrigoContext : DbContext, ISelfRequestDependency
    {       
        public FrigoContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<FrigoContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new IngredientConfiguration());
            modelBuilder.Configurations.Add(new IngredientQuantityConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<IngredientQuantity> IngredientQuantities { get; set; }
    }
}