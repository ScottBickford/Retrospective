using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retrospective.API.Dtos
{
  public class FeedbackForCreateDto : BaseFeedbackDto
  {
    public int RetrospectiveId { get; set; }
  }
}
