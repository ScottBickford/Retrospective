using Retrospective.API.Engines;

namespace Retrospective.API.Data
{
  public interface IBaseController
  {
    IBaseEngine IBaseEngine { get; }
  }
}
