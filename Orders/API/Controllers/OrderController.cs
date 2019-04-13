using BAL;
using BAL.Rules;
using DTO;
using Newtonsoft.Json;
using System;
using System.Web.Http;
using AutoMapper;

namespace API.Controllers
{

    public class OrderController : ApiController
    {
        private OrderBAL OrderBal { get; set; }
        private EntityBase EntityBase { get; set; }

        public OrderController()
        {
            EntityBase = new EntityBase();
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                EntityBase.InObject = new { PatientID = id };
                OrderBal = ConfigIOC.GetInstance<OrderBAL>(EntityBase);
                return Ok(OrderBal.Get());
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        public IHttpActionResult Post([FromBody] object postParameters)
        {
            try
            {
                EntityBase.InObject = JsonConvert.DeserializeObject<Order>(postParameters.ToString());
                OrderBal = ConfigIOC.GetInstance<OrderBAL>(EntityBase);
                int PatientID = OrderBal.Post();

                return Ok("200 - Post!!!");
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Put([FromBody] object postParameters)
        {
            try
            {
                EntityBase.InObject = JsonConvert.DeserializeObject<Order>(postParameters.ToString());
                OrderBal = ConfigIOC.GetInstance<OrderBAL>(EntityBase);
                OrderBal.Put();

                return Ok("200 - Put!!!");
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}