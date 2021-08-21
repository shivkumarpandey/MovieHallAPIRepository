using System;
using System.Collections.Generic;
using System.Text;

namespace MovieHallAPI.Contracts
{
   public class RequestBase
    {
        public string MessageId { get; set; }
        public DateTime RequestDateTime { get; set; }
    }
}
