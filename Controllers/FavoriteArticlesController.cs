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

namespace newsroom.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteArticlesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public FavoriteArticlesController(DatabaseContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
        }

        // GET: api/FavoriteArticles
        [HttpGet(Name = nameof(GetFavoriteeArticles))]
        public async Task<ActionResult<IEnumerable<FavoriteArticleDTo>>> GetFavoriteeArticles()
        {
            IQueryable<FavoriteArticle> favoriteArticles = _context.FavoriteeArticles;

            return await favoriteArticles.Include(a => a.Article).Select(x => favoriteArtileToDTo(x)).ToListAsync();
        }

        // GET: api/FavoriteArticles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FavoriteArticleDTo>> GetFavoriteArticle(int id)
        {
            var favoriteArticle = await _context.FavoriteeArticles.FindAsync(id);

            if (favoriteArticle == null)
            {
                return NotFound();
            }

            return favoriteArtileToDTo(favoriteArticle);
        }


        [HttpPost]
        public async Task<ActionResult<FavoriteArticleDTo>> PostFavoriteArticle(FavoriteArticleDTo favoriteArticleDTo)
        {
            var favoriteArticle = new FavoriteArticle
            {
                userId = favoriteArticleDTo.userId,
                articleId = favoriteArticleDTo.articleId,
            };

            _context.FavoriteeArticles.Add(favoriteArticle);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FavoriteArticleExists(favoriteArticle.articleId))
                {
                    return await DeleteFavoriteArticle(favoriteArticle.Id);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetFavoriteArticle), new { id = favoriteArticle.Id }, favoriteArtileToDTo(favoriteArticle));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFavoriteArticle(int id)
        {
            var favoriteArticle = await _context.FavoriteeArticles.FindAsync(id);
            if (favoriteArticle == null)
            {
                return NotFound();
            }

            _context.FavoriteeArticles.Remove(favoriteArticle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavoriteArticleExists(int id)
        {
            return _context.FavoriteeArticles.Any(e => e.articleId == id);
        }

        private static FavoriteArticleDTo favoriteArtileToDTo(FavoriteArticle favorite) => new FavoriteArticleDTo
        {
            Id = favorite.Id,
            articleId = favorite.articleId,
            userId = favorite.userId,
            Article = favorite.Article,
            UserReader = favorite.UserReader

        };
    }
}
