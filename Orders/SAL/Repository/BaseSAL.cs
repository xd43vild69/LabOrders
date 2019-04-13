using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DTO;

namespace SAL.Repository
{
    public class BaseSAL
    {

        public EntityBase EntityBase { get; set; }

        public string CONNECTION_STRING { get; set; }

        public BaseSAL()
        {
            CONNECTION_STRING  = ConfigurationManager.ConnectionStrings["StringConn"].ConnectionString;
        }
    }
}
