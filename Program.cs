using System;
using System.IO;

namespace TestingS
{
    public class Users
    {

        public string Login;
        public string Password;
        public string FIO;
        public bool Role;

        public void addUsers()
        {

            Label:
            Console.WriteLine("Логин");
            Login = Console.ReadLine();
            BinaryReader FR = new BinaryReader(File.Open("C:\\Users\\Татьяна\\Documents\\users.txt", FileMode.Open)); //открыть для проверки сущ логина


            bool f = false;
            while (FR.PeekChar() > 0) // проверка наличия символов
            {
                string L = FR.ReadString(); // считываем строку
                string P = FR.ReadString();
                string F = FR.ReadString();
                bool R = FR.ReadBoolean();
                if (L == Login)
                {

                    f = true;
                }

            }
            FR.Close();
            if (f == true)
            {

                Console.WriteLine("Пользователь с таким именем уже существует");
                goto Label; // отправит в начало регистрации
            }

            Console.WriteLine("Пароль");
            Password = Console.ReadLine();
            Console.WriteLine("ФИО");
            FIO = Console.ReadLine();
            Console.WriteLine("Права:");
            string s = Console.ReadLine();
            if (s == "Администратор" || s == "администратор")
            {
                Role = true;
            }
            else
            {
                Role = false;
            }
            BinaryWriter FP = new BinaryWriter(File.Open("C:\\Users\\Татьяна\\Documents\\users.txt", FileMode.Open)); // записать и открыть файл
            FP.Seek(0, SeekOrigin.End); //указатель в конец
            FP.Write(Login);
            FP.Write(Password);
            FP.Write(FIO);
            FP.Write(Role);
            FP.Close();
        }

        public void showUsers()
        {
            BinaryReader FP = new BinaryReader(File.Open("C:\\Users\\Татьяна\\Documents\\users.txt", FileMode.Open));
            while (FP.PeekChar() > 0)
            {
                Login = FP.ReadString();
                Password = FP.ReadString();
                FIO = FP.ReadString();
                Role = FP.ReadBoolean();
                Console.WriteLine("Логин: {0}", Login);
                Console.WriteLine("ФИО: {0}", FIO);
                if (Role == true)
                {
                    Console.WriteLine("Администратор:");
                }
                else
                {
                    Console.WriteLine("Пользователь:");
                }

            }
            Console.ReadKey();
            FP.Close();
        }

    }
    public class AdminPanel
    {
        string[] menu = new string[] {
            "Добавить вопрос",
            "Результаты тестов",
            "Информация о пользователях" };


        int pMenu = 0;
        ConsoleKeyInfo key;
        public void viewMenu()
        {
            while (pMenu != 3)
            {
                Console.Clear();
                for (int i = 0; i < menu.Length; i++)
                {
                    if (pMenu == i)
                    {
                        Console.WriteLine(">>" + menu[i]);
                    }
                    else
                    {
                        Console.WriteLine("" + menu[i]);
                    }
                }
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (pMenu < menu.Length - 1) pMenu++;
                    else pMenu = 0;
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (pMenu > 0) pMenu--;
                    else pMenu = menu.Length - 1;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    switch (pMenu)
                    {
                        case 0:
                            {
                                BankQuestions FB = new BankQuestions();
                                FB.addQuestion();
                                break;
                            }
                        case 1:
                            {
                                Results FB = new Results();
                                FB.showResult();
                                break;
                            }
                        case 2:
                            {
                                Users FB = new Users();
                                FB.showUsers();
                                break;
                            }



                    }
                }
            }
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            string[] menuP = new string[] {
            "Регистрация",
            "Авторизация",
             };


            int mainMenu = 0;
            ConsoleKeyInfo key;
            while (mainMenu != 3)
            { 
                for (int i = 0; i < menuP.Length; i++)
                {
                    if (mainMenu == i)
                    {
                        Console.WriteLine(">>" + menuP[i]);
                    }
                    else
                    {
                        Console.WriteLine("" + menuP[i]);
                    }
                }
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.DownArrow)
            {
                if (mainMenu < menuP.Length - 1) mainMenu++;
                else mainMenu = 0;
            }
            if (key.Key == ConsoleKey.UpArrow)
            {
                if (mainMenu > 0) mainMenu--;
                else mainMenu = menuP.Length - 1;
            }
                if (key.Key == ConsoleKey.Enter)
                {
                    switch (mainMenu)
                    {
                        case 0:
                            {
                                goto Label1;

                                break;
                            }
                        case 1:
                            {
                                Users User = new Users();
                                User.addUsers();

                                break;
                            }
                    }

                }


                Label1:
                BankQuestions FB = new BankQuestions();
                bool c = false;
                Label:
                Console.WriteLine("Логин: ");
                string l = Console.ReadLine();
                Console.WriteLine("Пароль: ");
                string p = Console.ReadLine();
                BinaryReader FR = new BinaryReader(File.Open("C:\\Users\\Татьяна\\Documents\\users.txt", FileMode.Open));
                while (FR.PeekChar() > 0)
                {
                    string L = FR.ReadString();
                    string P = FR.ReadString();
                    string F = FR.ReadString();
                    bool R = FR.ReadBoolean();
                    if (L == l && p == P)
                    {
                        c = true;
                        if (R == true)
                        {
                            AdminPanel AP = new AdminPanel();
                            AP.viewMenu();
                        }
                        else
                        {
                            Console.Clear();
                            FB.testAnswer(F);
                        }
                    }

                    /* Users User = new Users();
                     User.addUsers();
                     BankQuestions FB = new BankQuestions();
                     FB.testAnswer();*/

                    Console.ReadKey();
                }
                FR.Close();
                if (c == false)
                {
                    goto Label;

                    Console.ReadKey();
                }
            }
        }
    }
}

