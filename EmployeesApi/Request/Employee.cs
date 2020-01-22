namespace EmployeesApi.Request
{
    public class Employee
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long? DepartmentId { get; set; }

        public string Email { get; set; }
    }
}