namespace EmpoweredWoman.Client.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        List<SuperHero> Heroes { get; set; }
        List<Position> Positions { get; set; }
        Task GetPositions();
        Task GetSuperHeroes();
        Task<SuperHero> GetSingleHero(int id);
        Task CreateHero(SuperHero hero);
        Task UpdateHero(SuperHero hero);
        Task DeleteHero(int id);
    }
}
