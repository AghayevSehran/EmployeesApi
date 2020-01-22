namespace EmployeeRepository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        public long Id { get; set; }

        [StringLength(1000)]
        public string Name { get; set; }

        public long? DepartmentId { get; set; }

        [StringLength(200)]
        public string Email { get; set; }
    }
}
