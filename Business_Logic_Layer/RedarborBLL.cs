using Data_Access_Layer.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    //Business Logic Layer -- BLL
    public class RedarborBLL
    {

        private readonly Data_Access_Layer.RedarborDal _DAL;

        public RedarborBLL()
        {
            _DAL = new Data_Access_Layer.RedarborDal();
        }
        public async Task<List<Employee>> GetAllEmployee()
        {
            return await _DAL.GetAllEmployee();
        }
        public async Task<List<Employee>> GetEmployeeById(int id)
        {
            return await _DAL.GetEmployeeById(id);
        }
        public async Task<string> InsertEmployee(Employee emp)
        {
            return await _DAL.InsertEmployee(emp);
        }
        public async Task<string> UpdateEmployee(int id, Employee emp)
        {
            return await _DAL.UpdateEmployee(id, emp);
        }
        public async Task<string> DeleteEmployee(int id)
        {
            return await _DAL.DeleteEmployee(id);
        }
    }
}
