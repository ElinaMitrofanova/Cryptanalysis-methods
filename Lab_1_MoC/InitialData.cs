using System;
using System.IO;
using System.Linq;

namespace Lab_1_MoC
{
    class InitialData
    {
        static protected double[] M;
        static protected double[] k;
        static protected int[,] C;
        string defaultpath = "C:/Users/ellun/source/repos/Lab_1_MoC/Lab_1_MoC/Data/";
    public void SetMAndK(string filename)
        {
            string path = defaultpath + filename;
            var lines = File.ReadLines(path).ToList();
            M = new double[lines[0].Length];
            k = new double[lines[0].Length];
            M = lines[0].Split(',').Select(s => double.Parse(s.Replace(".", ","))).ToArray();
            k = lines[1].Split(',').Select(s => double.Parse(s.Replace(".", ","))).ToArray();
        }

        public void SetC(string filename)
        {
            string path = defaultpath + filename;
            var lines = File.ReadLines(path).ToList();
            C = new int[lines.Count, lines.Count];
            for (int line = 0; line < lines.Count; line++)
            {
                int[] temp = lines[line].Split(',').Select(s => Int32.Parse(s.Replace(".", ","))).ToArray();
                for ( int j=0; j<lines.Count;j++)
                {
                    C[line, j] = temp[j];
                }
            }
        }
    }
}