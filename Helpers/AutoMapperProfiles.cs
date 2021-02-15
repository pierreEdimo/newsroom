using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            CreateMap<Article, ArticleDetailsDTO>().ReverseMap();

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

        }

    

     

    }

}
