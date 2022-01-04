
using Data_Access_Layer.Repository.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestEmployee.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class redarborController : ControllerBase
    {
        private Business_Logic_Layer.RedarborBLL _BLL;

        public redarborController()
        {
            _BLL = new Business_Logic_Layer.RedarborBLL();
        }

        //GET: api/<EmployeeController>
        [HttpGet]
        public async Task<List<Employee>> Get()
        {
            return await _BLL.GetAllEmployee();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<List<Employee>> Get(int id)
        {
            return await _BLL.GetEmployeeById(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<string> Post([FromBody] Employee emp)
        {
            return await _BLL.InsertEmployee(emp);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<string> Put(int id, [FromBody] Employee emp)
        {
            return await _BLL.UpdateEmployee(id, emp);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            return await _BLL.DeleteEmployee(id);
        }
    }
}
