using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Retrospective.API.Data;
using Retrospective.API.Dtos;
using Retrospective.API.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retrospective.API.Controllers
{
  public class RetrospectiveController : BaseController<IRetrospectiveEngine>
  {
    public RetrospectiveController(IRetrospectiveRepository repository, IRetrospectiveEngine engine, IMapper mapper) : base(repository, engine, mapper) { }

    [HttpGet("{id}", Name = "Get")]
    public async Task<IActionResult> Get([FromRoute]RetrospectiveForGetDto requestDto)
    {
      var responseDto = await Process(Engine.Get, requestDto);
      return Ok(responseDto);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery]RetrospectiveForGetAllDto requestDto)
    {
      var responseDto = await Process(Engine.GetAll, requestDto);
      return Ok(responseDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRetrospective(RetrospectiveForCreateDto submitDto)
    {
      var response = await Process(Engine.CreateRetrospective, submitDto) as RetrospectiveForCreateResponseDto;
      var messageToReturn = await Process(Engine.Get, new RetrospectiveForGetDto { Id = response.RetrospectiveId });
      return CreatedAtRoute("Get", new { id = response.RetrospectiveId }, messageToReturn);
    }

    [HttpPost("{retrospectiveId}")]
    public async Task<IActionResult> AddFeedback(int retrospectiveId, FeedbackForCreateDto submitDto)
    {
      submitDto.RetrospectiveId = retrospectiveId;
      await ProcessAction(Engine.AddFeedback, submitDto);
      var messageToReturn = await Process(Engine.Get, new RetrospectiveForGetDto { Id = retrospectiveId });
      return CreatedAtRoute("Get", new { id = submitDto.RetrospectiveId }, messageToReturn);
    }
  }
}