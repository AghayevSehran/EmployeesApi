using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeesApi.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            MapperWrapper.Initialize(cfg =>
            {
                cfg.CreateMap<EmployeesApi.Request.Employee, EmployeeRepository.Employee>();
                cfg.CreateMap<EmployeesApi.Request.Department, EmployeeRepository.Department>();
            });

            MapperWrapper.AssertConfigurationIsValid();
        }
    }
}