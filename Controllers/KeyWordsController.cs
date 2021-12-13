using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        /// <summary>
        /// all the savedwords from the search
        /// </summary>
        /// <returns> A list of all the savedwords from the search </returns>
        /// <response code="200"> ok </response>
        [HttpGet]
        public async Task<ActionResult<List<KeyWordDTO>>> GetKeyWords()
        {
            var words = await _context.KeyWords.ToListAsync();

            return _mapper.Map<List<KeyWordDTO>>(words); 
        }

        /// <summary>
        /// a filtered list of the savedword from the userId
        /// </summary>
        /// <returns> A list of all the filtered savedwords from the user's search </returns>
        /// <response code="200"> ok </response>
        [HttpGet("[action]")]
        public async Task<ActionResult<List<string>>> QueryWord([FromQuery] FilterFromUserDTO filter )
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
               
        /// <summary>
        /// a single savedword
        /// </summary>
        /// <returns> a single Savedword based on the Id </returns>
        /// <param name="Id"></param>
        /// <response code="200"> ok </response>
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


        /// <summary>
        /// add a new word in the savedword table
        /// </summary>
        /// <param name="addkeyWord"></param>
        /// <returns> a newly created savedword in the database </returns>
        /// <response code="201"> created </response>
        [HttpPost]
        public async Task<ActionResult> PostKeyWord(AddWordDTO addkeyWord)
        {
            var word = _mapper.Map<KeyWord>(addkeyWord);

            _context.Add(word);

            await _context.SaveChangesAsync();

            var wordDTO = _mapper.Map<KeyWordDTO>(word); 

            return CreatedAtAction("GetKeyWord", new { id = wordDTO.Id }, wordDTO);
        }

        /// <summary>
        /// delete a single savedword 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns> an empty object </returns>
        /// <response code="204"> no content </response>
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
