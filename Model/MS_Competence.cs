using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class MS_Competence : BaseModel
    {
        public int Id { get; set; }
        public string Kompetence { get; set; }
        public int Stars { get; set; }
    }
}
