using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Librarium;

namespace Task2
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
            Queue<Challenge> ExamsQueue = new Queue<Challenge>();
            // Вспомогательная переменная для заполнения очереди
            Random rnd = new Random();
            Challenge ElementToAdd = null;

            // Первоначальное заполнение таблицы
            for (ushort i = 0; i < 1000; i++)
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

                    ExamsQueue.Enqueue(ElementToAdd);
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
                    Console.WriteLine("5 - Поиск количества студентов, получивших за работу оценку не ниже заданной");
                    Console.WriteLine("6 - Поиск студентов, получивших за работу оценку не ниже заданной");
                    Console.WriteLine("7 - Поиск студентов, получивших за экзамен оценку не ниже заданной");
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

                            ExamsQueue.Clear();
                            // Ввод количества элементов
                            int NumberToAdd = InputOutput.InputNumber(10, 1000);

                            for (ushort i = 0; i < NumberToAdd; i++)
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

                            ExamsQueue.Enqueue(ElementToAdd);

                            Console.WriteLine("Новая таблица успешно создана.");
                            ok = true;
                            break;

                        // Печать таблицы
                        case 2:
                            foreach (Challenge Element in ExamsQueue)
                                Element.Show();
                            ok = true;
                            break;

                        // Удаление элемента
                        case 3:
                            ExamsQueue.Dequeue();
                            Console.WriteLine("Первый элемент коллекции удален.");

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
                                    Console.Write("Введите ФИО студента: ");
                                    string Name = Console.ReadLine();
                                    Console.Write("Введите общее количество задач: ");
                                    ushort TasksTotal = UInt16.Parse(Console.ReadLine());
                                    Console.Write("Введите количество решенных задач: ");
                                    ushort TasksDone = UInt16.Parse(Console.ReadLine());

                                    ExamsQueue.Enqueue(new Challenge(Name, TasksTotal, TasksDone));
                                    break;

                                case 2:
                                    Console.Write("Введите ФИО студента: ");
                                    Name = Console.ReadLine();
                                    Console.Write("Введите общее количество задач: ");
                                    TasksTotal = UInt16.Parse(Console.ReadLine());
                                    Console.Write("Введите количество решенных задач: ");
                                    TasksDone = UInt16.Parse(Console.ReadLine());

                                    ExamsQueue.Enqueue(new Test(Name, TasksTotal, TasksDone));
                                    break;

                                case 3:
                                    Console.Write("Введите ФИО студента: ");
                                    Name = Console.ReadLine();
                                    Console.Write("Введите общее количество задач: ");
                                    TasksTotal = UInt16.Parse(Console.ReadLine());
                                    Console.Write("Введите количество решенных задач: ");
                                    TasksDone = UInt16.Parse(Console.ReadLine());
                                    Console.Write("Введите предмет, по которому был экзамен: ");
                                    string Subject = Console.ReadLine();

                                    ExamsQueue.Enqueue(new Exam(Name, Subject, TasksTotal, TasksDone));
                                    break;

                                case 4:
                                    Console.Write("Введите ФИО студента: ");
                                    Name = Console.ReadLine();
                                    Console.Write("Введите общее количество задач: ");
                                    TasksTotal = UInt16.Parse(Console.ReadLine());
                                    Console.Write("Введите количество решенных задач: ");
                                    TasksDone = UInt16.Parse(Console.ReadLine());
                                    Console.Write("Введите предмет, по которому был экзамен: ");
                                    Subject = Console.ReadLine();
                                    Console.Write("Введите учебное заведение, откуда выпускается студент: ");
                                    string Organisation = Console.ReadLine();

                                    ExamsQueue.Enqueue(new GraduateExam(Name, Subject, Organisation, TasksTotal, TasksDone));
                                    break;
                            }

                            ok = true;
                            break;

                        case 5:
                            // Счетчик
                            int Counter = 0;
                            // Ввод оценки
                            double MarkToFind = InputOutput.InputMark();
                            // Перебор элементов
                            foreach (Challenge Element in ExamsQueue)
                            {
                                if (Element.GetMark >= MarkToFind)
                                    Counter++;
                            }
                            Console.WriteLine("{0} студентов получили за работу оценку не менее {1}.", Counter, MarkToFind);

                            ok = true;
                            break;

                        case 6:
                            // Ввод оценки
                            MarkToFind = InputOutput.InputMark();
                            Console.WriteLine("Студенты, получившие за работу оценку не менее {0}:", MarkToFind);
                            // Перебор элементов
                            foreach (Challenge Element in ExamsQueue)
                            {
                                if (Element.GetMark >= MarkToFind)
                                    Element.Show();
                            }

                            ok = true;
                            break;

                        case 7:
                            // Ввод оценки
                            MarkToFind = InputOutput.InputMark();
                            Console.WriteLine("Студенты, получившие за экзамен оценку не менее {0}:", MarkToFind);
                            // Перебор элементов
                            foreach (Challenge Element in ExamsQueue)
                            {
                                // Если экзамен и удовлетворяет условию
                                if ((Element is Exam) || (Element is GraduateExam) &&
                                    (Element.GetMark >= MarkToFind))
                                    Element.Show();
                            }

                            ok = true;
                            break;

                        // Клонирование очереди
                        case 8:
                            Queue<Challenge> ClonedQueue = new Queue<Challenge>();
                            foreach (Challenge Element in ClonedQueue)
                                Element.Show();
                            ok = true;
                            break;

                        // Сортировка очереди
                        case 9:
                            ExamsQueue.OrderBy(Element => Element.GetName);
                            Console.WriteLine("Отсортированная по возрастанию имен очередь: ");
                            foreach (Challenge Element in ExamsQueue)
                                Element.Show();
                            ok = true;
                            break;

                        // Поиск элемента по ключу
                        case 10:
                            Console.Write("Введите ключ (ФИО) элемента, который Вы хотите найти: ");
                            string KeyToFind = Console.ReadLine();
                            if (!ExamsQueue.Any(Element => Element.GetName == KeyToFind))
                                Console.WriteLine("Элемента с таким ключом не найдено.");
                            else
                                foreach (Challenge Element in ExamsQueue)
                                    if (Element.GetName == KeyToFind)
                                        Element.Show();

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
