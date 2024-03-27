using ApplicationCore.Models.QuizAggregate;
using AutoMapper;
using WebApi.Dto;

namespace WebApi.Mappers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<QuizItem, QuizItemDto>()
            .ForMember(
                q => q.Options,
                op => op.MapFrom(
                    s => new List<string>(s.IncorrectAnswers) { s.CorrectAnswer }
                )
            );
        CreateMap<Quiz, QuizDto>()
            .ForMember(
                t => t.Items,
                op => op.MapFrom<List<QuizItem>>(
                    i => i.Items
            ));
    }
}