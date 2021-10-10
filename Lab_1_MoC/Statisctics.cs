using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_MoC
{
    class Statisctics: InitialData
    {
        static public double[] Pr_CipherText()
        {
            double[] prС = new double[C.GetLength(0)];
            for (int i = 0; i < C.GetLength(0); i++)
            {
                for (int j = 0; j < C.GetLength(1); j++)
                {
                    prС[C[i, j]] = M[i] * k[j] + prС[C[i, j]];
                
                }
            }
            return prС;
        }

        static public double[,] Pr_MC()
        {
            double[,] prMC = new double[C.GetLength(0), C.GetLength(1)];
            for (int i = 0; i < M.Length; i++)
            {
                for (int j = 0; j < M.Length; j++)
                {
                    prMC[C[i, j],j] = M[j] * k[i] + prMC[C[i, j],j];

                }
            }
            return prMC;
        }
    }
}
