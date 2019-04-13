using System;
using Moq;
using BAL;
using DTO;
using SAL.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using API;
using BAL.Rules;
using SAL.Repository;
using SAL;

namespace Test
{
    [TestClass]
    public class OrderMedicationTest
    {
        [TestMethod]
        public void IsNOTaValidaGetOrder()
        {
            // arrange
            //bool isValidCancelation = false;

            //Order order;// = new Order() { OrderPatientID  = 1, IdCodeActivity = 1, IdPriority = 1, IdState = 1, Name = "Medicamentos", Posology = "Medicina."};
            //var moqSet = new Mock<OrderMedicationsRepository<Order>>();

            //OrderBAL orderBal = new OrderBAL(moqSet.Object);

            ////moqSet.Setup(x => x.GetById(It.IsAny<int>())).Returns(order);

            //// act
            ////orderBal.Get(schedule.Id, schedule.Datebook);

            //// Assert
            //Assert.IsFalse(isValidCancelation);
        }
    }
}
