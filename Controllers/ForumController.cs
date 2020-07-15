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
    public class ForumController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ForumController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Forum

        [HttpGet(Name = nameof(GetForums))]
        public async Task<ActionResult<IEnumerable<ForumDTo>>> GetForums()
        {
            IQueryable<Forum> forums = _context.Forums;

            return await forums.Include(a => a.Author).Select(x => forumToDTo(x)).ToListAsync();
        }

        // GET: api/Forum/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ForumDTo>> GetForum(int id)
        {
            var forum = await _context.Forums.FindAsync(id);

            if (forum == null)
            {
                return NotFound();
            }

            return forumToDTo(forum);
        }

        // PUT: api/Forum/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutForum(int id, ForumDTo forumDTo)
        {
            if (id != forumDTo.Id)
            {
                return BadRequest();
            }

            var forum = await _context.Forums.FindAsync(id);

            if (forum == null)
            {
                return NotFound();
            }

            forum.title = forumDTo.title;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForumExists(id))
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

        // POST: api/Forum
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ForumDTo>> PostForum(ForumDTo forumDTo)
        {
            var forum = new Forum
            {
                uid = forumDTo.uid,
                title = forumDTo.title
            };

            _context.Forums.Add(forum);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetForum), new { id = forum.Id }, forumToDTo(forum));
        }

        // DELETE: api/Forum/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteForum(int id)
        {
            var forum = await _context.Forums.FindAsync(id);
            if (forum == null)
            {
                return NotFound();
            }

            _context.Forums.Remove(forum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ForumExists(int id)
        {
            return _context.Forums.Any(e => e.Id == id);
        }

        private static ForumDTo forumToDTo(Forum forum) => new ForumDTo
        {
            Author = forum.Author,
            createdAt = forum.createdAt,
            Id = forum.Id,
            title = forum.title,
            uid = forum.uid
        };
    }
}
