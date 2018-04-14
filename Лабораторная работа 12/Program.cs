using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Librarium;

namespace Лабораторная_работа_12
{
    class Program
    {
        static void ChooseTypeMenu(out int Option)
        {
            //Флаг правильности ввода
            bool ok = true;
            Option = 0;

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
                        Option = 1;
                        ok = true;
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Option = 2;
                        ok = true;
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Option = 3;
                        ok = true;
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Option = 4;
                        ok = true;
                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        ok = true;
                        break;

                    default:
                        ok = false;
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
                    Console.WriteLine("3 - Удалить элемент");
                    Console.WriteLine("4 - Добавить новый элемент");
                    Console.WriteLine("5 - ЗАПРОС");
                    Console.WriteLine("6 - ЗАПРОС");
                    Console.WriteLine("7 - ЗАПРОС");
                    Console.WriteLine("8 - Клонирование коллекции");
                    Console.WriteLine("9 - Сортировка коллекции");
                    Console.WriteLine("10 - Поиск элемента с заданным ключом");
                    Console.WriteLine("11 - Выход");

                    //Выбор пункта меню и вызов соответствующих функций
                    int ChosenOption = Int32.Parse(Console.ReadLine());
                    Console.WriteLine();

                    switch (ChosenOption)
                    {
                            // Создание новой таблицы
                        case 1:

                            ExamsTable.Clear();
                            // Ввод количества элементов
                            int NumberToAdd = InputOutput.InputNumber(10, 1000);

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

                            // Печать таблицы
                        case 2:
                            foreach (DictionaryEntry DE in ExamsTable)
                            {
                                Challenge Element = DE.Value as Challenge;
                                Element.Show();
                            }
                            ok = true;
                            break;

                            // Удаление элемента
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

                            // Создание элемента
                        case 4:
                            // Тип создаваемого объекта
                            int Option = 0;
                            ChooseTypeMenu(out Option);

                            switch (Option)
                            {
                                case 1:
                                    string Name = "";
                                    do
                                    {
                                        Console.Write("Введите ФИО студента: ");
                                        Name = Console.ReadLine();
                                        if (ExamsTable.ContainsKey(Name))
                                            Console.WriteLine("В таблице уже есть элемент с таким ключом.");
                                    } while (ExamsTable.ContainsKey(Name));
                                    Console.Write("Введите общее количество задач: ");
                                    ushort TasksTotal = UInt16.Parse(Console.ReadLine());
                                    Console.Write("Введите количество решенных задач: ");
                                    ushort TasksDone = UInt16.Parse(Console.ReadLine());

                                    ExamsTable.Add(Name, new Challenge(Name, TasksTotal, TasksDone));
                                    break;

                                case 2:
                                    do
                                    {
                                        Console.Write("Введите ФИО студента: ");
                                        Name = Console.ReadLine();
                                        if (ExamsTable.ContainsKey(Name))
                                            Console.WriteLine("В таблице уже есть элемент с таким ключом.");
                                    } while (ExamsTable.ContainsKey(Name));
                                    Console.Write("Введите общее количество задач: ");
                                    TasksTotal = UInt16.Parse(Console.ReadLine());
                                    Console.Write("Введите количество решенных задач: ");
                                    TasksDone = UInt16.Parse(Console.ReadLine());

                                    ExamsTable.Add(Name, new Test(Name, TasksTotal, TasksDone));
                                    break;

                                case 3:
                                    do
                                    {
                                        Console.Write("Введите ФИО студента: ");
                                        Name = Console.ReadLine();
                                        if (ExamsTable.ContainsKey(Name))
                                            Console.WriteLine("В таблице уже есть элемент с таким ключом.");
                                    } while (ExamsTable.ContainsKey(Name));
                                    Console.Write("Введите общее количество задач: ");
                                    TasksTotal = UInt16.Parse(Console.ReadLine());
                                    Console.Write("Введите количество решенных задач: ");
                                    TasksDone = UInt16.Parse(Console.ReadLine());
                                    Console.Write("Введите предмет, по которому был экзамен: ");
                                    string Subject = Console.ReadLine();

                                    ExamsTable.Add(Name, new Exam(Name, Subject, TasksTotal, TasksDone));
                                    break;

                                case 4:
                                    do
                                    {
                                        Console.Write("Введите ФИО студента: ");
                                        Name = Console.ReadLine();
                                        if (ExamsTable.ContainsKey(Name))
                                            Console.WriteLine("В таблице уже есть элемент с таким ключом.");
                                    } while (ExamsTable.ContainsKey(Name));
                                    Console.Write("Введите общее количество задач: ");
                                    TasksTotal = UInt16.Parse(Console.ReadLine());
                                    Console.Write("Введите количество решенных задач: ");
                                    TasksDone = UInt16.Parse(Console.ReadLine());
                                    Console.Write("Введите предмет, по которому был экзамен: ");
                                    Subject = Console.ReadLine();
                                    Console.Write("Введите учебное заведение, откуда выпускается студент: ");
                                    string Organisation = Console.ReadLine();

                                    ExamsTable.Add(Name, new GraduateExam(Name, Subject, Organisation, TasksTotal, TasksDone));
                                    break;
                            }

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

                            // Клонирование таблицы
                        case 8:
                            Hashtable ClonedTable = ExamsTable.Clone() as Hashtable;
                            foreach (DictionaryEntry DE in ClonedTable)
                                (DE.Value as Challenge).Show();
                            ok = true;
                            break;

                            // Сортировка таблицы
                        case 9:
                            // Список для сортировки
                            SortedList SortList = new SortedList(ExamsTable);
                            Console.WriteLine("Отсортированная таблица: "); 
                            foreach (DictionaryEntry Element in SortList)
                                (Element.Value as Challenge).Show();
                            ok = true;
                            break;

                            // Поиск элемента по ключу
                        case 10:
                            Console.Write("Введите ключ (ФИО) элемента, который Вы хотите найти: ");
                            string KeyToFind = Console.ReadLine();
                            if (!ExamsTable.ContainsKey(KeyToFind))
                                Console.WriteLine("Элемента с таким ключом не найдено.");
                            else
                                (ExamsTable[KeyToFind] as Challenge).Show();
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
