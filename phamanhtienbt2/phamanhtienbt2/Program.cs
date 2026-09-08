
using System;

namespace phamanhtienbt2
{

    public class Person
    {
        public string Id { get; init; }
        public string FullName { get; set; }
        public int BirthYear { get; set; }


        public Person(string id, string fullName, int birthYear)
        {
            Id = id;
            FullName = fullName;
            BirthYear = birthYear;
        }


        public int GetAge(int currentYear)
        {
            return currentYear - BirthYear;
        }
    }



    public class Employee : Person
    {
        public decimal BaseSalary { get; set; }


        public Employee(
            string id,
            string fullName,
            int birthYear,
            decimal baseSalary)
            : base(id, fullName, birthYear)
        {
            BaseSalary = baseSalary;
        }


        public virtual decimal CalculateIncome()
        {
            return BaseSalary;
        }
    }



    public sealed class Manager : Employee
    {
        public decimal ResponsibilityAllowance { get; set; }

   
        public Manager(
            string id,
            string fullName,
            int birthYear,
            decimal baseSalary,
            decimal allowance)
            : base(id, fullName, birthYear, baseSalary)
        {
            ResponsibilityAllowance = allowance;
        }


        public override decimal CalculateIncome()
        {
            return BaseSalary + ResponsibilityAllowance;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            int currentYear = 2026;

            Console.WriteLine("======================================");
            Console.WriteLine("     HE THONG QUAN LY NHAN VIEN");
            Console.WriteLine("======================================");
            Console.WriteLine();


            Console.WriteLine("----- NHAP THONG TIN EMPLOYEE -----");

            Console.Write("Nhap ID: ");
            string employeeId = Console.ReadLine();

            Console.Write("Nhap ho ten: ");
            string employeeName = Console.ReadLine();

            Console.Write("Nhap nam sinh: ");
            int employeeBirthYear = int.Parse(Console.ReadLine());

            Console.Write("Nhap luong co ban: ");
            decimal employeeSalary =
                decimal.Parse(Console.ReadLine());


        
            Employee employee = new Employee(
                employeeId,
                employeeName,
                employeeBirthYear,
                employeeSalary
            );


            Console.WriteLine();



            Console.WriteLine("----- NHAP THONG TIN MANAGER -----");

            Console.Write("Nhap ID: ");
            string managerId = Console.ReadLine();

            Console.Write("Nhap ho ten: ");
            string managerName = Console.ReadLine();

            Console.Write("Nhap nam sinh: ");
            int managerBirthYear = int.Parse(Console.ReadLine());

            Console.Write("Nhap luong co ban: ");
            decimal managerSalary =
                decimal.Parse(Console.ReadLine());

            Console.Write("Nhap phu cap trach nhiem: ");
            decimal allowance =
                decimal.Parse(Console.ReadLine());


            Manager manager = new Manager(
                managerId,
                managerName,
                managerBirthYear,
                managerSalary,
                allowance
            );


            Console.WriteLine();
            Console.WriteLine();


    

            Console.WriteLine("======================================");
            Console.WriteLine("          PHIEU LUONG EMPLOYEE");
            Console.WriteLine("======================================");

            Console.WriteLine("ID: " + employee.Id);
            Console.WriteLine("Ho ten: " + employee.FullName);
            Console.WriteLine(
                "Tuoi: " + employee.GetAge(currentYear)
            );

            Console.WriteLine(
                "Luong co ban: " +
                employee.BaseSalary.ToString("N0") +
                " VND"
            );

            Console.WriteLine(
                "Thu nhap thuc linh: " +
                employee.CalculateIncome().ToString("N0") +
                " VND"
            );


            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("======================================");
            Console.WriteLine("          PHIEU LUONG MANAGER");
            Console.WriteLine("======================================");

            Console.WriteLine("ID: " + manager.Id);
            Console.WriteLine("Ho ten: " + manager.FullName);

            Console.WriteLine(
                "Tuoi: " + manager.GetAge(currentYear)
            );

            Console.WriteLine(
                "Luong co ban: " +
                manager.BaseSalary.ToString("N0") +
                " VND"
            );

            Console.WriteLine(
                "Phu cap trach nhiem: " +
                manager.ResponsibilityAllowance.ToString("N0") +
                " VND"
            );

            Console.WriteLine(
                "Thu nhap thuc linh: " +
                manager.CalculateIncome().ToString("N0") +
                " VND"
            );



            Console.WriteLine();
            Console.WriteLine("Nhan phim bat ky de ket thuc...");
            Console.ReadKey();
        }
    }
}

