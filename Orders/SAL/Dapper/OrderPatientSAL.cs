using Dapper;
using DTO;
using SAL.Repository;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SAL
{
    public class OrderPatientSAL: BaseSAL
    {

        public OrderPatientSAL(EntityBase entityBase)
        {
            EntityBase = entityBase;
        }

        public IEnumerable<Get_OrderPatient_ByPatientID> GetById()
        {
            using (var conn = new SqlConnection(base.CONNECTION_STRING))
            {
                return conn.Query<Get_OrderPatient_ByPatientID>("usp_select_OrderPatient_ByPatientID", EntityBase.InObject, null,true, null, System.Data.CommandType.StoredProcedure);
            }
        }

        public int Post()
        {
            using (var conn = new SqlConnection(base.CONNECTION_STRING))
            {
                return conn.QueryFirstOrDefault<Insert_OrderPatient>("usp_insert_OrderPatient", EntityBase.InObject, null, null, System.Data.CommandType.StoredProcedure).OrderPatientID;
            }
        }
        public void Put()
        {
            using (var conn = new SqlConnection(base.CONNECTION_STRING))
            {
                conn.Execute("usp_update_OrderPatient", EntityBase.InObject, null, null, System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
