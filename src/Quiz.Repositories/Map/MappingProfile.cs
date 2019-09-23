using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MongoDB.Bson;
using Quiz.Entities.Entitites;
using Quiz.Repositories.Model;

namespace Quiz.Repositories.Map
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<List<ObjectId>, List<string>>().ConvertUsing(o => o.Select(os => os.ToString()).ToList());
            CreateMap<List<string>, List<ObjectId>>().ConvertUsing(o => o.Select(os => ObjectId.Parse(os)).ToList());
            CreateMap<ObjectId, string>().ConvertUsing(o => o.ToString());
            CreateMap<string, ObjectId>().ConvertUsing(s => ObjectId.Parse(s));

            CreateMap<Questao, QuestaoModel>().ReverseMap();
            CreateMap<Prova, ProvaModel>().ReverseMap();

            CreateMap<Prova, ProvaModel>().ForMember(dest => dest.Id, source => source.Ignore());
            CreateMap<ProvaModel, ProvaModel>().ForMember(dest => dest.Id, source => source.Ignore());
        }
    }
}
