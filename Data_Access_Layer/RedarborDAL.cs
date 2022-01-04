using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Linq;


namespace Data_Access_Layer
{
    public class RedarborDAL
    {
        db dbop = new db();
        string msg = string.Empty;

        public async Task<List<Employee>> GetAllEmployee()
        {
            return await GetEmployeeList();
        }
        public async Task<List<Employee>> GetEmployeeById(int id)
        {
            return await GetEmployee(id);
        }
        private async Task<List<Employee>> GetEmployee(int id)
        {
            DataSet ds;
            List<Employee> employeeById;
            GetEmployeeData(id, out ds, out employeeById);

            await Task.Run(() =>
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    employeeById.Add(new Employee
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        CompanyId = dr["CompanyId"].ToString(),
                        CreatedOn = (DateTime)dr["CreatedOn"],
                        DeletedOn = (DateTime)dr["DeletedOn"],
                        Email = dr["Email"].ToString(),
                        Fax = dr["Fax"].ToString(),
                        TestName = dr["TestName"].ToString(),
                        LastLogin = (DateTime)dr["LastLogin"],
                        Password = dr["Password1"].ToString(),
                        PortalId = dr["PortalId"].ToString(),
                        RoleId = dr["RoleId"].ToString(),
                        StatusId = dr["StatusId"].ToString(),
                        Telephone = dr["Telephone"].ToString(),
                        UpdatedOn = (DateTime)dr["UpdatedOn"],
                        Username = dr["UserName"].ToString()


                    });

                }
            });
            return employeeById;
        } 
        public async Task<string> InsertEmployee(Employee emp)
        {
            string msg = string.Empty;
            try
            {
                msg = await dbop.EmployeeOpt(emp);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;

        }
        public async Task<string> UpdateEmployee(int id, Employee emp)
        {
            string msg = string.Empty;
            try
            {
                emp.ID = id;
                msg = await dbop.EmployeeOpt(emp);
            }
            catch (Exception ex)
            {

                msg = ex.Message;
            }
            return msg;

        }
        public async Task<string> DeleteEmployee(int id)
        {
            string msg = string.Empty;
            try
            {
                Employee emp = new Employee();
                emp.ID = id;
                emp.type = "delete";
                msg = await dbop.EmployeeOpt(emp);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;

        }
        public async Task<List<Employee>> GetEmployeeList()
        {
            DataSet ds;
            List<Employee> listEmployee;
            GetListData(out ds, out listEmployee);

            await Task.Run(() =>
            {


                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    listEmployee.Add(new Employee
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        CompanyId = dr["CompanyId"].ToString(),
                        CreatedOn = (DateTime)dr["CreatedOn"],
                        DeletedOn = (DateTime)dr["DeletedOn"],
                        Email = dr["Email"].ToString(),
                        Fax = dr["Fax"].ToString(),
                        TestName = dr["TestName"].ToString(),
                        LastLogin = (DateTime)dr["LastLogin"],
                        Password = dr["Password1"].ToString(),
                        PortalId = dr["PortalId"].ToString(),
                        RoleId = dr["RoleId"].ToString(),
                        StatusId = dr["StatusId"].ToString(),
                        Telephone = dr["Telephone"].ToString(),
                        UpdatedOn = (DateTime)dr["UpdatedOn"],
                        Username = dr["UserName"].ToString(),
                        //type = dr["type"].ToString()

                    });

                }
            });


            return listEmployee;
        }
        private void GetListData(out DataSet ds, out List<Employee> listEmployee)
        {
            Employee emp = new Employee();
            emp.type = "get";
            ds = dbop.EmployeeGet(emp, out msg);
            listEmployee = new List<Employee>();
        }
        private void GetEmployeeData(int id, out DataSet ds, out List<Employee> employeeById)
        {
            Employee emp = new Employee();
            emp.ID = id;
            emp.type = "getid";
            ds = dbop.EmployeeGet(emp, out msg);
            employeeById = new List<Employee>();
        }
    }
}