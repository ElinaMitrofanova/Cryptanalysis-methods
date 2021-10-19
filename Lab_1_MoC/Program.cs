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
            Display.DisplayTwoDimArrayInExcel(prMC_Cond_6, "result_PMC_Cond_6.xlsx");

            double[,] st6 = var6.StochasticMatrix();
            Display.DisplayTwoDimArrayInExcel(st6, "result_st_6.xlsx" );


            List<int> determFunc_6 = var6.DeterministicFunction();
            Console.WriteLine("Deterministic function: ");
            Display.DisplayList(determFunc_6);

            double avgLossDet_6 = var6.AvgDeterministic();
            Console.WriteLine();
            Console.WriteLine("AvgDetLoss: " + avgLossDet_6);
            double avgLossStoch_6 = var6.AvgStochastic();
            Console.WriteLine("AvgStLoss: " + avgLossStoch_6);

            Console.WriteLine("--------------------------------------------------VARIANT 14----------------------------------------------------------");
            InitialData variant14 = new InitialData();
            variant14.SetC("table_14.csv");
            variant14.SetMAndK("prob_14.csv");

            Statisctics var14 = new Statisctics();
            double[,] prMC_Cond_14 = var14.PrConditional_MC();
            Display.DisplayTwoDimArrayInExcel(prMC_Cond_14, "result_PMC_Cond_14.xlsx");

            double[,] st14 = var14.StochasticMatrix();
            Display.DisplayTwoDimArrayInExcel(st6, "result_st_14.xlsx");

            List<int> determFunc_14 = var14.DeterministicFunction();
            Console.WriteLine("Deterministic function: ");
            Display.DisplayList(determFunc_14);

            double avgLossDet_14 = var14.AvgDeterministic();
            Console.WriteLine("AvgDetLoss: " + avgLossDet_14);
            double avgLossStoch_14 = var14.AvgStochastic();
            Console.WriteLine("AvgStLoss: " + avgLossStoch_14);
        }
    }
}
