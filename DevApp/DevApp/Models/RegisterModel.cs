using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidNotify.Models
{
   public class RegisterModel
    {
      public int DeviceType { get; set; }
      public string DeviceToken { get; set; }
      public string CustomerEmail { get; set; }
    }
    public class ResponseModel
    {
        public string Message { get; set; }
    }
}
