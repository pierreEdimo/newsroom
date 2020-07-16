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
    public class ForumCommentsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ForumCommentsController(DatabaseContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
        }

        // GET: api/ForumComments
        [HttpGet(Name = nameof(GetforumComments))]
        public async Task<ActionResult<IEnumerable<ForumCommentDTo>>> GetforumComments()
        {
            IQueryable<ForumComments> comments = _context.forumComments;

            return await comments.Include(a => a.Answers).Include(a => a.author).Select(x => commentToDTo(x)).ToListAsync();
        }

        // GET: api/ForumComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ForumCommentDTo>> GetForumComments(int id)
        {
            var forumComments = await _context.forumComments.FindAsync(id);

            if (forumComments == null)
            {
                return NotFound();
            }

            return commentToDTo(forumComments);
        }

        // PUT: api/ForumComments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutForumComments(int Id, ForumCommentDTo forumCommentDTo)
        {
            if (Id != forumCommentDTo.Id)
            {
                return BadRequest();
            }

            var comment = await _context.forumComments.FindAsync(Id);
            if (comment == null)
            {
                return NotFound();
            }

            comment.content = forumCommentDTo.content;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForumCommentsExists(Id))
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

        // POST: api/ForumComments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ForumCommentDTo>> PostForumComments(ForumCommentDTo forumCommentDTo)
        {
            var comment = new ForumComments
            {
                uid = forumCommentDTo.uid,
                content = forumCommentDTo.content,
                forumId = forumCommentDTo.forumId
            };

            _context.forumComments.Add(comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetForumComments), new { id = comment.Id }, commentToDTo(comment));
        }

        // DELETE: api/ForumComments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteForumComments(int id)
        {
            var forumComments = await _context.forumComments.FindAsync(id);
            if (forumComments == null)
            {
                return NotFound();
            }

            _context.forumComments.Remove(forumComments);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ForumCommentsExists(int id)
        {
            return _context.forumComments.Any(e => e.Id == id);
        }

        public static ForumCommentDTo commentToDTo(ForumComments comment) => new ForumCommentDTo
        {
            Id = comment.Id,
            uid = comment.uid,
            content = comment.content,
            forumId = comment.forumId,
            author = comment.author,
            createdAt = comment.createdAt,
            Answers = comment.Answers

        };
    }
}
