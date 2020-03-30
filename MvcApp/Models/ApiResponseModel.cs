using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace MvcApp.Models
{
    public class ApiResponseModel
    {
        public JArray Response { get; set; }
    }
}
