using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Retrospective.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retrospective.API.Engines
{
  public interface IBaseEngine
  {
    ControllerBase Controller { get; set; }
    IRetrospectiveRepository Repository { get; set; }
    IMapper Mapper { get; set; }

    void Initialise(ControllerBase controller, IRetrospectiveRepository repository, IMapper mapper);
  }
}