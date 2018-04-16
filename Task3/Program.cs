using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Librarium;

namespace Task3
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

            // Стек элементов иерархии
            MyStack<Challenge> ExamsStack = new MyStack<Challenge>();
            // Вспомогательная переменная для заполнения стека
            Random rnd = new Random();
            Challenge ElementToAdd = null;

            // Первоначальное заполнение стека
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

                ExamsStack.Push(ElementToAdd);
            }

            Console.WriteLine("Успешно создан новый стек емкостью {0} с количеством элементов {1}.",
                ExamsStack.Capacity, ExamsStack.Count);

            do
            {
                do
                {
                    Console.Clear();
                    //Вывод меню
                    Console.WriteLine();
                    Console.WriteLine("1 - Создание нового стека");
                    Console.WriteLine("2 - Печать стека");
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

                            ExamsStack.Clear();
                            // Ввод количества элементов
                            int NumberToAdd = InputOutput.InputNumber(10, 1000);
                            ExamsStack = new MyStack<Challenge>(NumberToAdd);

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

                            ExamsStack.Push(ElementToAdd);

                            Console.WriteLine("Успешно создан новый стек емкостью {0} с количеством элементов {1}.", 
                                ExamsStack.Capacity, ExamsStack.Count);
                            ok = true;
                            break;

                        // Печать таблицы
                        case 2:
                            foreach (Challenge Element in ExamsStack)
                                Element.Show();
                            ok = true;
                            break;

                        // Удаление элемента
                        case 3:
                            ExamsStack.Pop();
                            Console.WriteLine("Последний элемент стека удален.");
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

                                    ExamsStack.Push(new Challenge(Name, TasksTotal, TasksDone));
                                    break;

                                case 2:
                                    Console.Write("Введите ФИО студента: ");
                                    Name = Console.ReadLine();
                                    Console.Write("Введите общее количество задач: ");
                                    TasksTotal = UInt16.Parse(Console.ReadLine());
                                    Console.Write("Введите количество решенных задач: ");
                                    TasksDone = UInt16.Parse(Console.ReadLine());

                                    ExamsStack.Push(new Test(Name, TasksTotal, TasksDone));
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

                                    ExamsStack.Push(new Exam(Name, Subject, TasksTotal, TasksDone));
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

                                    ExamsStack.Push(new GraduateExam(Name, Subject, Organisation, TasksTotal, TasksDone));
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

                        // Клонирование стека
                        case 8:
                            Queue<Challenge> ClonedQueue = new Queue<Challenge>();
                            foreach (Challenge Element in ClonedQueue)
                                Element.Show();
                            ok = true;
                            break;

                        // Сортировка стека
                        case 9:
                            Console.WriteLine("Отсортированный по возрастанию имен стек: ");
                            foreach (Challenge Element in ExamsStack)
                                Element.Show();
                            ok = true;
                            break;

                        // Поиск элемента по ключу
                        case 10:
                            Option = 0;
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

                                    Console.WriteLine("В коллекции присутствует указанный элемент: {0}", 
                                        ExamsStack.Contains(new Challenge(Name, TasksTotal, TasksDone)));
                                    break;

                                case 2:
                                    Console.Write("Введите ФИО студента: ");
                                    Name = Console.ReadLine();
                                    Console.Write("Введите общее количество задач: ");
                                    TasksTotal = UInt16.Parse(Console.ReadLine());
                                    Console.Write("Введите количество решенных задач: ");
                                    TasksDone = UInt16.Parse(Console.ReadLine());

                                    Console.WriteLine("В коллекции присутствует указанный элемент: {0}",
                                        ExamsStack.Contains(new Test(Name, TasksTotal, TasksDone)));
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

                                    Console.WriteLine("В коллекции присутствует указанный элемент: {0}",
                                        ExamsStack.Contains(new Exam(Name, Subject, TasksTotal, TasksDone)));
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

                                    Console.WriteLine("В коллекции присутствует указанный элемент: {0}",
                                        ExamsStack.Contains(new GraduateExam(Name, Subject, Organisation, TasksTotal, TasksDone)));
                                    break;
                            }

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
