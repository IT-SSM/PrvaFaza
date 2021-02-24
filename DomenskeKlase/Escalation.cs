using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLModifications.DomenskeKlase
{
    public enum EscalationType
    {
        Time,
        Interval
    }
    public enum Action
    {
        SetField,
        PushField
    }
    public class Escalation
    {
        public int IdJob { get; set; }
        public string TableName { get; set; }
        public EscalationType EscalationType { get; set; }
        public string Condition { get; set; }
        public Action Action { get; set; }
    }
}
