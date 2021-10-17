using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab_1_MoC
{
    class Program
    {
        static void Main(string[] args)
        {
            InitialData variant6 = new InitialData();
            variant6.SetC("table_06.csv");
            variant6.SetMAndK("prob_06.csv");

            Statisctics var6 = new Statisctics();
            double[,] prMC_Cond_6 = var6.PrConditional_MC();
            for (int i = 0; i < prMC_Cond_6.GetLength(0); i++)
            {
                for (int j = 0; j < prMC_Cond_6.GetLength(1); j++)
                {
                    Console.Write(prMC_Cond_6[i, j] + "\t");

                }
                Console.WriteLine();
            }


            List<int> determFunc_6 = var6.DeterministicFunction();
            double avgLoss_6 = var6.AvgDeterministic();
            Console.WriteLine("Середні втрати детермiнiстичної функції: " + avgLoss_6);

            Console.WriteLine("--------------------------------------------------VARIANT 14----------------------------------------------------------");
            InitialData variant14 = new InitialData();
            variant14.SetC("table_14.csv");
            variant14.SetMAndK("prob_14.csv");

            Statisctics var14 = new Statisctics();
            double[,] prMC_Cond_14 = var14.PrConditional_MC();

            List<int> determFunc_14 = var14.DeterministicFunction();
            double avgLoss_14 = var14.AvgDeterministic();
            Console.WriteLine("Середні втрати детермiнiстичної функції: " + avgLoss_14);
        }
    }
}
