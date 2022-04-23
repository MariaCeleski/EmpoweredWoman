namespace EmpoweredWoman.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().HasData(
               new Position { Id = 1, Name = "Developer" },
               new Position { Id = 2, Name = "Teacher" },
               new Position { Id = 3, Name = "Assistant" },
               new Position { Id = 4, Name = "Administrative" },
               new Position { Id = 5, Name = "Principal" }
            );

            modelBuilder.Entity<SuperHero>().HasData(
               new SuperHero
               {
                   Id = 1,
                   FirstName = "Maria",
                   LastName = "Celeski",
                   Country = "Brazil",
                   Company = "PrograMaria",
                   FinancialBank = "",
                   Actions = "",
                   PositionId = 1
               },

                new SuperHero
                {
                    Id = 2,
                    FirstName = "Jessica",
                    LastName = "Matheus",
                    Country = "Brazil",
                    Company = "PyLadies",
                    FinancialBank = "",
                    Actions = "",
                    PositionId = 2
                }
                );
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }

        public DbSet<Position> Positions { get; set; }
    }
}
    

