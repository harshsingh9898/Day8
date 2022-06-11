using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpWageProblem
{
    
    public class EmpWage : IComputeEmpWage
    {
        public const int FULL_TIME = 1;
        public const int PART_TIME = 2;
        public static int empHrs = 0;
        int empWage;
        int days = 1;
        int empWorkingHrs = 0;
        emppp[] CompanyRecord = new emppp[5];
        public int numOfCompany = 0;

       
        public IList<emppp> CompanyEmpWge;
        public IDictionary<string, emppp> employees;

        
        public EmpWage()
        {
            this.CompanyEmpWge = new List<emppp>();
            this.employees = new Dictionary<string, emppp>();
        }
       
        public void AddCompany(string company, int empRatePerHr, int maxWorkingDays, int maxWorkingHrs)
        {
            emppp emp = new emppp(company, empRatePerHr, maxWorkingDays, maxWorkingHrs);
            CompanyEmpWge.Add(emp);
            employees.Add(company, emp);
        }

        
        public void GetWage()
        {
            foreach (emppp empp in this.CompanyEmpWge)
            {
                empp.SetTotalWage(CalWage(empp));
            }

        }
       
        public int CalWage(emppp emp)
        {
            int totalWage = 0;
            Random random = new Random();
            while (empWorkingHrs <= emp.maxWorkingHrs && days <= emp.maxWorkingDays)
            {
                int randomInput = random.Next(0, 3);
           
                GetWorkingHrs(randomInput);
                empWage = emp.empRatePerHr * empHrs;
                
                totalWage += empWage;
                empWorkingHrs += empHrs;

                if (empWorkingHrs > emp.maxWorkingHrs)
                {
                    empWorkingHrs = emp.maxWorkingHrs;
                    break;
                }
                days++;

            }
            Console.WriteLine("\ncompany : {0} , Total wage is : {1} ", emp.company, totalWage);
            return totalWage;
        }
       
        public int GetTotalWage(string company)
        {
            return this.employees[company].totalWage;
        }

        //method to calculate  calculate working hours
        public static void GetWorkingHrs(int randomInput)
        {

            switch (randomInput)
            {
                case FULL_TIME:
                    empHrs = 8;
                    //Console.WriteLine("Employee is present fulltime "+empHrs);
                    break;
                case PART_TIME:
                    empHrs = 4;
                    //Console.WriteLine("Employee is present parttime " +empHrs);
                    break;
                default:
                    empHrs = 0;
                    //Console.WriteLine("Employee is absent " +empHrs);
                    break;
            }
        }
    }

}
