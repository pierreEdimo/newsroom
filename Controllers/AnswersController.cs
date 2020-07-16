using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newsroom.DBContext;
using newsroom.DTO;
using newsroom.Model;

namespace newsroom.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AnswersController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Answers
        [HttpGet(Name = nameof(GetAnswers))]
        public async Task<ActionResult<IEnumerable<AnswerDTo>>> GetAnswers()
        {
            IQueryable<Answer> answers = _context.Answers;

            return await _context.Answers.Include(x => x.Author).Select(x => answerToDTo(x)).ToListAsync();
        }

        // GET: api/Answers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnswerDTo>> GetAnswer(int id)
        {
            var answer = await _context.Answers.FindAsync(id);

            if (answer == null)
            {
                return NotFound();
            }

            return answerToDTo(answer);
        }

        // PUT: api/Answers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnswer(int id, AnswerDTo answerDTo)
        {
            if (id != answerDTo.Id)
            {
                return BadRequest();
            }

            var answer = await _context.Answers.FindAsync(id); 
            if(answer == null)
            {
                return NotFound(); 
            }

            answer.content = answerDTo.content; 

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Answers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AnswerDTo>> PostAnswer(AnswerDTo answerDTo)
        {
            var answer = new Answer
            {
                uid = answerDTo.uid, 
                commentId = answerDTo.commentId, 
                content = answerDTo.content
            }; 

            _context.Answers.Add(answer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAnswer), new { id = answer.Id }, answerToDTo(answer));
        }

        // DELETE: api/Answers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAnswer(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer == null)
            {
                return NotFound();
            }

            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnswerExists(int id)
        {
            return _context.Answers.Any(e => e.Id == id);
        }

        private static AnswerDTo answerToDTo(Answer answer) => new AnswerDTo
        {
            Id = answer.Id ,
            commentId = answer.commentId, 
            Comments = answer.Comments ,
            content = answer.content, 
            Author = answer.Author, 
            uid = answer.uid
        }; 
    }
}
