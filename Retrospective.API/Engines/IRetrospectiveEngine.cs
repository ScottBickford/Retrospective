using Retrospective.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retrospective.API.Engines
{
  public interface IRetrospectiveEngine : IBaseEngine
  {
    Task<RetrospectiveForReturnDto> Get(RetrospectiveForGetDto requestDto);
    Task<AllRetrospectivesForReturnDto> GetAll(RetrospectiveForGetAllDto requestDto);
    Task<RetrospectiveForCreateResponseDto> CreateRetrospective(RetrospectiveForCreateDto submitDto);
    Task AddFeedback(FeedbackForCreateDto submitDto);
  }
}
