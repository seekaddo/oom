using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task6
{
    public class Employee
    {
        public string Name { get; }
        public string EmployeeId { get; }
        public string JobType { get; }
        public string Company { get; }
        public string Location { get; }

        public Employee(string name, string employeeId, string jobType, string company, string location)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Name can't be null {0}", nameof(name));
            if (jobType != null && string.IsNullOrEmpty(employeeId))
                throw new ArgumentException("employeeId can't be null {0}", nameof(employeeId));
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Name can't be null {0}", nameof(name));
            if (string.IsNullOrEmpty(location))
                throw new ArgumentException("I hope you are not living on the strights {0}", nameof(location));

            Name = name;
            EmployeeId = employeeId;

            JobType = jobType ?? "Job-hunting";
            Company = company;
            Location = location;
        }


        public bool Isemployed()

        {
            return this.JobType != null;
        }

        public static Task<List<Employee>> GetGermanEmployeeListAsync(List<Employee> em){
            return Task.Run(() => em.Where(k => k.Location.Equals("Germany")).ToList());
        }
    }
}
