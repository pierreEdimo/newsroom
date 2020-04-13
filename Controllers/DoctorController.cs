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
        public async Task<ActionResult<IEnumerable<DoctorsDTo>>> GetDoctors()
        {
            return await _context.Doctors.Select(x => DoctorToDTO(x)).ToListAsync();
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
            doctor.description = doctorDTO.description;
            doctor.location = doctorDTO.location;
            doctor.city = doctorDTO.city;
            doctor.country = doctorDTO.country;
            doctor.email = doctorDTO.email;
            doctor.number = doctorDTO.number;
            doctor.opening = doctorDTO.opening;
            doctor.closing = doctorDTO.closing;
            doctor.categoryId = doctorDTO.categoryId;

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
                description = doctorsDTo.description,
                location = doctorsDTo.location,
                city = doctorsDTo.city,
                country = doctorsDTo.country,
                email = doctorsDTo.email,
                number = doctorsDTo.number,
                opening = doctorsDTo.opening,
                closing = doctorsDTo.closing,
                categoryId = doctorsDTo.categoryId,
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
            description = doctor.description,
            location = doctor.location,
            city = doctor.city,
            country = doctor.country,
            email = doctor.email,
            number = doctor.number,
            opening = doctor.opening,
            closing = doctor.closing,
            categoryId = doctor.categoryId
        };


    }
}