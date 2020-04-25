using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using findaDoctor.DBContext;
using findaDoctor.DTO;
using findaDoctor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace findaDoctor.Controllers
{

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


        [HttpGet(Name = nameof(GetThemes))]
        public async Task<ActionResult<IEnumerable<ThemeDTo>>> GetThemes()
        {
            return await _context.Themes.Include(a => a.Articles).Select(x => ThemeToDTo(x)).ToListAsync();
        }

        public static ThemeDTo ThemeToDTo(Theme theme) => new ThemeDTo
        {
            Id = theme.Id,
            name = theme.name,
            imageUrl = theme.imageUrl,
            Articles = theme.Articles
        };

    }
}