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
    
    [Route("api/[controller]")]
    [ApiController]
    public class KeyWordsController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper; 

        public KeyWordsController(DatabaseContext context,  
                                  IMapper mapper
                                 )
        {
            _context = context;
            _mapper = mapper; 
        }

        // GET: api/KeyWords
        [HttpGet]
        public async Task<ActionResult<List<KeyWordDTO>>> GetKeyWords()
        {
            var words = await _context.KeyWords.ToListAsync();

            return _mapper.Map<List<KeyWordDTO>>(words); 
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<String>>> QueryWord([FromQuery] FilterFromUserDTO filter )
        {
            var queryable = _context.KeyWords.AsQueryable(); 

             if (!String.IsNullOrWhiteSpace(filter.UserId))
            {
                queryable = queryable.Where(x => x.UserId.Contains(filter.UserId)); 
            }

              if (!String.IsNullOrWhiteSpace(filter.sortBy))
            {
                if (typeof(KeyWord).GetProperty(filter.sortBy) != null)
                {
                   queryable = queryable.OrderByCustom(filter.sortBy, filter.SortOrder);
                }
            }

            queryable = queryable.Take(filter.Size);

            var words = await queryable.Select(x => x.Word)
                                       .Distinct()
                                       .ToListAsync();

            return words; 
            
        }
 

        // GET: api/KeyWords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KeyWordDTO>> GetKeyWord(int Id)
        {
            var keyWord = await _context.KeyWords.FirstOrDefaultAsync( x => x.Id == Id );

            if (keyWord == null)
            {
                return NotFound();
            }

            var wordDTO = _mapper.Map<KeyWordDTO>(keyWord); 

            return wordDTO;
        }


        // POST: api/KeyWords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostKeyWord(AddWordDTO addkeyWord)
        {
            var word = _mapper.Map<KeyWord>(addkeyWord);

            _context.Add(word);

            await _context.SaveChangesAsync();

            var wordDTO = _mapper.Map<KeyWordDTO>(word); 

            return CreatedAtAction("GetKeyWord", new { id = wordDTO.Id }, wordDTO);
        }

        // DELETE: api/KeyWords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKeyWord(int Id)
        {
            var exists = _context.KeyWords.AnyAsync(x => x.Id == Id); 

            if(! await exists)
            {
                return NotFound(); 
            }

            _context.Remove(new KeyWord() { Id = Id });
            await _context.SaveChangesAsync(); 

            return NoContent();
        }

      
    }
}
