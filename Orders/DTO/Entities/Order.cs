using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Order 
    {
        public int OrderPatientID { get; set; }
        public int PatientID { get; set; }
        public int OrderTypeID { get; set; }
        public int OrderStateID { get; set; }
        public int OrderPriorityID { get; set; }
        public string Posology { get; set; }
    }
}
