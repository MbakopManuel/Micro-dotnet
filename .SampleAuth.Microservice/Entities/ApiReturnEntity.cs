using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAuth.Microservice.Entities
{
    public class ApiReturnEntity
    {
        public string status { get; set; }
        public Object data {get; set;}
    }
}
