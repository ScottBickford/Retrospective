using Retrospective.API.Dtos;
using Retrospective.API.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retrospective.API.Engines
{
  public class RetrospectiveEngine : BaseEngine, IRetrospectiveEngine
  {
    #region Get
    public async Task<RetrospectiveForReturnDto> Get(RetrospectiveForGetDto requestDto)
    {
      var retrospectiveFromRepo = await Repository.GetRetrospective(requestDto.Id);
      var retrospective = Mapper.Map<RetrospectiveForReturnDto>(retrospectiveFromRepo);
      return retrospective;
    }
    #endregion

    #region GetAll
    public async Task<AllRetrospectivesForReturnDto> GetAll(RetrospectiveForGetAllDto requestDto)
    {
      var retrospectivesFromRepo = await Repository.GetAllRetrospectives(requestDto.Date);
      var retrospectives = Mapper.Map<List<RetrospectiveForReturnDto>>(retrospectivesFromRepo);
      return new AllRetrospectivesForReturnDto
      {
        Retrospectives = retrospectives
      };
    }
    #endregion

    #region CreateRetrospective
    public async Task<RetrospectiveForCreateResponseDto> CreateRetrospective(RetrospectiveForCreateDto submitDto)
    {
      // Check for duplication
      var retrospectiveFromRepo = await Repository.GetRetrospectiveByName(submitDto.Name);
      if (retrospectiveFromRepo != null)
      {
        throw new BadRequestException("Retrospective name already exists");
      }
      // Remove any blank participants
      submitDto.Participants = submitDto.Participants.Where(p => !String.IsNullOrEmpty(p)).ToList();
      // Check that there is at least 1 participant (the Data Annotatin catches this, but we need to recheck after removing empty participants)
      if (submitDto.Participants.Count() == 0)
      {
        throw new BadRequestException("There must be at least 1 participant");
      }
      var retrospective = Mapper.Map<Models.Retrospective>(submitDto);
      await Repository.AddRetrospective(retrospective);
      return new RetrospectiveForCreateResponseDto
      {
        RetrospectiveId = retrospective.RetrospectiveId
      };
    }
    #endregion

    #region AddFeedback
    public async Task AddFeedback(FeedbackForCreateDto submitDto)
    {
      var retrospectiveFromRepo = await Repository.GetRetrospective(submitDto.RetrospectiveId);
      if (retrospectiveFromRepo == null)
      {
        throw new NotFoundException("Could not find Retrospective");
      }

      var feedback = Mapper.Map<Models.Feedback>(submitDto);
      await Repository.AddFeedback(retrospectiveFromRepo.RetrospectiveId, feedback);
    }
    #endregion
  }
}
