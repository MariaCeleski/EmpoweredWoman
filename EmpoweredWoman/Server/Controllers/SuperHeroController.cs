using EmpoweredWoman.Server.Data;
using EmpoweredWoman.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpoweredWoman.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        //public static List<Position> positions = new List<Position>
        //{
        //    new Position{ Id = 1, Name = "Developer"},
        //    new Position{ Id = 2, Name = "Teacher" },
        //    new Position{ Id = 3, Name = "Assistant" },
        //    new Position{ Id = 4, Name = "Administrative" },
        //    new Position{ Id = 5, Name = "Principal" }
        //};

        //public static List<SuperHero> heroes = new List<SuperHero>
        //{
        //    new SuperHero
        //    {
        //        Id = 1,
        //        FirstName = "Maria",
        //        LastName = "Celeski",
        //        Country = "Brazil",
        //        Company = "PrograMaria",
        //        FinancialBank = "",
        //        Actions = "",
        //        Position = positions[0],
        //        PositionId = 1,
        //    },

        //    new SuperHero
        //    {
        //        Id = 2,
        //        FirstName = "Jessica",
        //        LastName = "Matheus",
        //        Country = "Brazil",
        //        Company = "PyLadies",
        //        FinancialBank = "",
        //        Actions = "",
        //        Position = positions[1],
        //        PositionId = 2,
        //    },
        //};
        private readonly DataContext _Context;
        public SuperHeroController(DataContext Context)
        {
            _Context = Context;

        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        {
            var heroes = await _context.SuperHeroes.Include(sh => sh.Position).ToListAsync();
            return Ok(heroes);
        }

        [HttpGet("positions")]
        public async Task<ActionResult<List<Position>>> GetPositions()
        {
            var positions = await _context.Positions.ToListAsync();
            return Ok(positions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var hero = await _context.SuperHeroes
                .Include(h => h.Position)
                .FirstOrDefaultAsync(h => h.Id == id);
            if (hero == null)
            {
                return NotFound("Sorry, no hero here. :/");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> CreateSuperHero(SuperHero hero)
        {
            hero.Position = null;
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await GetDbHeroes());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateSuperHero(SuperHero hero, int id)
        {
            var dbHero = await _context.SuperHeroes
                .Include(sh => sh.Position)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbHero == null)
                return NotFound("Sorry, but no hero for you. :/");

            dbHero.FirstName = hero.FirstName;
            dbHero.LastName = hero.LastName;
            dbHero.Country = hero.Country;
            dbHero.Company = hero.Company;
            dbHero.FinancialBank = hero.FinancialBank;
            dbHero.Actions = hero.Actions;
            dbHero.PositionId = hero.PositionId;

            await _context.SaveChangesAsync();

            return Ok(await GetDbHeroes());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero(int id)
        {
            var dbHero = await _context.SuperHeroes
                .Include(sh => sh.Position)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbHero == null)
                return NotFound("Sorry, but no hero for you. :/");

            _context.SuperHeroes.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await GetDbHeroes());
        }

        private async Task<List<SuperHero>> GetDbHeroes()
        {
            return await _context.SuperHeroes.Include(sh => sh.Position).ToListAsync();
        }
    }
}


