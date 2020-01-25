using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retrospective.API.Dtos
{
  public class AllRetrospectivesForReturnDto : BaseResponse_Dto
  {
    public List<RetrospectiveForReturnDto> Retrospectives { get; set; }
  }
}
