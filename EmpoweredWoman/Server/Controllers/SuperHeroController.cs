using EmpoweredWoman.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpoweredWoman.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        public static List<Position> positions = new List<Position>
        {
            new Position{ Id = 1, Name = "Developer"},
            new Position{ Id = 2, Name = "Teacher" },
            new Position{ Id = 3, Name = "Assistant" },
            new Position{ Id = 4, Name = "Administrative" },
            new Position{ Id = 5, Name = "Principal" }
        };

        public static List<SuperHero> heroes = new List<SuperHero>
        {
            new SuperHero
            {
                Id = 1,
                FirstName = "Maria",
                LastName = "Celeski",
                Country = "Brazil",
                Company = "PrograMaria",
                FinancialBank = "",
                Actions = "",
                LocalActions = "",
                Position = positions[0]
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
                LocalActions = "",
                Position = positions[1]

            },
        };
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        {
            
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var hero = heroes.FirstOrDefault(h => h.Id == id);
            if (hero == null)
            {
                return NotFound("Sorry, no hero here. :/");
            }
            return Ok(hero);
        }
    }
}

