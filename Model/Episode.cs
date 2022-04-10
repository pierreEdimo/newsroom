using System;
using System.ComponentModel.DataAnnotations;

namespace newsroom.Model
{

    public class Episode
    {
        [Key]
        public int Id { get; set; }
        public string VideoaUrl { get; set; }
        public string EpisodeTitle { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public virtual PodCast PodCast { get; set; }
        public int PodCastId { get; set; }
    }

}