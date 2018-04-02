using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TestingS
{
    class Results
    {
        public string FIO;
        public float result;
        public void addResult(string sFIO, float fresult)
        {

            FIO = sFIO;
            result = fresult;
            BinaryWriter WR = new BinaryWriter(File.Open("C:\\Users\\Татьяна\\Documents\\Results.txt", FileMode.Open));
            WR.Seek(0, SeekOrigin.End);
            WR.Write(FIO);
            WR.Write(result);
            WR.Close();
        }
        public void showResult()
        {
            BinaryReader RR = new BinaryReader(File.Open("C:\\Users\\Татьяна\\Documents\\Results.txt", FileMode.Open));
            while (RR.PeekChar() > 0)
            {
                FIO = RR.ReadString();
                result = RR.ReadSingle();
                Console.WriteLine("ФИО :{0}", FIO);
                Console.WriteLine("Результат :{0}", result);
                Console.WriteLine("------------------------------------------------------------------");
            }
            RR.Close();
            Console.ReadKey();
        }
    }
}
