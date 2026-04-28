using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiterfassung_console
{
    class ZeitObjekt
    {
        public DateTime CreationTime { get; set; } 
        public string Start { get; set; }
        public string End { get; set; }

        public ZeitObjekt(string sta, string end)
        {
            this.Start = sta;
            this.End = end;
            CreationTime = DateTime.Now;

        }
    }
}
