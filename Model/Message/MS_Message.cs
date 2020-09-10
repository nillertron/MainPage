using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public abstract class MS_Message:BaseModel
    {
        public  int Id { get; set; }
        public  string Headline { get; set; }

        public  string Content { get; set; }
        public  bool Read { get; set; }
        public string SenderEmail { get; set; }
        public string SenderName { get; set; }

        public string SenderPhoneNumber { get; set; }

        public DateTime MessageSent { get; set; }
        public async Task CreateMessage()
        {

        }
    }
}
