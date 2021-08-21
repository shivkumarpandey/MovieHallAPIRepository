using System;
using System.Collections.Generic;
using System.Text;

namespace MovieHallAPI.Contracts
{
   public class ResponseBase
    {
        string MessageId { get; set; }
        DateTime RequestDateTime { get; set; }
    }
}
