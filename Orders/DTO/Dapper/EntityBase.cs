using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EntityBase
    {
        public string ProcedureName { get; set; }
        public object InObject { get; set; }
        public object OutObject { get; set; }
    }
}
