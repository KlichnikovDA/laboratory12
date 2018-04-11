using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Librarium;

namespace Лабораторная_работа_12
{
    class Task1
    {
        static void ChooseTypeMenu(out string Subj)
        {
            //Флаг правильности ввода
            bool ok = false;
            Subj = "";

            do
            {
                //Вывод меню
                Console.WriteLine();
                Console.WriteLine("1 - Challenge");
                Console.WriteLine("2 - Test");
                Console.WriteLine("3 - Exam");
                Console.WriteLine("4 - GraduateExam");
                Console.WriteLine("5 - Отмена");

                //Выбор пункта меню и вызов соответствующих функций
                var ChosenOption = Console.ReadKey();
                Console.WriteLine();

                switch (ChosenOption.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Subj = "Линейная алгебра";
                        ok = true;
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Subj = "Аналитическая геометрия";
                        ok = true;
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Subj = "Математический анализ";
                        ok = true;
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Subj = "Программирование";
                        ok = true;
                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        Subj = "Английский язык";
                        ok = true;
                        break;

                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        ok = true;
                        break;
                }

            } while (!ok);
        }

        static void MainMenu()
        {
            //Флаг правильности ввода
            bool ok = true;
            //Флаг завершения работы
            bool Finish = false;

            // Хеш-таблица элементов иерархии
            Hashtable ExamsTable = new Hashtable();
            // Вспомогательная переменная для заполнения таблицы
            Random rnd = new Random();
            Challenge ElementToAdd = null;

            // Первоначальное заполнение таблицы
            for (ushort i = 0; i < 1000; i++)
            {
                do
                {
                    switch (rnd.Next(4))
                    {
                        case 0:ElementToAdd = new Challenge();
                            break;
                        case 1:
                            ElementToAdd = new Test();
                            break;
                        case 2:
                            ElementToAdd = new Exam();
                            break;
                        case 3:
                            ElementToAdd = new GraduateExam();
                            break;
                    }
                }
                while (ExamsTable.ContainsKey(ElementToAdd.GetName));

                ExamsTable.Add(ElementToAdd.GetName, ElementToAdd);
            }

            do
            {
                do
                {
                    Console.Clear();
                    //Вывод меню
                    Console.WriteLine();
                    Console.WriteLine("1 - Создание новой хеш-таблицы");
                    Console.WriteLine("2 - Печать хеш-таблицы");
                    Console.WriteLine("3 - Добавить новый элемент");
                    Console.WriteLine("4 - Удалить элемент");
                    Console.WriteLine("5 - ");
                    Console.WriteLine("6 - ");
                    Console.WriteLine("7 - ");
                    Console.WriteLine("8 - Клонирование коллекции");
                    Console.WriteLine("9 - Сортировка коллекции");
                    Console.WriteLine("10 - Поиск элемента с заданным ключом");
                    Console.WriteLine("11 - Выход");

                    //Выбор пункта меню и вызов соответствующих функций
                    int ChosenOption = Int32.Parse(Console.ReadLine());
                    Console.WriteLine();

                    switch (ChosenOption)
                    {
                        case 1:
                            // Ввод количества элементов
                            int NumberToAdd = InputOutput.InputNumber(100, 1000);

                            for (ushort i = 0; i < NumberToAdd; i++)
                            {
                                do
                                {
                                    switch (rnd.Next(4))
                                    {
                                        case 0:
                                            ElementToAdd = new Challenge();
                                            break;
                                        case 1:
                                            ElementToAdd = new Test();
                                            break;
                                        case 2:
                                            ElementToAdd = new Exam();
                                            break;
                                        case 3:
                                            ElementToAdd = new GraduateExam();
                                            break;
                                    }
                                }
                                while (ExamsTable.ContainsKey(ElementToAdd.GetName));

                                ExamsTable.Add(ElementToAdd.GetName, ElementToAdd);
                            }

                            Console.WriteLine("Новая таблица успешно создана.");
                            ok = true;
                            break;

                        case 2:
                            foreach (DictionaryEntry DE in ExamsTable)
                            {
                                Challenge Element = DE.Value as Challenge;
                                Element.Show();
                            }
                            ok = true;
                            break;

                        case 3:
                            Console.Write("Введите ключ (ФИО) элемента, который Вы хотите удалить: ");
                            string KeyToDelete = Console.ReadLine();
                            if (ExamsTable.ContainsKey(KeyToDelete))
                            {
                                ExamsTable.Remove(KeyToDelete);
                                Console.WriteLine("Элемент с указанным ключом удален.");
                            }
                            else
                                Console.WriteLine("Элемента с таким ключом не найдено.");
                            ok = true;
                            break;

                        case 4:
                            ok = true;
                            

                            break;

                        case 5:
                            ok = true;
                            break;

                        case 6:
                            ok = true;
                            break;

                        case 7:
                            ok = true;
                            break;

                        case 8:
                            ok = true;
                            break;

                        case 9:
                            ok = true;
                            break;
                        case 10:
                            ok = true;
                            break;

                        case 11:
                            Finish = ok = true;
                            break;

                        default:
                            ok = false;
                            break;
                    }
                } while (!ok);

                if (!Finish && ok)
                {
                    Console.WriteLine("Нажмите любую клавишу...");
                    Console.ReadKey();
                }

            } while (!Finish);
        }

        static void Main(string[] args)
        {
            MainMenu();
        }
    }
}
