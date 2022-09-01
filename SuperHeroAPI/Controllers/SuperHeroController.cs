using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
{
        /*
        private static List<SuperHero> heroes = new List<SuperHero>
        {
            new SuperHero {
                Id = 1, 
                Name = "Spider Man",
                FirstName = "Peter",
                LastName = "Parker",
                Place = "New York City"
            },
              new SuperHero {
                Id = 2,
                Name = "Iron Man",
                FirstName = "Tony",
                LastName = "stark",
                Place = "Long Island"
            },
        };
        */
        // constructor
        private readonly DataContext _context;
        public SuperHeroController(DataContext context)
        {
            _context = context;
        }


        // GET all
        [HttpGet]
        public  async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await _context.SuperHeroes.ToListAsync());  // Ok 200 status response
        }

        // GET id
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = _context.SuperHeroes.FindAsync(id);
            if (hero == null)
                return BadRequest("Hero not found");
            return Ok(hero);  // Ok 200 status response
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());  // Ok 200 status response
        }

        //PUT
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var DbHero = await _context.SuperHeroes.FindAsync(request.Id);
            if (DbHero == null)
                return BadRequest("Hero not found");

            DbHero.Name = request.Name;
            DbHero.FirstName = request.FirstName;
            DbHero.LastName = request.LastName;
            DbHero.Place = request.Place;
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());  // Ok 200 status response
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var DbHero = await _context.SuperHeroes.FindAsync(id);
            if (DbHero == null)
                return BadRequest("Hero not found");

            _context.SuperHeroes.Remove(DbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());  // Ok 200 status response
        }

    }
}
