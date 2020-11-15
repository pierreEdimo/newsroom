using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using newsroom.DBContext;
using newsroom.DTO;
using newsroom.Model;
using newsroom.QueryClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace newsroom.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ThemeController : ControllerBase
    {
        private DatabaseContext _context;

        public ThemeController(DatabaseContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
        }

        [AllowAnonymous]
        [HttpGet(Name = nameof(GetThemes))]
        public async Task<ActionResult<IEnumerable<ThemeDTo>>> GetThemes([FromQuery] NewRoomQueryParameters queryParameter)
        {
            IQueryable<Theme> themes = _context.Themes;

            if (!string.IsNullOrEmpty(queryParameter.sortBy))
            {
                if (typeof(Theme).GetProperty(queryParameter.sortBy) != null)
                {
                    themes = themes.OrderByCustom(queryParameter.sortBy, queryParameter.SortOrder);
                }
            }

            return await themes.Include(a => a.Articles)
                                  .ThenInclude(a => (a as Article).Author)
                               .Include(a => a.Articles)
                                  .ThenInclude(a => a.Comments)
            .Select(x => GetThemeToDTo(x)).ToListAsync();
        }


        [HttpGet("{Id}")]
        public async Task<ActionResult<ThemeDTo>> GetTheme(int Id)
        {
            IQueryable<Theme> themes = _context.Themes;

            var theme = await themes.Include(a => a.Articles)
                                        .ThenInclude(a => (a as Article).Author)
                                    .Include(a => a.Articles).ThenInclude(a => a.Comments)
                .FirstOrDefaultAsync(x => x.Id == Id);

            if (theme == null)
            {
                return NotFound();
            }

            return GetThemeToDTo(theme);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateTheme(int Id, ThemeDTo themeDTo)
        {
            if (Id != themeDTo.Id)
            {
                return BadRequest();
            }

            var theme = await _context.Themes.FindAsync(Id);
            if (theme == null)
            {
                return NotFound();
            }

            theme.name = themeDTo.name;
            theme.imageUrl = themeDTo.imageUrl;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException) when (!ThemeExists(Id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ThemeDTo>> CreateTheme(ThemeDTo themeDTo)
        {
            var theme = new Theme
            {
                name = themeDTo.name,
                imageUrl = themeDTo.imageUrl
            };

            _context.Themes.Add(theme);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTheme), new { id = theme.Id }, ThemeToDTo(theme));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteTheme(int Id)
        {
            var theme = await _context.Themes.FindAsync(Id);

            if (theme == null)
            {
                return NotFound();
            }

            _context.Themes.Remove(theme);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThemeExists(int Id) => _context.Themes.Any(e => e.Id == Id);

        public static ThemeDTo ThemeToDTo(Theme theme) => new ThemeDTo
        {
            Id = theme.Id,
            name = theme.name,
            imageUrl = theme.imageUrl,
            Articles = theme.Articles
        };

        public static ThemeDTo GetThemeToDTo(Theme theme) => new ThemeDTo
        {
            Id = theme.Id,
            name = theme.name,
            imageUrl = theme.imageUrl,
            Articles = theme.Articles,
            numberOfArticles = theme.Articles.Count()
        };


    }
}