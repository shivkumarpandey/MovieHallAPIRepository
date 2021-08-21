using System;
using System.Collections.Generic;
using System.Text;

namespace MovieHallAPI.Contracts
{
   public class ResponseBase
    {
        public string MessageId { get; set; }
        public DateTime ResponseDateTime { get; set; }
    }
}
