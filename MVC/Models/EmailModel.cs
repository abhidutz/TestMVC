using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class EmailModel
    {
        public string body { get; set; }
        public string subject { get; set; }
        public string sender { get; set; }
        public DateTime recievedDate { get; set; }
        public string reviever { get; set; }

    }
}