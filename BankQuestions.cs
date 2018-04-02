using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TestingS
{
    class BankQuestions
    {
        public string Question;
        public string Answer1;
        public string Answer2;
        public string Answer3;
        public string Answer4;
        public string TrueAnswer;

        public void addQuestion()
        {
            Console.WriteLine("Вопрос");
            Question = Console.ReadLine();
            Console.WriteLine("1 вариант");
            Answer1 = Console.ReadLine();
            Console.WriteLine("2 вариант");
            Answer2 = Console.ReadLine();
            Console.WriteLine("3 вариант");
            Answer3 = Console.ReadLine();
            Console.WriteLine("4 вариант");
            Answer4 = Console.ReadLine();
            Console.WriteLine("Правильный вариант ответа");
            TrueAnswer = Console.ReadLine();

            BinaryWriter FP = new BinaryWriter(File.Open("C:\\Users\\Татьяна\\Documents\\BankQuestions.txt", FileMode.Open));
            FP.Seek(0, SeekOrigin.End);
            FP.Write(Question);
            FP.Write(Answer1);
            FP.Write(Answer2);
            FP.Write(Answer3);
            FP.Write(Answer4);
            FP.Write(TrueAnswer);
            FP.Close();
        }
        public void testAnswer( string FIO)
        {
            BinaryReader FR = new BinaryReader(File.Open("C:\\Users\\Татьяна\\Documents\\BankQuestions.txt", FileMode.Open));
            string Answer;
            float countCorrectAnswers = 0;
            float countQuestions = 0;
            while (FR.PeekChar() > 0)
            {
                Question = FR.ReadString();
                Answer1 = FR.ReadString();
                Answer2 = FR.ReadString();
                Answer3 = FR.ReadString();
                Answer4 = FR.ReadString();
                TrueAnswer = FR.ReadString();
                Console.WriteLine(Question);
                Console.WriteLine(Answer1);
                Console.WriteLine(Answer2);
                Console.WriteLine(Answer3);
                Console.WriteLine(Answer4);
                Answer = Console.ReadLine();
                countQuestions++;
                if (Answer == TrueAnswer)
                {
                    countCorrectAnswers++;
                }
                Console.Clear();

            }
            FR.Close();
            Console.WriteLine("Правильных ответов:{0}", countCorrectAnswers);
            Console.WriteLine("Всего вопросов в тесте:{0}", countQuestions);
            float Result = countCorrectAnswers / countQuestions * 100;
            Console.WriteLine("Результат :{0} %", Result );
            Results WriteResult = new Results();
            WriteResult.addResult(FIO, countCorrectAnswers);

        }
    }

}
