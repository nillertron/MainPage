using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class MS_Picture:BaseModel
    {
        public int Id { get; set; }
        public int MS_PortfolioId { get; set; }
        private string _Url;
        public string Url { get => FormatString(_Url); set { value = FormatString(value); _Url = value; } }
        public bool FrontFoto { get; set; }

        private string FormatString(string fix)
        {
            var index = 0;
            bool replaced = false;
            for (int i = 0; i < fix.Length; i++)
            {
                if (fix[i] == 'i' && fix[i + 1] == 'm' && fix[i + 2] == 'a')
                {
                    index = i;
                    replaced = true;
                    break;
                }
            }
            return replaced?"http://www.nillertron.com/" + fix.Substring(index, fix.Length - index):fix;
        }
    }
}
