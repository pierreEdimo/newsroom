using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newsroom.DBContext;
using newsroom.Model;
using AutoMapper;
using newsroom.DTO;
using Microsoft.AspNetCore.Authorization;

namespace newsroom.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper; 

        public AuthorsController(DatabaseContext context, 
                                 IMapper mapper
                                 )
        {
            _context = context;
            _mapper = mapper; 
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<List<AuthorDTO>>> GetAuthors()
        {
            var author =  await _context.Authors.ToListAsync();

            return _mapper.Map<List<AuthorDTO>>(author); 
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDTO>> GetAuthor(int Id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == Id );

            if (author == null)
            {
                return NotFound();
            }

            var authorDTO = _mapper.Map<AuthorDTO>(author); 

            return authorDTO;
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int Id, [FromBody] CreateAuthorDTO updateAuthor)
        {
            var authorDB = await _context.Authors.FirstOrDefaultAsync(x => x.Id == Id);

            if (authorDB == null)
            {
                return NotFound(); 
            }

            authorDB = _mapper.Map(updateAuthor, authorDB);

            await _context.SaveChangesAsync(); 

            return NoContent();
        }

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostAuthor( [FromBody] CreateAuthorDTO createAuthor)
        {
            var author = _mapper.Map<Author>(createAuthor); 

            _context.Add(author);

            await _context.SaveChangesAsync();

            var authorDTO = _mapper.Map<AuthorDTO>(author); 

            return CreatedAtAction("GetAuthor", new { id = authorDTO.Id }, authorDTO);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int Id)
        {
            var exists = _context.Authors.AnyAsync(x => x.Id == Id); 

            if(!await exists)
            {
                return NotFound(); 
            }

            _context.Remove(new Author() { Id = Id });

            await _context.SaveChangesAsync(); 

            return NoContent();
        }

    }
}
