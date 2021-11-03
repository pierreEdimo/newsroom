using AutoMapper;
using newsroom.Model;
using newsroom.DTO; 

namespace newsroom.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Article, ArticleDTO>().ReverseMap();

            CreateMap<CreateArticleDTO, Article>()
                .ForMember(x => x.ImageUrl, options => options.Ignore());

            CreateMap<KeyWord, KeyWordDTO>().ReverseMap();

            CreateMap<AddWordDTO, KeyWord>().ReverseMap();

            CreateMap<FavoritesArticles, FavoriteDTO>().ReverseMap();

            CreateMap<AddFavoriteDTO, FavoritesArticles>().ReverseMap(); 

            CreateMap<Topic, TopicDTO>().ReverseMap();

            CreateMap<CreateTopicDTO, Topic>()
                .ForMember(x => x.ImageUrl, options => options.Ignore());

            CreateMap<Author, AuthorDTO>().ReverseMap();

            CreateMap<CreateAuthorDTO, Author>().ReverseMap();

            CreateMap<Comment, CommentDTO>().ReverseMap();

            CreateMap<CreateCommentDTO, Comment>().ReverseMap();

            CreateMap<Report, ReportDTO>().ReverseMap(); 

            CreateMap<CreateReportDTO, Report>().ReverseMap(); 

            CreateMap<UserEntity, UserDTO>()
                .ForMember(x => x.Email, options => options.MapFrom(x => x.Email))
                .ForMember(x => x.Id, options => options.MapFrom(x => x.Id))
                .ForMember(x => x.UserName, options => options.MapFrom(x => x.UserName)); 

        }

    

     

    }

}
