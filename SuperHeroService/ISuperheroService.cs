using SuperHeroProject.Entity;

namespace SuperHeroProject.SuperHeroService
{
    public interface ISuperheroService
    {
        Task<List<SuperHero>>? GetAllHeroes();
        Task<SuperHero>? GetSingleHeroes(int id);
        Task<List<SuperHero>>? AddHero(SuperHero hero);
        Task<SuperHero> ? EditHero(int id, SuperHero req);
        Task<List<SuperHero>> ? DeleteHero(int id);
    }
}
