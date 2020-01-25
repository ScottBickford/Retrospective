using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Retrospective.API.Data;
using Retrospective.API.Dtos;
using Retrospective.API.Engines;
using Retrospective.API.Exceptions;
using Retrospective.API.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retrospective.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [LoggingFilter]
  public abstract class BaseController<T> : ControllerBase, IBaseController where T : IBaseEngine
  {
    IRetrospectiveRepository Repository { get; set; }
    public T Engine { get; set; }
    public IBaseEngine IBaseEngine { get { return Engine; } }

    public BaseController(IRetrospectiveRepository repository, T engine, IMapper mapper)
    {
      Repository = repository;
      Engine = engine;
      Engine.Initialise(this, repository, mapper);
    }

    protected async Task<BaseResponse_Dto> Process<In, Out>(Func<In, Task<Out>> processAction, In requestModel) where Out : BaseResponse_Dto, new()
    {
      if (ModelState.IsValid)
      {
        return await processAction(requestModel);
      }
      else
      {
        throw new BadRequestException(GetModelStateErrors());
      }
    }

    protected async Task<BaseResponse_Dto> Process<Out>(Func<Task<Out>> processAction) where Out : BaseResponse_Dto, new()
    {
      if (ModelState.IsValid)
      {
        return await processAction();
      }
      else
      {
        throw new BadRequestException(GetModelStateErrors());
      }
    }

    protected async Task ProcessAction<In>(Func<In, Task> processAction, In requestModel)
    {
      if (ModelState.IsValid)
      {
        await processAction(requestModel);
      }
      else
      {
        throw new BadRequestException(GetModelStateErrors());
      }
    }

    protected async Task ProcessAction(Func<Task> processAction)
    {
      if (ModelState.IsValid)
      {
        await processAction();
      }
      else
      {
        throw new BadRequestException(GetModelStateErrors());
      }
    }

    private string GetModelStateErrors()
    {
      List<string> errors = new List<string>();
      foreach (var value in ModelState.Values)
      {
        foreach (var error in value.Errors)
        {
          errors.Add(error.ErrorMessage);
        }
      }
      return string.Join(", ", errors);
    }
  }
}
