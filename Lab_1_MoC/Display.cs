using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_MoC
{
    class Display
    {
        static public void DisplayTwoDimArray(double[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("|" + arr[i, j] + "\t");

                }
                Console.WriteLine();
            }

        }
        static public void DisplayList(List<int> list)
        {
            foreach (var element in list)
            {
                Console.Write(element + " ");
            }
        }

    }
}