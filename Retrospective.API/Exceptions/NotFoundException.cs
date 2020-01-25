using System;

namespace Retrospective.API.Exceptions
{
  public class NotFoundException : Exception
  {
    public NotFoundException(string message) : base(message) { }
  }
}
