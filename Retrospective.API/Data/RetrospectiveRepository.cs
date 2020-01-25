using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retrospective.API.Data
{
  public class RetrospectiveRepository : IRetrospectiveRepository
  {
    #region Create Data
    private static ICollection<Models.Retrospective> _retrospectives;

    private ICollection<Models.Retrospective> retrospectives {
      get {
        if (_retrospectives == null)
        {
          // Initialize some data for in memory testing
          _retrospectives = new List<Models.Retrospective>
          {
            new Models.Retrospective
            {
              RetrospectiveId = 1,
              Name = "Retrospective 1",
              Summary = "Post release retrospective",
              Date = new DateTime(2016,7,27),
              Participants = new List<string> { "Viktor", "Gareth", "Mike" },
              Feedback = new List<Models.Feedback>
              {
                new Models.Feedback
                {
                  FeedbackId = 1,
                  Name = "Gareth",
                  Body = "Sprint objective met",
                  FeedbackType = "Postive"
                },
                new Models.Feedback
                {
                  FeedbackId = 2,
                  Name = "Viktor",
                  Body = "Too many items piled up in the awaiting QA",
                  FeedbackType = "Negative"
                },
                new Models.Feedback
                {
                  FeedbackId = 3,
                  Name = "Mike",
                  Body = "We should be looking to start using VS2015",
                  FeedbackType = "Idea"
                }
              }
            }
          };
        }
        return _retrospectives;
      }
    }
    #endregion

    public async Task<Models.Retrospective> GetRetrospective(int retrospectiveId)
    {
      // There is a warning above as we are not using an async method, calling a db will be done async, however for now we are calling the information in memory.
      // Alternately we could wrap the method in a task to take care of the warning
      return retrospectives.FirstOrDefault(r => r.RetrospectiveId == retrospectiveId);
    }

    public async Task<Models.Retrospective> GetRetrospectiveByName(string name)
    {
      // There is a warning above as we are not using an async method, calling a db will be done async, however for now we are calling the information in memory.
      // Alternately we could wrap the method in a task to take care of the warning
      return retrospectives.FirstOrDefault(r => string.Compare(r.Name, name) == 0);
    }

    public async Task<IEnumerable<Models.Retrospective>> GetAllRetrospectives(DateTime? date)
    {
      return retrospectives.Where(r => !date.HasValue || r.Date.Date == date.Value.Date);
    }

    public async Task AddRetrospective(Models.Retrospective retrospective)
    {
      retrospective.RetrospectiveId = retrospectives.Count() + 1;
      retrospectives.Add(retrospective);
    }

    public async Task AddFeedback(int retrospectiveId, Models.Feedback feedback)
    {
      var retrospective = retrospectives.FirstOrDefault(r => r.RetrospectiveId == retrospectiveId);
      if (retrospective == null) { return; }
      if (retrospective.Feedback == null) { retrospective.Feedback = new List<Models.Feedback>(); }
      feedback.FeedbackId = retrospective.Feedback.Count() + 1;
      retrospective.Feedback.Add(feedback);
    }
  }
}
