using System;
using System.Collections.Generic;
using System.Text;

namespace SondaDemo.Models
{
    public class CreateUser
    {
        public Header header { get; set; }
        public Data_RequestCreateUser data { get; set; }
    }
    public class Data_RequestCreateUser
    {
        public UserCreate user { get; set; }
    }
    public class UserCreate
    {
        public string name { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string numberDoc { get; set; }
        public string password { get; set; }
    }
}
