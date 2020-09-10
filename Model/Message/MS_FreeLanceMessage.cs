using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MS_FreeLanceMessage:MS_Message
    {
        public string FreelanceJobType { get; set; }
        public double Budget { get; set; }
        public string ClientLocation { get; set; }
        public string Currency { get; set; }
        public DateTime DeadLine { get; set; } = DateTime.Now;


    }
}
