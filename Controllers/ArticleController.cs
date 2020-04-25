using Microsoft.AspNetCore.Mvc;
using findaDoctor.DBContext;
using findaDoctor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using findaDoctor.DTO;
using findaDoctor.QueryClasses;

namespace findaDoctor.Controllers
{
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

        [HttpGet(Name = nameof(GetArticles))]
        public async Task<ActionResult<IEnumerable<ArticleDTo>>> GetArticles()
        {
            return await _context.Articles.Include(a => a.Author).Select(x => ArticleToDTo(x)).ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleDTo>> GetArticle(int id)
        {
            var article = await _context.Articles.FindAsync();

            if (article == null)
            {
                return NotFound();
            }

            return ArticleToDTo(article);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArticle(int id, ArticleDTo articleDTo)
        {
            if (id != articleDTo.id)
            {
                return BadRequest();
            }

            var articleItem = await _context.Articles.FindAsync(id);
            if (articleItem == null)
            {
                return NotFound();
            }

            articleItem.title = articleDTo.title;
            articleItem.imageUrl = articleDTo.imageUrl;
            articleItem.content = articleDTo.content;
            articleItem.createdAt = articleDTo.createdAt;
            articleItem.authorId = articleDTo.authorId;
            articleItem.themeId = articleDTo.themeId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ArticleExists(id))
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
                authorId = articleDTo.authorId,
                themeId = articleDTo.themeId


            };


            _context.Articles.Add(articleItem);
            await _context.SaveChangesAsync();


            return CreatedAtAction(nameof(GetArticle), new { id = articleItem.id }, ArticleToDTo(articleItem));
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


        private bool ArticleExists(int id) => _context.Articles.Any(e => e.id == id);

        public static ArticleDTo ArticleToDTo(Article article) => new ArticleDTo
        {
            id = article.id,
            title = article.title,
            imageUrl = article.imageUrl,
            content = article.content,
            createdAt = article.createdAt,
            authorId = article.authorId,
            themeId = article.themeId,
            Author = article.Author
        };


    }
}