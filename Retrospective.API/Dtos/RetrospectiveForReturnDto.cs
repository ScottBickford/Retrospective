using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retrospective.API.Dtos
{
  public class RetrospectiveForReturnDto : BaseRetrospectiveDto
  {
    public List<BaseFeedbackDto> Feedback { get; set; }
  }
}
