using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAL.Repository;
using DTO;
using SAL;

namespace BAL.Rules
{
    public class OrderBAL : Interfaces.IOrder<OrderBAL>
    {
        public IOrderRepository<Order> OrderRepository { get; set; }
        public OrderPatientSAL OrderPatientSAL { get; set; }
        public Order Order { get; set; }

        public OrderBAL(EntityBase entityBase)
        {
            OrderPatientSAL = new OrderPatientSAL(entityBase);
        }

        public OrderBAL(Object entity)
        {
            Order = (Order)entity;
            OrderRepository = new OrderMedicationsRepository<Order>(Order);
        }

        public object Get()
        {
            return OrderPatientSAL.GetById();
        }

        public IEnumerable<object> GetList()
        {
            throw new NotImplementedException();
        }

        public int Post()
        {
            return OrderPatientSAL.Post();
        }

        public void Put()
        {
            OrderPatientSAL.Put();
        }
    }
}
