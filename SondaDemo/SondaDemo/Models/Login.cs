using System;
using System.Collections.Generic;
using System.Text;

namespace SondaDemo.Models
{
    public class Login
    {
        public Header header { get; set; }
        public Data_RequestLogin data { get; set; }
    }
    public class Data_RequestLogin
    {
        public Userlogin userlogin { get; set; }
    }
    public class Userlogin
    {
        public string email { get; set; }
        public string password { get; set; }
    }
    public class Header
    {
        public string invokeMethod { get; set; }
        public string channel { get; set; }
        public string operationSystem { get; set; }
        public string deviceModel { get; set; }
        public string applicationVersion { get; set; }
        public int osType { get; set; }
    }
}
