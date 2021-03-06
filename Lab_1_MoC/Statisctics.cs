using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_MoC
{
    class Statisctics: InitialData
    {
        double [] prC = new double[C.GetLength(0)];
        double[,] prMC = new double[C.GetLength(0), C.GetLength(1)];
        public Statisctics()
        {
            for (int i = 0; i < C.GetLength(0); i++)
            {
                for (int j = 0; j < C.GetLength(1); j++)
                {
                    prC[C[i, j]] += Math.Round(M[j] * k[i],4);
                    prMC[C[i, j], j] += Math.Round(M[j] * k[i],4);
                }
            }
        }
         public double[,] PrConditional_MC()
         {
            double[,] prMC_Cond = new double[C.GetLength(0), C.GetLength(1)];
            for (int i = 0; i < C.GetLength(0); i++)
            {
                for (int j = 0; j < C.GetLength(1); j++)
                {
                    prMC_Cond[i, j] = Math.Round(prMC[i, j] / prC[i],4);
                }
            }
            return prMC_Cond;
        }
        public List<int> DeterministicFunction()
        {
            double[,] prMC_Cond = PrConditional_MC();
            List<int> maxList = new List<int>();
            for (int i = 0; i < prMC_Cond.GetLength(0); i++)
            {
                List<double> tempList = new List<double>();
                for (int j = 0; j < prMC_Cond.GetLength(1); j++)
                {
                    tempList.Add(prMC_Cond[i, j]);

                }
                maxList.Add(tempList.IndexOf(tempList.Max()));
            }
            return maxList;
        }

        public double AvgDeterministic()
        {
            double[,] prMC_Cond = PrConditional_MC();
            double avgLoss = 0;
            List<int> deterministicFunction = DeterministicFunction();
            for (int i = 0; i < prC.Length; i++)
            {
                avgLoss += prC[i] * (1 - prMC_Cond[i, deterministicFunction[i]]);
            }
            return avgLoss;
        }

       public double[,] StochasticMatrix()
        {
            double[,] prMC_Cond = PrConditional_MC();
            double[,] stMatrix = new double[C.GetLength(0), C.GetLength(1)];
            for (int i = 0; i < C.GetLength(0); i++)
            {
                List<double> tempElements = new List<double>();
                for (int j = 0; j < C.GetLength(1); j++)
                {
                    tempElements.Add(prMC_Cond[i, j]);
                }
                double maxElement = tempElements.Max();
                int maxCount = tempElements.Count(x => x == maxElement);
                for( int k= 0; k< tempElements.Count; k++)
                {
                    if (tempElements[k] == maxElement)
                    { 
                        stMatrix[i, k] = 1.0 / maxCount;
                    }
                }

            }
            return stMatrix;
        }
        public double AvgStochastic()
        {
            double[,] prMC_Cond = PrConditional_MC();
            double[,] stMatrix = StochasticMatrix();
            double avgLoss = 0;
            for (int i = 0; i < prMC_Cond.GetLength(0); i++)
            {
                List<double> temp = new List<double>();
                for (int j = 0; j < prMC_Cond.GetLength(1); j++)
                {
                    temp.Add(prMC_Cond[i, j] * stMatrix[i, j]);
                }
                avgLoss += prC[i]*(1-temp.Sum());
            }
            return avgLoss;
        }
    }
}