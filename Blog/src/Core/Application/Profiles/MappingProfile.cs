using AutoMapper;
using Blog.src.Core.Application.DTOs.CommentDtos;
using Blog.src.Core.Application.DTOs.PostDtos;
using Blog.src.Core.Domain.Entity;

namespace Blog.src.Core.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            #region  comment
            CreateMap<Comment, CreateCommentDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentDto>().ReverseMap();
            #endregion

            #region post
            CreateMap<Post, CreatePostDto>().ReverseMap();
            CreateMap<Post, UpdatePostDto>().ReverseMap();
            #endregion
            
           
        }
    }
} 