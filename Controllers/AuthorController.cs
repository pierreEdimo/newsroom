using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using findaDoctor.DBContext;
using findaDoctor.DTO;
using findaDoctor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace findaDoctor.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private DatabaseContext _context;

        public AuthorController(DatabaseContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
        }

        [HttpGet(Name = nameof(GetAuthors))]
        public async Task<ActionResult<IEnumerable<AuthorDTo>>> GetAuthors()
        {
            return await _context.Authors.Include(a => a.Articles).Select(x => AuthorToDTO(x)).ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<AuthorDTo>> GetAuthor(int Id)
        {
            var author = await _context.Authors.FindAsync(Id);

            if (author == null)
            {
                return NotFound();
            }

            return AuthorToDTO(author);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int Id, AuthorDTo authorDTo)
        {
            if (Id != authorDTo.Id)
            {
                return BadRequest();
            }

            var author = await _context.Authors.FindAsync(Id);
            if (author == null)
            {
                return NotFound();
            }

            author.name = authorDTo.name;
            author.biography = authorDTo.biography;
            author.imageUrl = authorDTo.imageUrl;
            author.createdAt = authorDTo.createdAt;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!AuthorExist(Id))
            {
                return NotFound();
            }

            return NoContent();

        }

        [HttpPost]
        public async Task<ActionResult<AuthorDTo>> CreateAuthor(AuthorDTo authorDTo)
        {
            var author = new Author
            {
                name = authorDTo.name,
                biography = authorDTo.biography,
                imageUrl = authorDTo.imageUrl,
                createdAt = authorDTo.createdAt
            };

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAuthor), new { Id = author.Id }, AuthorToDTO(author));
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAuthor(int Id)
        {
            var author = await _context.Authors.FindAsync(Id);

            if (author == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();

        }


        private bool AuthorExist(int Id) => _context.Authors.Any(e => e.Id == Id);

        public static AuthorDTo AuthorToDTO(Author author) => new AuthorDTo
        {
            Id = author.Id,
            name = author.name,
            biography = author.biography,
            imageUrl = author.imageUrl,
            createdAt = author.createdAt,
            Articles = author.Articles
        };

    }
}