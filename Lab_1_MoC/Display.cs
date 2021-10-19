using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_MoC
{
    class Display
    {
        static public void DisplayTwoDimArrayInExcel(double[,] arr,string filename)
        {

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

                FileInfo excelFile = new FileInfo(@"C:\Users\ellun\Desktop\" + filename);

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    workSheet.Cells[i+1, j+1].Value = Math.Round(arr[i, j], 4).ToString();
                }
            }
            FileInfo fi = new FileInfo(@"C:\Users\ellun\Desktop\" + filename);
                excelPackage.SaveAs(fi);
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