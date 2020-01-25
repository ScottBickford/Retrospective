using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retrospective.API.Data
{
  public interface IRetrospectiveRepository
  {
    Task<Models.Retrospective> GetRetrospective(int id);
    Task<Models.Retrospective> GetRetrospectiveByName(string name);
    Task<IEnumerable<Models.Retrospective>> GetAllRetrospectives(DateTime? date);
    Task AddRetrospective(Models.Retrospective retrospective);
    Task AddFeedback(int retrospectiveId, Models.Feedback feedback);
  }
}
