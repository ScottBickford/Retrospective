using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retrospective.API.Models
{
  public class Retrospective
  {
    public int RetrospectiveId { get; set; }
    public string Name { get; set; }
    public string Summary { get; set; }
    public DateTime Date { get; set; }
    public ICollection<string> Participants { get; set; }
    public ICollection<Feedback> Feedback { get; set; }
  }
}
