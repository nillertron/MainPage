using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class MS_Portfolio : BaseModel
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Beskrivelse { get; set; }
        public DateTime Published { get; set; } = DateTime.Now;
        public string ShortDescription { get; set; }
        public List<MS_Picture> PhotoLinks { get; set; } = new List<MS_Picture>();
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
