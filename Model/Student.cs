using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Core.Services
{
  public class Student
    {
        public  int StudentId{ get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string PostalDistrict { get; set; }
        public string Email { get; set; }
    }
}
