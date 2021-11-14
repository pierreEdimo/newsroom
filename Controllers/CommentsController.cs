using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newsroom.DBContext;
using newsroom.Model;
using newsroom.DTO;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;

namespace newsroom.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CommentsController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper; 

        public CommentsController(DatabaseContext context, 
                                  IMapper mapper  )
        {
            _context = context;
            _mapper = mapper; 
        }

        /// <summary>
        /// all the Comments
        /// </summary>
        /// <returns>A List of Comments</returns>
        /// <response code="200"> ok </response>
        [HttpGet]
        public async Task<ActionResult<List<CommentDTO>>> GetComments()
        {
            var comments = await _context.Comments.Include(x => x.Author).ToListAsync();

            return _mapper.Map<List<CommentDTO>>(comments); 
        }

        /// <summary>
        /// a single Comment
        /// </summary>
        /// <returns>A single comment based on the given Id </returns>
        /// <param name="Id"></param>
        /// <response code="200"> ok </response>
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDTO>> GetComment(int Id)
        {
            var comment = await _context.Comments.Include(x => x.Author).FirstOrDefaultAsync(x => x.Id == Id);

            if (comment == null)
            {
                return NotFound();
            }

            var commentDTO = _mapper.Map<CommentDTO>(comment); 

            return commentDTO;
        }

        /// <summary>
        /// a filtered list of comments
        /// </summary>
        /// <returns>A filtered list of comments based on the given parameters </returns>
        /// <param name="filterDTO"></param>
        /// <response code="200"> ok </response>
        [HttpGet("[action]")]
        public async Task<ActionResult<List<CommentDTO>>> FilterComments([FromQuery] FilterCommentDTO filterDTO)
        {
            var commentQueryable = _context.Comments.AsQueryable(); 

            if( filterDTO.ArticleId != 0)
            {
                commentQueryable = commentQueryable.Where(x => x.Article.Id == filterDTO.ArticleId); 
            }

            if (!String.IsNullOrWhiteSpace(filterDTO.sortBy))
            {
                if(typeof(Comment).GetProperty(filterDTO.sortBy) != null)
                {
                    commentQueryable = commentQueryable.OrderByCustom(filterDTO.sortBy, filterDTO.SortOrder); 
                }
            }

            commentQueryable = commentQueryable.Take(filterDTO.Size); 

            var comments = await commentQueryable.Include(x => x.Author).ToListAsync();

            return _mapper.Map<List<CommentDTO>>(comments); 
        }


        /// <summary>
        /// update Comment
        /// </summary>
        /// <returns>An updated comment based on the given parameters </returns>
        /// <param name="updateCommentDTO"></param>
        /// <param name="Id"></param>
        /// <response code="204"> no content </response>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int Id, CreateCommentDTO updateCommentDTO)
        {
            var commentDB = await _context.Comments.FirstOrDefaultAsync(x => x.Id == Id); 

            if(commentDB == null)
            {
                return NotFound(); 
            }

            commentDB = _mapper.Map(updateCommentDTO, commentDB);

            await _context.SaveChangesAsync(); 

            return NoContent();
        }

        /// <summary>
        /// a new Comment
        /// </summary>
        /// <returns>A newly created comment </returns>
        /// <param name="createComment"></param>
        /// <response code="201"> created </response>
        [HttpPost]
        public async Task<ActionResult> PostComment([FromBody] CreateCommentDTO createComment)
        {
            var comment = _mapper.Map<Comment>(createComment);

            _context.Add(comment); 
            
            await _context.SaveChangesAsync();

            var commentDTO = _mapper.Map<CommentDTO>(comment); 

            return CreatedAtAction("GetComment", new { id = commentDTO.Id }, commentDTO);
        }

        /// <summary>
        /// delete comment
        /// </summary>
        /// <returns>An empty object </returns>
        /// <param name="Id"></param>
        /// <response code="204"> Comment has been deleted </response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int Id)
        {
            var exist = _context.Comments.AnyAsync(x => x.Id == Id); 

            if(!await exist)
            {
                return NotFound(); 
            }

            _context.Remove(new Comment() { Id = Id }); 
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}
