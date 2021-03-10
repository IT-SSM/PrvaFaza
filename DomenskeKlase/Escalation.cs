using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLModifications.DomenskeKlase
{
  
    public class Escalation
    {
        public int IdJob { get; set; }
        public string TableName { get; set; }
        public int EscalationType { get; set; }
        public string Condition { get; set; }
        public string Action { get; set; }

        public System.Timers.Timer Timer { get; set; }
    }
}
