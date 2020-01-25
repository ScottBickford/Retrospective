using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Retrospective.API.Dtos
{
  public class BaseRetrospectiveDto : BaseResponse_Dto
  {
    [Required]
    public int RetrospectiveId { get; set; }

    [Required]
    public string Name { get; set; }

    public string Summary { get; set; }

    [Required]
    public DateTime? Date { get; set; }

    [Required]
    [MinLength(1, ErrorMessage="There must be at least 1 participant")]
    public List<string> Participants { get; set; }
  }

  public class BaseFeedbackDto : BaseResponse_Dto
  {
    [Required]
    public int FeedbackId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Body { get; set; }

    [Required]
    public string FeedbackType { get; set; }
  }
}
