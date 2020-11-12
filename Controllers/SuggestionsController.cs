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

namespace newsroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuggestionsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SuggestionsController(DatabaseContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
        }

        // GET: api/Suggestions
        [HttpGet(Name = nameof(GetSuggestions))]
        public async Task<ActionResult<IEnumerable<SuggestionDTo>>> GetSuggestions()
        {
            IQueryable<Suggestion> suggestions = _context.Suggestions;

            return await suggestions.Include(a => a.article)
                                       .ThenInclude(a => a.Author)
                                    .Include(a => a.article)
                                       .ThenInclude(a => a.Comments).Select(a => SuggestionToDTo(a)).ToListAsync();
        }

        // GET: api/Suggestions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SuggestionDTo>> GetSuggestion(int id)
        {
            IQueryable<Suggestion> suggestions = _context.Suggestions;

            var suggestion = await suggestions.Include(a => a.article)
                                       .ThenInclude(a => a.Author)
                                    .Include(a => a.article)
                                       .ThenInclude(a => a.Comments).FirstOrDefaultAsync(x => x.Id == id);

            if (suggestion == null)
            {
                return NotFound();
            }

            return SuggestionToDTo(suggestion);
        }



        // POST: api/Suggestions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SuggestionDTo>> PostSuggestion(SuggestionDTo suggestionDTo)
        {
            var suggestion = new Suggestion
            {
                articleId = suggestionDTo.articleId
            };

            _context.Suggestions.Add(suggestion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSuggestion), new { id = suggestion.Id }, SuggestionToDTo(suggestion));
        }

        // DELETE: api/Suggestions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuggestion(int id)
        {
            var suggestion = await _context.Suggestions.FindAsync(id);
            if (suggestion == null)
            {
                return NotFound();
            }

            _context.Suggestions.Remove(suggestion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SuggestionExists(int id)
        {
            return _context.Suggestions.Any(e => e.Id == id);
        }

        public static SuggestionDTo SuggestionToDTo(Suggestion suggestion) => new SuggestionDTo
        {
            Id = suggestion.Id,
            articleId = suggestion.articleId,
            article = suggestion.article
        };

    }
}