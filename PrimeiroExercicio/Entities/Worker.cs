using System;
using System.Collections.Generic;
using PrimeiroExercicio.Entities.Enums;

namespace PrimeiroExercicio.Entities
{
    class Worker
    {
        public string Nome { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List <HourContract> Contracts { get; set; } = new List<HourContract> ();   // não adicionado no construtor , para muitos

        public Worker()
        {

        }

        public Worker(string nome, WorkerLevel level, double baseSalary, Department department)
        {
            Nome = nome;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract (HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;
            foreach (HourContract contract in Contracts)
            {
                 if (contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.TotalValue();
                }
            }
            return sum;
        }
    }
}
