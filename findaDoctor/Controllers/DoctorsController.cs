using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using findaDoctor.DBcontext;
using findaDoctor.model;
using findaDoctor.DTO;

namespace findaDoctor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public DoctorsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDTO>>> GetDoctors()
        {
           

            return await _context.Doctors.Select(x=> DoctorToDTO(x)).ToListAsync();
        }

        // GET: api/Doctors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDTO>> GetDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return DoctorToDTO(doctor);
        }

        // PUT: api/Doctors/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(int id, DoctorDTO  doctorDTO)
        {
            if (id != doctorDTO.Id)
            {
                return BadRequest();
            }

            var doctor = await _context.Doctors.FindAsync(id); 
            if(doctor == null)
            {
                return NotFound(); 
            }

            doctor.name = doctorDTO.name;
            doctor.category = doctorDTO.category;
            doctor.description = doctorDTO.category;
            doctor.createdAt = doctorDTO.createdAt;
            doctor.city = doctorDTO.city;
            doctor.country = doctorDTO.country;
            doctor.address = doctorDTO.address;
            doctor.poBox = doctorDTO.poBox;
            doctor.email = doctorDTO.email;
            doctor.teleFonNumber = doctorDTO.teleFonNumber;

           
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!DoctorExists(id))
            {
                if (!DoctorExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // POST: api/Doctors
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DoctorDTO>> PostDoctor(DoctorDTO doctorDTO)
        {
            var doctor = new Doctor
            {
                name = doctorDTO.name,
                category = doctorDTO.category,
                description = doctorDTO.description,
                createdAt = doctorDTO.createdAt,
                city = doctorDTO.city,
                country = doctorDTO.country,
                address = doctorDTO.address,
                poBox = doctorDTO.poBox,
                email = doctorDTO.email,
                teleFonNumber = doctorDTO.teleFonNumber
            };

            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDoctor), new { id = doctor.Id }, DoctorToDTO(doctor));
        }

        // DELETE: api/Doctors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Doctor>> DeleteDoctor(int id)
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

        private bool DoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.Id == id);
        }

        private static DoctorDTO DoctorToDTO(Doctor doctor) => new DoctorDTO
        {
            Id = doctor.Id,
            name = doctor.name,
            category = doctor.category,
            description = doctor.description,
            createdAt = doctor.createdAt,
            city = doctor.city,
            country = doctor.country,
            address = doctor.address,
            poBox = doctor.poBox,
            email = doctor.email,
            teleFonNumber = doctor.teleFonNumber
        }; 
    }
}
