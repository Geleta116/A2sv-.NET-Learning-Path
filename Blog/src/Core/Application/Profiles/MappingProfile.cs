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
            CreateMap<Comment, CreateCommentDto>().ReverseMap();
            CreateMap<Post, CreatePostDto>().ReverseMap();
            CreateMap<PostDto, CreatePostDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentDto>().ReverseMap();
            CreateMap<Post, UpdatePostDto>().ReverseMap();
        }
    }
} 