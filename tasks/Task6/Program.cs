using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.InteropServices;
using System.Threading;
using static Task6.Employee;

namespace Task6
{
    public class Program
    {



        public static void Main(string[] args)
        {

            var employeeList = new List<Employee>()
                               {
                                   new Employee("Larry Johns","fh2015","System Administrator","GM Motors","Germany"),
                                   new Employee("Morris Hasdoc","wks2015","Publisher","RTL DE","Germany"),
                                   new Employee("Loskav Sissi","bmw200s","C/C++ Developer","BMW","Russia"),
                                   new Employee("James Braokigi","ksl0105","Techer","Wiener Kindergarten","Austria"),
                                   new Employee("Marry Adicos","ms4627xxx","Software Architect","OMV","Austria"),
                                   new Employee("Kannus Gerrad","as2003","IT Specialist","Kaspersky Lab","USA"),
                                   new Employee("Hausio Gastro","kia200s","C/C++ Developer","KIA Motors","Germany"),
                                   new Employee("Adam Borrows",null,null,"Online","Germany")
                               };

            //<summary>
            //initialising Subject and subscriber
            //processing data and converting it to obersable
            //</summary>
            var developers = new Subject<Employee>();
            Console.WriteLine("<----------List of Software Developers---------->");

            developers.Subscribe(p =>
                                 {
                                     Thread.Sleep(TimeSpan.FromSeconds(3));
                                     Console.WriteLine("Name: {0,-5}  Location:{1}", p.Name, p.Location);
                                 });

            var re = from p in employeeList
                     where p.JobType != null && p.JobType.Contains("Developer")
                     select p;

            foreach (var employee in re)
            {
                developers.OnNext(employee);

            }



            var germanyemployees = employeeList.Where(e => e.Isemployed() && e.Location.Contains("Germany")).ToObservable();
            Console.WriteLine();
            Console.WriteLine("<----------List of Employees in Germany---------->");

            germanyemployees.Subscribe(
                x =>
                {
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    Console.WriteLine("Name: {0,-5}     JobType: {1,-5}", x.Name, x.JobType);
                },
                ex => Console.WriteLine("OnError: {0}",ex.Message),
                ()=> Console.WriteLine("OnComplete")
            );


            //<summary>
            //Using Async and await
            //</summary>

            Console.WriteLine("<----------List of Employees in Germany With Async---------->");
            var lempy =  GetGermanEmployeeListAsync(employeeList);


            foreach (var l in  lempy.Result)
            {
                Console.WriteLine("Name: {0} jobType: {1}",l.Name,l.JobType);
            }



        }

    }
}
