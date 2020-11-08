using Microsoft.AspNetCore.Mvc;
using newsroom.DBContext;
using newsroom.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using newsroom.DTO;
using newsroom.QueryClasses;
using Microsoft.AspNetCore.Authorization;

namespace newsroom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private DatabaseContext _context;

        public ArticleController(DatabaseContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
        }


        [AllowAnonymous]
        [HttpGet(Name = nameof(GetArticles))]
        public async Task<ActionResult<IEnumerable<ArticleDTo>>> GetArticles([FromQuery] DoctorQueryParameter queryParameters)
        {
            IQueryable<Article> articles = _context.Articles;

            if (!string.IsNullOrEmpty(queryParameters.sortBy))
            {
                if (typeof(Article).GetProperty(queryParameters.sortBy) != null)
                {
                    articles = articles.OrderByCustom(queryParameters.sortBy, queryParameters.SortOrder);
                }
            }

            if (!string.IsNullOrEmpty(queryParameters.title))
            {
                articles = articles.Where(p => p.title.ToLower().Contains(queryParameters.title.ToLower()));
            }

            articles = articles.Skip(queryParameters.Size * (queryParameters.Page - 1)).Take(queryParameters.Size);

            return await articles.Include(a => a.Comments).Include(a => a.Author).Include(a => a.Theme).Select(x => GetArticleToDTo(x)).ToListAsync();
        }

        [AllowAnonymous]
        [HttpGet("[action]", Name = nameof(GetArticleFromAuthor))]
        public async Task<ActionResult<IEnumerable<ArticleDTo>>> GetArticleFromAuthor([FromQuery] DoctorQueryParameter queryParameters)
        {
            IQueryable<Article> articles = _context.Articles;

            if (!string.IsNullOrEmpty(queryParameters.sortBy))
            {
                if (typeof(Article).GetProperty(queryParameters.sortBy) != null)
                {
                    articles = articles.OrderByCustom(queryParameters.sortBy, queryParameters.SortOrder);
                }
            }

            if (!string.IsNullOrEmpty(queryParameters.authorId.ToString()))
            {
                articles = articles.Where(p => p.authorId.ToString().Contains(queryParameters.authorId.ToString()));
            }

            articles = articles.Skip(queryParameters.Size * (queryParameters.Page - 1)).Take(queryParameters.Size);

            return await articles.Include(a => a.Comments).Include(a => a.Author).Include(a => a.Theme).Select(x => GetArticleToDTo(x)).ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleDTo>> GetArticle(int Id)
        {
            IQueryable<Article> articles = _context.Articles;

            var article = await articles.Include(a => a.Author).Include(a => a.Theme).FirstOrDefaultAsync(x => x.Id == Id);

            if (article == null)
            {
                return NotFound();
            }

            return ArticleToDTo(article);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArticle(int Id, ArticleDTo articleDTo)
        {
            if (Id != articleDTo.Id)
            {
                return BadRequest();
            }

            var articleItem = await _context.Articles.FindAsync(Id);
            if (articleItem == null)
            {
                return NotFound();
            }

            articleItem.title = articleDTo.title;
            articleItem.imageUrl = articleDTo.imageUrl;
            articleItem.content = articleDTo.content;
            articleItem.createdAt = articleDTo.createdAt;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ArticleExists(Id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ArticleDTo>> CreateAnArticle(ArticleDTo articleDTo)
        {



            var articleItem = new Article
            {
                title = articleDTo.title,
                imageUrl = articleDTo.imageUrl,
                content = articleDTo.content,
                createdAt = articleDTo.createdAt,
                themeId = articleDTo.themeId,
                authorId = articleDTo.authorId,


            };


            _context.Articles.Add(articleItem);
            await _context.SaveChangesAsync();


            return CreatedAtAction(nameof(GetArticle), new { id = articleItem.Id }, ArticleToDTo(articleItem));
        }

        [HttpDelete("{id }")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var artcileItem = await _context.Articles.FindAsync(id);
            if (artcileItem == null)
            {
                return NotFound();
            }

            _context.Articles.Remove(artcileItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool ArticleExists(int Id) => _context.Articles.Any(e => e.Id == Id);

        public static ArticleDTo ArticleToDTo(Article article) => new ArticleDTo
        {
            Id = article.Id,
            title = article.title,
            imageUrl = article.imageUrl,
            content = article.content,
            createdAt = article.createdAt,
            themeId = article.themeId,
            Theme = article.Theme,
            authorId = article.authorId,
            Author = article.Author,
            Comments = article.Comments,
            numberOfComments = article.Comments.Count()


        };

        public static ArticleDTo GetArticleToDTo(Article article) => new ArticleDTo
        {
            Id = article.Id,
            title = article.title,
            imageUrl = article.imageUrl,
            content = article.content,
            createdAt = article.createdAt,
            themeId = article.themeId,
            Theme = article.Theme,
            authorId = article.authorId,
            Author = article.Author,
            Comments = article.Comments,
            numberOfComments = article.Comments.Count()

        };


    }
}