using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetBoard.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Re_Password { get; set; }
        public DateTime Created_Date { get; set; }
        public string Created_IP { get; set; }
        public DateTime Modified_Date { get; set; }
        public string Modified_IP { get; set; }
        public bool Is_Deleted { get; set; }
    }
}