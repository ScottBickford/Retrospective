using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retrospective.API.Models
{
  public class Feedback
  {
    public int FeedbackId { get; set; }
    public string Name { get; set; }
    public string Body { get; set; }
    public string FeedbackType { get; set; }
  }
}
