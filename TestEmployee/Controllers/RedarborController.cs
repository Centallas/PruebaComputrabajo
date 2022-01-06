
using Data_Access_Layer.Repository.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestEmployee.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class RedarborController : ControllerBase
    {
        private readonly Business_Logic_Layer.RedarborBLL _bll;

        public RedarborController()
        {
            _bll = new Business_Logic_Layer.RedarborBLL();
        }

        //GET: api/<EmployeeController>
        [HttpGet]
        public async Task<List<Employee>> Get()
        {
            return await _bll.GetAllEmployee();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<List<Employee>> Get(int id)
        {
            return await _bll.GetEmployeeById(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<string> Post([FromBody] Employee emp)
        {
            return await _bll.InsertEmployee(emp);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<string> Put(int id, [FromBody] Employee emp)
        {
            return await _bll.UpdateEmployee(id, emp);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            return await _bll.DeleteEmployee(id);
        }
    }
}
