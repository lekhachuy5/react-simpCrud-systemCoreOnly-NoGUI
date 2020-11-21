using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReactWeb.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReactWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CusController : ControllerBase
    {
        // GET: api/<CusController>
        private readonly IDataAccessProvider dataAccessProvider;
        public CusController(IDataAccessProvider dap)
        {
            dataAccessProvider = dap;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Cus>> Get()
        {
            return dataAccessProvider.GetPatientRecords();
        }
        [HttpPost] 
        public IActionResult Create([FromBody]Cus cus)
        {
            if (ModelState.IsValid)
            {
                dataAccessProvider.AddPatientRecord(cus);
                return Ok();
            }
            return BadRequest();
        }
        // GET api/<CusController>/5
        [HttpGet("{id}")]
        public Cus Details(long id)
        {
            return dataAccessProvider.GetPatientSingleRecord(id);
        }

        // POST api/<CusController>
       

        // PUT api/<CusController>/5
        [HttpPut("{id}")]
        public IActionResult Edit([FromBody]Cus cus)

        {
            if (ModelState.IsValid)
            {
                dataAccessProvider.UpdatePatientRecord(cus);
                return Ok();
            }
            return BadRequest();
        }

        // DELETE api/<CusController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var data = dataAccessProvider.GetPatientSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            dataAccessProvider.DeletePatientRecord(id);
            return Ok();
        }
    }
}
