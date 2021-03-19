using System;
using System.Collections.Generic;
using System.Text;

namespace SondaDemo.Models
{
    public class ResponseApi
    {
        public message msg { get; set; }
    }
    public class message
    {
        public string code { get; set; }
        public string msg { get; set; }
    }
}
