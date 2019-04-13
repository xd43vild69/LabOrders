using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderProcedures
    {
        public int PatientID { get; set; }
    }
    public class Get_OrderPatient_ByPatientID
    {
        public int OrderPatientID { get; set; }
        public int PatientID { get; set; }
        public int OrderTypeID { get; set; }
        public int OrderStateID { get; set; }
        public int OrderPriorityID { get; set; }
        public string Posology { get; set; }
        public string NameOrderState { get; set; }
        public string NameOrderPriority { get; set; }
        public string NameType { get; set; }
        public string FirstName { get; set; }
        public string MedicalHistory { get; set; }
    }
    public class Insert_OrderPatient
    {
        public int OrderPatientID { get; set; }
    }
}
