using System;
using PrimeiroExercicio.Entities.Enums;
using System.Globalization;
using PrimeiroExercicio.Entities;

namespace PrimeiroExercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entre com o Nome do Departamento: ");
            string deptName = Console.ReadLine();

            Console.WriteLine("Entre com os dados do trabalhador:");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Level do Funcionario (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.WriteLine("Entre com salário base do Funcionario: ");
            double baseSalary = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.WriteLine("Quantos Contratos para este trabalhador? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Entre com os Dados do contrato #{i}: ");
                Console.Write("Data (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.Write("Valor Por Hora: ");
                double hoursValue = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

                Console.WriteLine("Horas Trabalhadas: ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract (date,hoursValue,hours);
                worker.AddContract(contract);

            }

            Console.WriteLine("Entre com o mês e ano para calcular o ganho (MM/YYYY) ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine();
            Console.WriteLine("Nome do Trabalhador: "+ worker.Nome);
            Console.WriteLine("Departamento: "+worker.Department.Name);
            Console.WriteLine("Lucro do mês " + monthAndYear + ": " + worker.Income(year, month).ToString("f2",CultureInfo.InvariantCulture));








        }
    }
}