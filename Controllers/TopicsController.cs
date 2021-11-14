﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newsroom.DBContext;
using newsroom.Model;
using AutoMapper;
using newsroom.Services;
using newsroom.DTO;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace newsroom.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TopicsController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;
        private String containerName = "Topic"; 


        public TopicsController(DatabaseContext context, 
                                IMapper mapper, 
                                IFileStorageService fileStorageService
                                )
        {
            _context = context;
            _mapper = mapper;
            _fileStorageService = fileStorageService; 
        }

        /// <summary>
        /// list of all the topics
        /// </summary>
        /// <returns> a list of all the topics from the database </returns>
        /// <response code="200"> ok </response>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<TopicDTO>>> GetTopics()
        {
            var topic = await _context.Topics.ToListAsync();

            return _mapper.Map<List<TopicDTO>>(topic); 
        }

        /// <summary>
        /// a single topic
        /// </summary>
        /// <param name="Id"></param>
        /// <returns> a single topic based on the given Id </returns>
        /// <response code="200"> ok </response>
        [HttpGet("{id}")]
        public async Task<ActionResult<TopicDTO>> GetTopic(int Id)
        {
            var topic = await _context.Topics.FirstOrDefaultAsync(x => x.Id ==  Id); 

            if (topic == null)
            {
                return NotFound();
            }

            var topicDTO = _mapper.Map<TopicDTO>(topic); 

            return topicDTO;
        }

        /// <summary>
        /// update a topic
        /// </summary>
        /// <param name="updateTopic"></param>
        /// <param name="Id"></param>
        /// <returns> modified topic based on the given Id </returns>
        /// <response code="204"> no content </response>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTopic(int Id, [FromForm] CreateTopicDTO  updateTopic )
        {
            var topicDB = await _context.Topics.FirstOrDefaultAsync(x => x.Id == Id); 
          
            if(topicDB == null)
            {
                return NotFound(); 
            }

            topicDB = _mapper.Map(updateTopic, topicDB); 

            if( updateTopic.ImageUrl != null)
            {
                using( var memoryStream = new MemoryStream())
                {
                    await updateTopic.ImageUrl.CopyToAsync(memoryStream);
                    var content = memoryStream.ToArray();
                    var extension = Path.GetExtension(updateTopic.ImageUrl.FileName);
                    topicDB.ImageUrl = await _fileStorageService.EditFile(content, extension, containerName , topicDB.ImageUrl, updateTopic.ImageUrl.ContentType); 
                }
            }

            await _context.SaveChangesAsync(); 

            return NoContent();
        }

        // POST: api/Topics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostTopic([FromForm] CreateTopicDTO createTopic )
        {
            var topic = _mapper.Map<Topic>(createTopic); 

            if(createTopic != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await createTopic.ImageUrl.CopyToAsync(memoryStream);
                    var content = memoryStream.ToArray();
                    var extension = Path.GetExtension(createTopic.ImageUrl.FileName);
                    topic.ImageUrl = await _fileStorageService.SaveFile(content, extension, containerName, createTopic.ImageUrl.ContentType); 
                }
            }

            _context.Add(topic);

            await _context.SaveChangesAsync();

            var topicDTO = _mapper.Map<TopicDTO>(topic); 

            return CreatedAtAction("GetTopic", new { id = topicDTO.Id }, topicDTO);
        }

        // DELETE: api/Topics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(int Id)
        {
            var exists = _context.Topics.AnyAsync(x => x.Id == Id); 
          
            if (!await exists)
            {
                return NotFound();
            }

            _context.Topics.Remove( new Topic() { Id = Id });

            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
