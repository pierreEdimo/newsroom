using System.Collections.Generic;
using System.Threading.Tasks;
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
    [Produces("application/json")]
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

        /// <summary>
        /// all the Authors
        /// </summary>
        /// <returns>A List of Authors</returns>
        /// <response code="200"> ok </response>
        [HttpGet]
        public async Task<ActionResult<List<AuthorDTO>>> GetAuthors()
        {
            var author =  await _context.Authors.ToListAsync();

            return _mapper.Map<List<AuthorDTO>>(author); 
        }


        /// <summary>
        /// a single Author
        /// </summary>
        /// <returns>a single Author based on the given Id</returns>
        /// <param name="Id"></param>
        /// <response code="200"> ok </response>
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

        /// <summary>
        /// update an Author
        /// </summary>
        /// <returns>an Author with the modified informations</returns>
        /// <param name="updateAuthor"></param>
        /// <param name="Id"></param>
        /// <response code="204"> no content </response>
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

        /// <summary>
        /// create a new Author
        /// </summary>
        /// <returns>return a newly created Author</returns>
        /// <param name="createAuthor"></param>
        /// <response code="201"> Author has been successfully created </response>
        [HttpPost]
        public async Task<ActionResult> PostAuthor( [FromBody] CreateAuthorDTO createAuthor)
        {
            var author = _mapper.Map<Author>(createAuthor); 

            _context.Add(author);

            await _context.SaveChangesAsync();

            var authorDTO = _mapper.Map<AuthorDTO>(author); 

            return CreatedAtAction("GetAuthor", new { id = authorDTO.Id }, authorDTO);
        }

        /// <summary>
        /// delete an Author
        /// </summary>
        /// <returns>An empty object </returns>
        /// <param name="Id"></param>
        /// <response code="204"> Author has been deleted </response>
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
