using Application.Features.BookMembers.Commands.Create;
using Application.Features.BookMembers.Commands.Delete;
using Application.Features.BookMembers.Commands.Update;
using Application.Features.BookMembers.Queries.GetById;
using Application.Features.BookMembers.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.BookMembers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<BookMember, CreateBookMemberCommand>().ReverseMap();
        CreateMap<BookMember, CreatedBookMemberResponse>().ReverseMap();
        CreateMap<BookMember, UpdateBookMemberCommand>().ReverseMap();
        CreateMap<BookMember, UpdatedBookMemberResponse>().ReverseMap();
        CreateMap<BookMember, DeleteBookMemberCommand>().ReverseMap();
        CreateMap<BookMember, DeletedBookMemberResponse>().ReverseMap();
        CreateMap<BookMember, GetByIdBookMemberResponse>().ReverseMap();
        CreateMap<BookMember, GetListBookMemberListItemDto>().ReverseMap();
        CreateMap<IPaginate<BookMember>, GetListResponse<GetListBookMemberListItemDto>>().ReverseMap();
    }
}