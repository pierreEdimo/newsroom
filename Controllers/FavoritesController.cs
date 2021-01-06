using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newsroom.DBContext;
using newsroom.DTO;
using newsroom.Model;
using newsroom.QueryClasses;

namespace newsroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public FavoritesController(DatabaseContext context)
        {
            _context = context;

            _context.Database.EnsureCreated(); 
        }

        // GET: api/Favorites
        [HttpGet(Name = nameof(GetAllFavorites))]
        public async Task<ActionResult<IEnumerable<FavoriteDTo>>> GetAllFavorites( [FromBody] NewRoomQueryParameters queryParameter )
        {
            IQueryable<Favorites> favs = _context.Favorites;

            if (!string.IsNullOrEmpty(queryParameter.sortBy))
            {
                if (typeof(Favorites).GetProperty(queryParameter.sortBy) != null)
                {
                    favs = favs.OrderByCustom(queryParameter.sortBy, queryParameter.SortOrder);
                }
            }

            if (!string.IsNullOrEmpty(queryParameter.userId.ToString()))
            {
                favs = favs.Where(p => p.userId.ToString().Contains(queryParameter.userId.ToString()));
            }

            return await favs.Include(a => a.Article)
                               .ThenInclude(a => a.Author)
                              .Include(a => a.Article)
                                .ThenInclude(a => a.Comments)
                             .Select(x => favoriteToDTo(x)).ToListAsync(); 
        }

        // GET: api/Favorites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FavoriteDTo>> GetFavorites(int id)
        {
            IQueryable<Favorites> favs = _context.Favorites; 

            var favorites = await favs.Include(x => x.Article).FirstOrDefaultAsync(x => x.articleId == id ) ;

            if (favorites == null)
            {
                return NotFound();
            }

            return favoriteToDTo(favorites);
        }

   
        // POST: api/Favorites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FavoriteDTo>> PostFavorites(FavoriteDTo favDTo)
        {
            var fav = new Favorites
            {
                articleId = favDTo.articleId, 
                userId = favDTo.userId
            }; 

            _context.Favorites.Add(fav);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FavoritesExists(fav.articleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetFavorites), new { id = fav.articleId }, fav);
        }

        // DELETE: api/Favorites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavorites(int id)
        {
            var favorites = await _context.Favorites.FindAsync(id);
            if (favorites == null)
            {
                return NotFound();
            }

            _context.Favorites.Remove(favorites);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private static FavoriteDTo favoriteToDTo(Favorites favorites) => new FavoriteDTo
        {
            articleId = favorites.articleId,
            Article = favorites.Article,
            User = favorites.User,
            userId = favorites.userId
        }; 

        private bool FavoritesExists(int id)
        {
            return _context.Favorites.Any(e => e.articleId == id);
        }
    }
}
