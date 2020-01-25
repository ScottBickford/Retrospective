using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retrospective.API.Dtos
{
  public class RetrospectiveForGetAllDto : BaseRequest_Dto
  {
    public DateTime? Date { get; set; }
  }
}
