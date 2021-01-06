namespace newsroom.QueryClasses
{
    public class NewRoomQueryParameters : QueryParameters
    {
        public string title { get; set; }
        public string userId { get; set; }
        public int authorId { get; set;  }
        public int articleId { get; set;  }
    }
}