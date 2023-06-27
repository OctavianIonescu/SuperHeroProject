using SuperHeroProject.Data;
using SuperHeroProject.Entity;

namespace SuperHeroProject.SuperHeroService
{
    public class SuperHeroService : ISuperheroService
    {
        private readonly DataContext _context;
        public SuperHeroService(DataContext context)
        {
            _context = context;
        }
        
        public async Task<List<SuperHero>>? AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>>? DeleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<SuperHero>? EditHero(int id, SuperHero req)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
            {
                return null;
            }
            if (req.heroName != "string") { hero.heroName = req.heroName; }

            if (req.firstName != "string") { hero.firstName = req.firstName; }

            if (req.lastName != "string") { hero.lastName = req.lastName; }

            if (req.place != "string") { hero.place = req.place; }

            await _context.SaveChangesAsync();

            return hero;
        }

        public async Task<List<SuperHero>>? GetAllHeroes()
        {
            var superheroes = await _context.SuperHeroes.ToListAsync();
            return superheroes;
        }

        public async Task<SuperHero>? GetSingleHeroes(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
            {
                return null;
            }
            return hero;
        }
    }
}
