using Microsoft.AspNetCore.Mvc;
using findaDoctor.DBContext;
using findaDoctor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using findaDoctor.DTO;
using findaDoctor.QueryClasses;

namespace findaDoctor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private DatabaseContext _context;

        public DoctorController(DatabaseContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
        }

        [HttpGet(Name = nameof(GetDoctors))]
        public async Task<ActionResult<IEnumerable<DoctorsDTo>>> GetDoctors([FromQuery] DoctorQueryParameter queryParameters)
        {
            IQueryable<Doctor> doctors = _context.Doctors;


            if (!string.IsNullOrEmpty(queryParameters.specialisation))
            {
                doctors = doctors.Where(p => p.specialisation == queryParameters.specialisation);
            }

            if (!string.IsNullOrEmpty(queryParameters.city))
            {
                doctors = doctors.Where(p => p.city == queryParameters.city);
            }

            if (!string.IsNullOrEmpty(queryParameters.country))
            {
                doctors = doctors.Where(p => p.country == queryParameters.country);
            }

            if (!string.IsNullOrEmpty(queryParameters.name))
            {
                doctors = doctors.Where(p => p.name.ToLower().Contains(queryParameters.name.ToLower()));
            }

            if (!string.IsNullOrEmpty(queryParameters.sortBy))
            {
                if (typeof(Doctor).GetProperty(queryParameters.sortBy) != null)
                {
                    doctors = doctors.OrderByCustom(queryParameters.sortBy, queryParameters.SortOrder);
                }
            }


            doctors = doctors.Skip(queryParameters.Size * (queryParameters.Page - 1)).Take(queryParameters.Size);

            return await doctors.Select(x => DoctorToDTO(x)).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorsDTo>> GetDoctor(int Id)
        {
            var doctor = await _context.Doctors.FindAsync(Id);

            if (doctor == null)
            {
                return NotFound();
            }

            return DoctorToDTO(doctor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, DoctorsDTo doctorDTO)
        {
            if (id != doctorDTO.Id)
            {
                return BadRequest();
            }

            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            doctor.name = doctorDTO.name;
            doctor.specialisation = doctorDTO.specialisation;
            doctor.location = doctorDTO.location;
            doctor.description = doctorDTO.description;
            doctor.city = doctorDTO.city;
            doctor.country = doctorDTO.country;
            doctor.email = doctorDTO.email;
            doctor.number = doctorDTO.number;
            doctor.opening = doctorDTO.opening;
            doctor.closing = doctorDTO.closing;
            doctor.poBox = doctorDTO.poBox;
            doctor.searchWord = doctorDTO.searchWord;
            doctor.imageUrl = doctorDTO.imageUrl;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!DoctorExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<DoctorsDTo>> CreateDoctor(DoctorsDTo doctorsDTo)
        {
            var doctor = new Doctor
            {
                name = doctorsDTo.name,
                specialisation = doctorsDTo.specialisation,
                description = doctorsDTo.description,
                location = doctorsDTo.location,
                city = doctorsDTo.city,
                country = doctorsDTo.country,
                email = doctorsDTo.email,
                number = doctorsDTo.number,
                opening = doctorsDTo.opening,
                closing = doctorsDTo.closing,
                poBox = doctorsDTo.poBox,
                searchWord = doctorsDTo.searchWord,
                imageUrl = doctorsDTo.imageUrl
            };

            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDoctor), new { Id = doctor.Id }, DoctorToDTO(doctor));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool DoctorExists(int id) => _context.Doctors.Any(e => e.Id == id);


        private static DoctorsDTo DoctorToDTO(Doctor doctor) => new DoctorsDTo
        {
            Id = doctor.Id,
            name = doctor.name,
            specialisation = doctor.specialisation,
            description = doctor.description,
            location = doctor.location,
            city = doctor.city,
            country = doctor.country,
            email = doctor.email,
            number = doctor.number,
            opening = doctor.opening,
            closing = doctor.closing,
            poBox = doctor.poBox,
            searchWord = doctor.searchWord,
            imageUrl = doctor.imageUrl
        };


    }
}