using System; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newsroom.DBContext;
using newsroom.DTO;
using newsroom.Model;
using System.IO;
using newsroom.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace newsroom.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ArticlesController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;
        private String containerName = "Article"; 

        public ArticlesController(DatabaseContext context, 
                                  IMapper mapper, 
                                  IFileStorageService fileStorageService
                                  )
        {
            _context = context;
            _mapper = mapper;
            _fileStorageService = fileStorageService; 
        }

        /// <summary>
        /// all the Articles
        /// </summary>
        /// <returns>A List of Articles</returns>
        /// <response code="200"> ok </response>     
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<ArticleDTO>>> GetArticles( )
        {
            var queryable = _context.Articles.AsQueryable();

           

            var articles = await queryable.Include(x => x.Author)
                                          .Include(x => x.Topic)
                                          .Include(x => x.HasFavorites)
                                          .ToListAsync();

            var articleDTO = _mapper.Map<List<ArticleDTO>>(articles);

            return articleDTO; 
        }

        /// <summary>
        /// filtered list of Articles, based on the given parameters
        /// </summary>
        /// <returns>A Filtered List of Articles</returns>
        /// <param name="filterDTO"></param>
        /// <response code="200"> ok </response>
        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<List<ArticleDTO>>> Filter([FromQuery] FilterArticleDTO filterDTO)
        {
            var articleQueryable = _context.Articles.AsQueryable();


            if (!String.IsNullOrWhiteSpace(filterDTO.sortBy))
            {
                if(typeof(Article).GetProperty(filterDTO.sortBy) != null)
                {
                    articleQueryable = articleQueryable.OrderByCustom(filterDTO.sortBy, filterDTO.SortOrder); 
                }
            }

            if (!String.IsNullOrWhiteSpace(filterDTO.Title))
            {
                articleQueryable = articleQueryable.Where(x => x.Title.ToLower().Contains(filterDTO.Title.ToLower())); 
            }

            if(filterDTO.TopicId != 0)
            {
                articleQueryable = articleQueryable
                          .Where(x => x.Topic.Id == filterDTO.TopicId ); 
            }

            if (!String.IsNullOrWhiteSpace(filterDTO.Author))
            {
                articleQueryable = articleQueryable.Where(x => x.Author.Name.ToLower().Contains(filterDTO.Author.ToLower())); 
            }

            articleQueryable = articleQueryable.Take(filterDTO.Size); 

            var articles = await articleQueryable.Include(x => x.Author)
                                                 .Include(x => x.Topic)
                                                 .Include(x => x.Comments)
                                                 .Select(x => new Article()
                                                 {
                                                     Id = x.Id, 
                                                     Author = x.Author ,
                                                     AuthorId = x.AuthorId, 
                                                     Comments = x.Comments, 
                                                     Content = x.Content, 
                                                     CreatedAt = x.CreatedAt, 
                                                     ImageCredits = x.ImageCredits, 
                                                     ImageUrl = x.ImageUrl, 
                                                     HasFavorites = x.HasFavorites, 
                                                     Title = x.Title,
                                                     CommentCount = x.Comments.Count() != 0 ? x.Comments.Count() : 0,
                                                     Topic = x.Topic,
                                                     TopicId = x.TopicId, 
                                                 })
                                                 .ToListAsync();

            return _mapper.Map<List<ArticleDTO>>(articles); 
        }

        /// <summary>
        /// single Article
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="UserId"></param>
        /// <returns>return a single Article based on the given Id</returns>
        // GET: api/Articles/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ArticleDTO>> GetArticle(int Id , [FromQuery] string UserId)
        {
            var article = await _context.Articles.Include(x => x.Author)
                                                 .Include(x => x.Topic)
                                                 .Include(x => x.Comments)
                                                 .Include(x => x.HasFavorites)
                                                 .FirstOrDefaultAsync(x => x.Id == Id);

            article.CommentCount = article.Comments.Count();
            article.IsFavorite = UserId == null ? false : CheckIsFavorite(Id, UserId); 

            if (article == null) return NotFound();
          
            var articleDTO = _mapper.Map<ArticleDTO>(article); 

            return articleDTO;
        }

        /// <summary>
        /// update an Article 
        /// </summary>
        /// <returns>An Article with the modified informations</returns>
        /// <param name="updateArticle"></param>
        /// <param name="Id"></param>
        /// <response code="204"> no content </response>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticle(int Id, [FromForm] CreateArticleDTO updateArticle )
        {
            var articleDB = await _context.Articles.FirstOrDefaultAsync(x => x.Id == Id); 

            if(articleDB == null)
            {
                return NotFound(); 
            }

            articleDB = _mapper.Map(updateArticle, articleDB); 

            if(updateArticle.ImageUrl != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await updateArticle.ImageUrl.CopyToAsync(memoryStream);
                    var content = memoryStream.ToArray();
                    var extension = Path.GetExtension(updateArticle.ImageUrl.FileName);
                    articleDB.ImageUrl = await _fileStorageService.EditFile(content, extension, containerName, articleDB.ImageUrl, updateArticle.ImageUrl.ContentType); 
                }
            }

            await _context.SaveChangesAsync(); 

            return NoContent();
        }

        /// <summary>
        /// create a new Article 
        /// </summary>
        /// <returns>A newly created Article</returns>
        /// <param name="createArticleDTO"></param>
        /// <response code="201"> Article has been successfully created </response>
        [HttpPost]
        public async Task<ActionResult> PostArticle([FromForm] CreateArticleDTO createArticleDTO )
        {
            var article = _mapper.Map<Article>(createArticleDTO);

            if(createArticleDTO.ImageUrl != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await createArticleDTO.ImageUrl.CopyToAsync(memoryStream);
                    var content = memoryStream.ToArray();
                    var extension = Path.GetExtension(createArticleDTO.ImageUrl.FileName);
                    article.ImageUrl = await _fileStorageService.SaveFile(content, extension, containerName , createArticleDTO.ImageUrl.ContentType); 
                }
            }

            _context.Add(article); 

            await _context.SaveChangesAsync();

            var articleDTO = _mapper.Map<ArticleDTO>(article);

            return CreatedAtAction("GetArticle", new { id = articleDTO.Id }, article);
        }

        /// <summary>
        /// Delete an Article
        /// </summary>
        /// <returns>An emoty object</returns>
        /// <param name="Id"></param>
        /// <response code="204"> Article has been deleted </response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int Id)
        {
            var exists = _context.Articles.AnyAsync(x => x.Id == Id); 

            if(!await exists)
            {
                return NotFound(); 
            }

            _context.Remove(new Article() { Id = Id });
            
            await _context.SaveChangesAsync(); 

            return NoContent();
        }

        private  bool CheckIsFavorite(int ArticleId , string UserId)
        {
            var favs = _context.Favorites.ToList();

            bool isFavorite = false;

            foreach (FavoritesArticles fav in favs)
            {
                if (ArticleId == fav.ArticleId && UserId.Equals(fav.OwnerId))
                {
                    isFavorite = true;
                }
            }

            return isFavorite;
        }

    }
}
