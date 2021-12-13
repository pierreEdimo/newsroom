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
using AutoMapper;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;

namespace newsroom.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class FavoritesArticlesController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mappper; 

        public FavoritesArticlesController(DatabaseContext context, 
                                           IMapper mapper )
        {
            _context = context;
            _mappper = mapper; 
        }

        /// <summary>
        /// all the Favorites Articles
        /// </summary>
        /// <returns>A List of the user's favorites Articles</returns>
        /// <response code="200"> ok </response>
        [HttpGet]
        public async Task<ActionResult<List<FavoriteDTO>>> GetFavorites()
        {
            var favorites = await _context.Favorites.Include(x => x.Article).ToListAsync();

            return _mappper.Map<List<FavoriteDTO>>(favorites); 
        }

        /// <summary>
        /// a single Favorite article
        /// </summary>
        /// <returns> a single Article based on the given Id </returns>
        /// <param name="Id"></param>
        /// <response code="200"> ok </response>
        [HttpGet("{id}")]
        public async Task<ActionResult<FavoriteDTO>> GetFavoritesArticles(int Id)
        {
            var favoritesArticle = await _context.Favorites.FirstOrDefaultAsync(x => x.ArticleId == Id);

            if (favoritesArticle == null)
            {
                return NotFound();
            }

            var favorite = _mappper.Map<FavoriteDTO>(favoritesArticle); 

            return favorite;
        }

        /// <summary>
        /// a filtered list of favorites articles
        /// </summary>
        /// <returns>a filtered list of favorites articles based on the given parameters</returns>
        /// <response code="200"> ok </response>
        [HttpGet("[action]")]
        public async Task<ActionResult<List<FavoriteDTO>>> FilterFavorites([FromQuery] FilterFromUserDTO filter)
        {
            var queryable = _context.Favorites.AsQueryable();

            if (!String.IsNullOrWhiteSpace(filter.UserId))
            {
                queryable = queryable.Where(x => x.OwnerId.Contains(filter.UserId)); 
            }

            if (!String.IsNullOrWhiteSpace(filter.sortBy))
            {
                if (typeof(FavoritesArticles).GetProperty(filter.sortBy) != null)
                {
                    queryable = queryable.OrderByCustom(filter.sortBy, filter.SortOrder);
                }
            }

            queryable = queryable.Take(filter.Size);

            var favorites = await queryable.Include(x => x.Article).ToListAsync();

            return _mappper.Map<List<FavoriteDTO>>(favorites); 
        }


        /// <summary>
        /// a filtered list of favorites articles
        /// </summary>
        /// <returns>a filtered list of favorites articles based on the given parameters</returns>
        /// <response code="200"> ok </response>
        [HttpGet("[action]")]
        public async Task<ActionResult<bool>> IsFavorite([FromQuery] IsFavoriteCheckerDTo favChecker)
        {
            var favs = await _context.Favorites.ToListAsync(); 

            bool isFavorite = false;

            foreach(FavoritesArticles fav in favs)
            {
                if(favChecker.articleId == fav.ArticleId && favChecker.userId.Equals(fav.OwnerId))
                {
                    isFavorite = true; 
                }
            }

            return isFavorite; 
        }


        /// <summary>
        /// add an article in thier favorites
        /// </summary>
        /// <param name="addFavoriteDTO"></param>
        /// <returns>a newly added article in favorites</returns>
        /// <response code="201"> created </response>
        [HttpPost]
        public async Task<ActionResult> PostFavoritesArticles(AddFavoriteDTO addFavoriteDTO)
        {
            var favorite = _mappper.Map<FavoritesArticles>(addFavoriteDTO);

            _context.Add(favorite); 
           
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FavoritesArticlesExists(favorite.ArticleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            var favoriteDTO = _mappper.Map<FavoriteDTO>(favorite); 

            return CreatedAtAction("GetFavoritesArticles", new { id = favoriteDTO.ArticleId }, favoriteDTO );
        }

        /// <summary>
        /// remove an Article
        /// </summary>
        /// <returns>an empty object</returns>
        /// <response code="204"> No Content </response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoritesArticles(int Id)
        {
            var article = await  _context.Favorites.FirstOrDefaultAsync(x => x.ArticleId == Id); 

            if(article == null)
            {
                return NotFound(); 
            }

            _context.Favorites.RemoveRange(article);
            await _context.SaveChangesAsync(); 

            return NoContent();
        }

        private bool FavoritesArticlesExists(int id)
        {
            return _context.Favorites.Any(e => e.ArticleId == id);
        }
    }
}
