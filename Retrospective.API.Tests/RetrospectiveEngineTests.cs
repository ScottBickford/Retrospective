using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Retrospective.API.Controllers;
using Retrospective.API.Data;
using Retrospective.API.Dtos;
using Retrospective.API.Engines;
using System;
using System.Collections.Generic;
using Xunit;

namespace Retrospective.API.Tests
{
  public class RetrospectiveEngineTests
  {
    RetrospectiveEngine _engine;

    public RetrospectiveEngineTests()
    {
      _engine = new RetrospectiveEngine();
      var repository = new RetrospectiveRepository();
      var mapper = new Mapper(new MapperConfiguration(new AutoMapper.Configuration.MapperConfigurationExpression()));
      var controller = new RetrospectiveController(
        repository,
        _engine,
        mapper
      );
      _engine.Initialise(controller, repository, mapper);
    }

    [Fact]
    public void Get_WhenCalled_ReturnsObject()
    {
      // Act
      var result = _engine.Get(new RetrospectiveForGetDto { Id = 1 }).Result;

      // Assert
      var retrospective = Assert.IsType<RetrospectiveForReturnDto>(result);
      Assert.Equal("Retrospective 1", retrospective.Name);
    }

    [Fact]
    public void GetAll_WhenCalled_ReturnsList()
    {
      // Act
      var result = _engine.GetAll(new RetrospectiveForGetAllDto()).Result;

      // Assert
      var retrospectives = Assert.IsType<AllRetrospectivesForReturnDto>(result);
      var items = retrospectives.Retrospectives as List<RetrospectiveForReturnDto>;
      Assert.Single(items);
    }
  }
}
