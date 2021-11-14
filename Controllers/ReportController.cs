using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newsroom.DBContext;
using newsroom.DTO;


namespace  newsroom.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
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

        /// <summary>
        /// a list of all the reported comments
        /// </summary>
        /// <returns> a list of all the reported comments from the frontend </returns>
        /// <response code="200"> ok </response>
        [HttpGet]
        public async Task<ActionResult<List<ReportDTO>>> GetReports()
        {
            var queryable = _context.Reports.AsQueryable(); 

            var reports = await queryable.Include(x => x.Comment)
                                         .ToListAsync(); 

            var reportDTOs = _mapper.Map<List<ReportDTO>>(reports); 

            return reportDTOs; 
        }

        /// <summary>
        /// a single Report
        /// </summary>
        /// <param name="Id"></param>
        /// <returns> A single Report based on the given Id </returns>
        /// <response code="200"> ok </response>
        [HttpGet("{id}")]
        public async Task<ActionResult<ReportDTO>> GetReport(int Id)
        {
            var report = await _context.Reports.Include(x => x.Comment)
                                               .FirstOrDefaultAsync(x => x.Id == Id); 

            
            if(report == null) return NotFound(); 

            var reportDTO = _mapper.Map<ReportDTO>(report); 

            return reportDTO; 
        }

        /// <summary>
        /// create a new Report
        /// </summary>
        /// <param name="createReportDTO"></param>
        /// <returns> a newly created report in the database </returns>
        /// <response code="201"> created </response>
        [HttpPost]
        public async Task<ActionResult> PostReport(CreateReportDTO createReportDTO)
        {
            var report = _mapper.Map<ReportDTO>(createReportDTO); 

            _context.Add(report); 

            await _context.SaveChangesAsync(); 

            var reportDTO = _mapper.Map<ReportDTO>(report); 

            return CreatedAtAction("GetReport", new {id = reportDTO.Id }, reportDTO ); 
        }

        /// <summary>
        /// delete a single Report
        /// </summary>
        /// <param name="Id"></param>
        /// <returns> an empty object </returns>
        /// <response code="204"> no content </response>
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