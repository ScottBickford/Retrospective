using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Retrospective.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retrospective.API.Engines
{
  public abstract class BaseEngine : IBaseEngine
  {
    public static object LockObject = new object();
    public ControllerBase Controller { get; set; }
    public IRetrospectiveRepository Repository { get; set; }
    public IMapper Mapper { get; set; }

    public void Initialise(ControllerBase controller, IRetrospectiveRepository repository, IMapper mapper)
    {
      Controller = controller;
      Repository = repository;
      Mapper = mapper;
    }
  }
}