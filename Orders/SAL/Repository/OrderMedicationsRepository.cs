using DTO;
using SAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace SAL
{
    public class OrderMedicationsRepository<T> : BaseSAL, IOrderRepository<T> where T : Order, new()
    {

        public Order Order { get; set; }

        public OrderMedicationsRepository(Order order)
        {
            Order = order;
        }

        public T GetById(int id)
        {
            Get_OrderPatient_ByPatientID parameters = new Get_OrderPatient_ByPatientID { PatientID = id };
            using (var conn = new SqlConnection(base.CONNECTION_STRING))
            {
                return conn.QueryFirstOrDefault<T>("usp_select_OrderPatient_ByPatientID", parameters, null, null, System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<T> GetLists()
        {
            throw new NotImplementedException();
        }

        public void Insert(T entidad)
        {
            throw new NotImplementedException();
        }

        public void Update(T entidad)
        {
            throw new NotImplementedException();
        }
    }
}
