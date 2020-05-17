using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using findaDoctor.DBContext;
using findaDoctor.Model;
using findaDoctor.DTO;
using Microsoft.AspNetCore.Authorization;

namespace findaDoctor.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteDoctorsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public FavoriteDoctorsController(DatabaseContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteDoctorDTo>>> GetFavoriteDoctors()
        {
            return await _context.FavoriteDoctors.Select(x => favoriteDoctorToDTo(x)).ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<FavoriteDoctorDTo>> GetFavoriteDoctor(int id)
        {
            var favoriteDoctor = await _context.FavoriteDoctors.FindAsync(id);

            if (favoriteDoctor == null)
            {
                return NotFound();
            }

            return favoriteDoctorToDTo(favoriteDoctor);
        }

     

        [HttpPost]
        public async Task<ActionResult<FavoriteDoctorDTo>> PostFavoriteDoctor(FavoriteDoctorDTo favoriteDoctorDTo)
        {
            var favoriteDoctor = new FavoriteDoctor
            {
                userId = favoriteDoctorDTo.userId, 
                doctorId = favoriteDoctorDTo.doctorId
            }; 

            _context.FavoriteDoctors.Add(favoriteDoctor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FavoriteDoctorExists(favoriteDoctor.doctorId))
                {
                    return await DeleteFavoriteDoctor(favoriteDoctor.Id);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetFavoriteDoctor), new { id = favoriteDoctor.Id }, favoriteDoctorToDTo(favoriteDoctor));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFavoriteDoctor(int id)
        {
            var favoriteDoctor = await _context.FavoriteDoctors.FindAsync(id);
            if (favoriteDoctor == null)
            {
                return NotFound();
            }

            _context.FavoriteDoctors.Remove(favoriteDoctor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavoriteDoctorExists(int id)
        {
            return _context.FavoriteDoctors.Any(e => e.doctorId == id);
        }

        public static FavoriteDoctorDTo favoriteDoctorToDTo(FavoriteDoctor favorite) => new FavoriteDoctorDTo
        {
            Id = favorite.Id, 
            userId = favorite.userId, 
            doctorId = favorite.doctorId, 
            Doctor = favorite.Doctor, 
            UserPatient= favorite.UserPatient

        }; 
    }
}
