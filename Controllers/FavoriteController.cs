using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newsroom.DBContext;
using newsroom.Model;
using newsroom.DTO;
using Microsoft.AspNetCore.Authorization;
using newsroom.QueryClasses;

namespace newsroom.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public FavoriteController(DatabaseContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
        }

        // GET: api/FavoriteArticles
        [HttpGet(Name = nameof(GetFavoriteeArticles))]
        public async Task<ActionResult<IEnumerable<FavoriteDTo>>> GetFavoriteeArticles([FromQuery] DoctorQueryParameter queryParameters)
        {
            IQueryable<Favorite> favorites = _context.Favorites;

            if (!string.IsNullOrEmpty(queryParameters.userId))
            {
                favorites = favorites.Where(
                    p => p.userId.ToLower().Contains(queryParameters.userId.ToLower())
                );
            }

            return await favorites.Include(a => a.Article)
                                     .ThenInclude(a => a.Author)
                                  .Include(a => a.Article )
                                     .ThenInclude(a => a.Comments)
                   .Select(x => favoriteArtileToDTo(x)).ToListAsync();
        }

        // GET: api/FavoriteArticles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FavoriteDTo>> GetFavoriteArticle(int id)
        {
            IQueryable<Favorite> favorites = _context.Favorites;

            var favoriteArticle = await favorites.Include(a => a.Article)
                                                    .ThenInclude(a => a.Author )
                                                 .Include(a => a.Article )
                                                    .ThenInclude(a => a.Comments)
                     .FirstOrDefaultAsync(x => x.articleId == id) ;

            if (favoriteArticle == null)
            {
                return NotFound();
            }

            return favoriteArtileToDTo(favoriteArticle);
        }


        [HttpPost]
        public async Task<ActionResult<FavoriteDTo>> PostFavoriteArticle(FavoriteDTo favoriteArticleDTo)
        {
            var favoriteArticle = new Favorite
            {
                userId = favoriteArticleDTo.userId,
                articleId = favoriteArticleDTo.articleId,
            };

            _context.Favorites.Add(favoriteArticle);
            await _context.SaveChangesAsync();


            return CreatedAtAction(nameof(GetFavoriteArticle), new { id = favoriteArticle.articleId },  favoriteArtileToDTo(favoriteArticle));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFavoriteArticle(int id)
        {
            var favoriteArticle = await _context.Favorites.FindAsync(id);
            if (favoriteArticle == null)
            {
                return NotFound();
            }

            _context.Favorites.Remove(favoriteArticle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavoriteArticleExists(int id)
        {
            return _context.Favorites.Any(e => e.articleId == id);
        }

        private static FavoriteDTo favoriteArtileToDTo(Favorite favorite) => new FavoriteDTo
        {

            articleId = favorite.articleId,
            userId = favorite.userId,
            Article = favorite.Article,


        };
    }
}
