namespace EmployeeRepository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Department
    {
        public long Id { get; set; }

        [StringLength(1000)]
        public string Name { get; set; }
    }
}
