using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P4.Models
{
    public class Player
    {
        public int ID { get; set; }
        public String Registration_ID { get; set; }
        public String Player_name { get; set; }
        public String Team_name { get; set; }
        public DateTime Date_of_birth { get; set; }
    }
}