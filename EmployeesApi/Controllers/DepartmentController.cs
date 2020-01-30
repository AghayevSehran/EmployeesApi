using EmployeeRepository;
using EmployeesApi.App_Start;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeesApi.Controllers
{
    public class DepartmentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            var model = employeeModel.Departments.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
        public HttpResponseMessage Post(Request.Department department)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            var dep = MapperWrapper.Mapper.Map<Department>(department);
            employeeModel.Departments.Add(dep);
            employeeModel.SaveChanges();
            return Request.CreateResponse("Success");
        }

        public HttpResponseMessage Put(Request.Department department)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            var dep = MapperWrapper.Mapper.Map<Department>(department);
            employeeModel.Entry(dep).State = EntityState.Modified;
            employeeModel.SaveChanges();
            return Request.CreateResponse("Success");
        }

        public HttpResponseMessage Delete(int departmentid)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            var department = employeeModel.Departments.Find(departmentid);
            var dep = MapperWrapper.Mapper.Map<Department>(department);
            employeeModel.Entry(dep).State = EntityState.Deleted;
            employeeModel.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, dep);
        }


    }
}
