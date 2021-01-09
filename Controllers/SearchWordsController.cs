using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newsroom.DBContext;
using newsroom.DTO;
using newsroom.Model;
using newsroom.QueryClasses;

namespace newsroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchWordsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SearchWordsController(DatabaseContext context)
        {
            _context = context;

            _context.Database.EnsureCreated() ; 
        }

        // GET: api/SearchWords
        [HttpGet(Name = nameof(GetSearchWords))]
        public async Task<ActionResult<IEnumerable<SearchWordDTo>>> GetSearchWords([FromQuery] NewRoomQueryParameters queryParameters)
        {
            IQueryable<SearchWord> searchWords = _context.SearchWords;

            if (!string.IsNullOrEmpty(queryParameters.sortBy))
            {
                if (typeof(SearchWord).GetProperty(queryParameters.sortBy) != null)
                {
                    searchWords = searchWords.OrderByCustom(queryParameters.sortBy, queryParameters.SortOrder);
                }
            }

            return await searchWords.Select(x => searchWordToDTo(x) ).ToListAsync() ;
        }

        // GET: api/SearchWords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SearchWord>> GetSearchWord(int id)
        {
            var searchWord = await _context.SearchWords.FindAsync(id);

            if (searchWord == null)
            {
                return NotFound();
            }

            return searchWord;
        }

      

        // POST: api/SearchWords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SearchWordDTo>> PostSearchWord(SearchWordDTo searchWordDTo)
        {
            var searchWord = new SearchWord
            {
                keyWord = searchWordDTo.keyWord
            }; 


            _context.SearchWords.Add(searchWord);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSearchWord) , new { id = searchWord.Id }, searchWord);
        }

        // DELETE: api/SearchWords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSearchWord(int id)
        {
            var searchWord = await _context.SearchWords.FindAsync(id);
            if (searchWord == null)
            {
                return NotFound();
            }

            _context.SearchWords.Remove(searchWord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

      
        public static SearchWordDTo searchWordToDTo(SearchWord searchWord) => new SearchWordDTo
        {
            Id = searchWord.Id,
            keyWord = searchWord.keyWord
        }; 
    }
}
