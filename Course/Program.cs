using System;
using System.Globalization;
using System.Collections.Generic;
using Course.Entities;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> taxPayers = new List<TaxPayer>();

            Console.Write("Enter the number of tax payers: ");
            var nTaxPayers = int.Parse(Console.ReadLine());

            for(int i = 1; i <= nTaxPayers; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Tax payer #{i} data:");

                Console.Write("Individual or company (i/c)? ");
                var responsePayer = char.Parse(Console.ReadLine().ToLower());

                Console.Write("Name: ");
                var name = Console.ReadLine();

                Console.Write("Anual income: ");
                var anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                
                if(responsePayer == 'i')
                {
                    Console.Write("Health expenditures: ");
                    var healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    taxPayers.Add(new Individual(name, anualIncome, healthExpenditures));
                }
                else
                {
                    Console.Write("Number of employees: ");
                    var numberOfEmployees = int.Parse(Console.ReadLine());
                    taxPayers.Add(new Company(name, anualIncome, numberOfEmployees));
                } 
            }

            Console.WriteLine();
            Console.WriteLine("TAXES PAID");
            
            var sum = 0.0;

            foreach(var taxPayer in taxPayers)
            {
                Console.WriteLine("{0}: $ {1}", taxPayer.Name, taxPayer.Tax().ToString("F2", CultureInfo.InvariantCulture));
                sum += taxPayer.Tax();            
            }

            Console.WriteLine();
            Console.WriteLine("TOTAL PAXES: $ {0}", sum.ToString("F2", CultureInfo.InvariantCulture));
            Console.ReadKey();
        }
    }
}
