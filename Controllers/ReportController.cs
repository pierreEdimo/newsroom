using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newsroom.DBContext;
using newsroom.DTO;

namespace  newsroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase 
    {
        private readonly DatabaseContext _context; 
        private readonly IMapper _mapper; 

        public ReportController( DatabaseContext context, 
                                 IMapper mapper )
        {
            _context = context; 
            _mapper = mapper; 
        }

        [HttpGet]
        public async Task<ActionResult<List<ReportDTO>>> GetReports()
        {
            var queryable = _context.Reports.AsQueryable(); 

            var reports = await queryable.Include(x => x.Comment)
                                         .ToListAsync(); 

            var reportDTOs = _mapper.Map<List<ReportDTO>>(reports); 

            return reportDTOs; 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReportDTO>> GetReport(int Id)
        {
            var report = await _context.Reports.Include(x => x.Comment)
                                               .FirstOrDefaultAsync(x => x.Id == Id); 

            
            if(report == null) return NotFound(); 

            var reportDTO = _mapper.Map<ReportDTO>(report); 

            return reportDTO; 
        }

        [HttpPost]
        public async Task<ActionResult> PostReport(CreateReportDTO createReportDTO)
        {
            var report = _mapper.Map<ReportDTO>(createReportDTO); 

            _context.Add(report); 

            await _context.SaveChangesAsync(); 

            var reportDTO = _mapper.Map<ReportDTO>(report); 

            return CreatedAtAction("GetReport", new {id = reportDTO.Id }, reportDTO ); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReport(int Id)
        {
            var report = await _context.Reports.FirstOrDefaultAsync(x => x.Id == Id); 

            if(report == null) return NotFound(); 

            _context.Reports.Remove(report);

            await _context.SaveChangesAsync(); 

            return NoContent(); 
        }
    }
}