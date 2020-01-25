using AutoMapper;
using Retrospective.API.Dtos;

namespace Retrospective.API.Helpers
{
  public class AutoMapperProfiles : Profile
  {
    public AutoMapperProfiles()
    {
      CreateMap<Models.Retrospective, RetrospectiveForReturnDto>();
      CreateMap<RetrospectiveForCreateDto, Models.Retrospective>()
        .ForMember(m => m.Feedback, opt => opt.Ignore());
    }
  }
}
