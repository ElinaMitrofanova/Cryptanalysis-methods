﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_MoC
{
    class Statisctics: InitialData
    {
        public double[] Pr_CipherText()
        {
            double[] prС = new double[C.GetLength(0)];
            for (int i = 0; i < C.GetLength(0); i++)
            {
                for (int j = 0; j < C.GetLength(1); j++)
                {
                    prС[C[i, j]] += Math.Round(M[j] * k[i],4);
                    prС[C[i, j]] = Math.Round(prС[C[i, j]], 4);

                }
            }
            return prС;
        }

        public double[,] Pr_MC()
        {
            double[,] prMC = new double[C.GetLength(0), C.GetLength(1)];
            for (int i = 0; i < C.GetLength(0); i++)
            {
                for (int j = 0; j < C.GetLength(1); j++)
                {
                    prMC[C[i, j],j] += M[j] * k[i];
                    prMC[C[i, j], j] = Math.Round(prMC[C[i, j], j], 4);
                }
            }
            return prMC;
        }
         public double[,] PrConditional_MC()
        {
            double [] prC = Pr_CipherText();
            double[,] prMC= Pr_MC();
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

        public List<double> DeterministicFunction()
        {
            double[,] prMC_Cond = PrConditional_MC();
            List<double> maxList = new List<double>();
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
        void StochasticMatrix()
        {
            List<double> deterministicFunction = DeterministicFunction();
            double[,] stMatrix= new double[C.GetLength(0), C.GetLength(1)];

        }
    }
}