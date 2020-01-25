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
  public class RetrospectiveControllerTests
  {
    RetrospectiveController _controller;

    public RetrospectiveControllerTests()
    {
      _controller = new RetrospectiveController(
        new RetrospectiveRepository(),
        new RetrospectiveEngine(),
        new Mapper(new MapperConfiguration(new AutoMapper.Configuration.MapperConfigurationExpression()))
        );
    }

    [Fact]
    public void Get_WhenCalled_ReturnsOkResult()
    {
      // Act
      var okResult = _controller.Get(new RetrospectiveForGetDto { Id = 1 });

      // Assert
      Assert.IsType<OkObjectResult>(okResult.Result);
    }

    [Fact]
    public void Get_WhenCalled_ReturnsObject()
    {
      // Act
      var okResult = _controller.Get(new RetrospectiveForGetDto { Id = 1 }).Result as OkObjectResult;

      // Assert
      var retrospective = Assert.IsType<RetrospectiveForReturnDto>(okResult.Value);
      Assert.Equal("Retrospective 1", retrospective.Name);
    }

    [Fact]
    public void GetAll_WhenCalled_ReturnsOkResult()
    {
      // Act
      var okResult = _controller.GetAll(new RetrospectiveForGetAllDto());

      // Assert
      Assert.IsType<OkObjectResult>(okResult.Result);
    }

    [Fact]
    public void GetAll_WhenCalled_ReturnsList()
    {
      // Act
      var okResult = _controller.GetAll(new RetrospectiveForGetAllDto()).Result as OkObjectResult;

      // Assert
      var retrospectives = Assert.IsType<AllRetrospectivesForReturnDto>(okResult.Value);
      var items = retrospectives.Retrospectives as List<RetrospectiveForReturnDto>;
      Assert.Single(items);
    }
  }
}
