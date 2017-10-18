using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTemplate.Models
{
    public class Participant
    {
        public string NoregId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Amount { get; set; }
        public String City { get; set; }
    }
}