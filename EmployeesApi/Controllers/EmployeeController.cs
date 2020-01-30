using EmployeeRepository;
using EmployeesApi.App_Start;
using EmployeesApi.Response;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeesApi.Controllers
{
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            var model =(from emp in  employeeModel.Employees 
                       join dep in employeeModel.Departments
                       on emp.DepartmentId equals dep.Id
                       select new Response.Employee {
                           Id = emp.Id,
                           DepartmentId = emp.DepartmentId,
                           DepartmentName = dep.Name,
                       Name=  emp.Name,
                           Email = emp.Email}).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        public HttpResponseMessage Put(Request.Employee employee)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            var dep = MapperWrapper.Mapper.Map<EmployeeRepository.Employee>(employee);
            employeeModel.Entry(dep).State = EntityState.Modified;
            employeeModel.SaveChanges();
            return Request.CreateResponse("Success");
        }
        public HttpResponseMessage Delete(int employeeid)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            var employee = employeeModel.Employees.Find(employeeid);
            var dep = MapperWrapper.Mapper.Map<EmployeeRepository.Employee>(employee);
            employeeModel.Entry(dep).State = EntityState.Deleted;
            employeeModel.SaveChanges();
            return Request.CreateResponse("Success");
        }
    }
}
