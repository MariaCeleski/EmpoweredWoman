using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;


namespace EmpoweredWoman.Client.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public SuperHeroService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        
        public List<SuperHero> Heroes { get; set; } = new List<SuperHero>();
        public List<Position> Positions { get; set; } = new List<Position>();

        public Task CreateHero(SuperHero hero)
        {
            throw new NotImplementedException();
        }

        public Task DeleteHero(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetPositions()
        {
            throw new NotImplementedException();
        }

        public Task<SuperHero> GetSingleHero(int id)
        {
            throw new NotImplementedException();
        }

       

        public Task UpdateHero(SuperHero hero)
        {
            throw new NotImplementedException();
        }

        public async Task GetSuperHeroes()
        {
            var result = await _http.GetFromJsonAsync<List<SuperHero>>("api/superhero");
            if (result != null)
                Heroes = result;
        }
    }
}
