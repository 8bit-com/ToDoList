using System;
using static ToDoList.Const;

namespace ToDoList
{
    public static class Operations
    {
        static Issues issues = new Issues();

        public static int y = 0;

        public static ConsoleKey key = ConsoleKey.D0;

        // Навигация по меню
        public static void MoveCursor(int Y)
        {
            if ((key == ConsoleKey.DownArrow) && (y < issues.arr.Length - 1 + Y))
            {
                CursorPrint(y, print: false);
                y++;
                CursorPrint(y, print: true);
            }

            if (key == ConsoleKey.UpArrow && y > Y)
            {
                CursorPrint(y, print: false);
                y--;
                CursorPrint(y, print: true);
            }
        }

        // Отрисовка курсора
        public static void CursorPrint(int y, bool print)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(1, y);
            Console.BackgroundColor = print ? ConsoleColor.Red : ConsoleColor.Black;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
        }

        // Очистка экрана
        private static void Clear()
        {
            Console.SetCursorPosition(0, 7);

            for (int i = 0; i < 18; i++)
            {
                Console.WriteLine("                                              ");
            }
        }
        public static void Print()
        {
            PrintList();

            y = L_MENU;

            CursorPrint(y, true);

            do
            {
                if (Console.KeyAvailable)
                {
                    key = Console.ReadKey(true).Key;

                    MoveCursor(L_MENU);                    

                    Console.SetCursorPosition(0, 9);

                    if (key == ConsoleKey.Enter)
                    {
                        for (int i = 0; i < issues.arr.Length; i++)
                        {
                            if (y == i + L_MENU)
                            {
                                Clear();
                                Console.SetCursorPosition(0, 9);

                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write("   Title: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(issues.arr[i].Title);

                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write("   Status: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(issues.arr[i].Status);

                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write("   Date: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(issues.arr[i].Date);

                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write("   Description: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(issues.arr[i].Description);

                                Console.ReadKey();
                                Clear();
                                break;
                            }
                        }
                        break;
                    }
                }
            } while (key != ConsoleKey.Escape);

            key = ConsoleKey.J;
        }

        // Вывести список задач
        public static void PrintList(string str = "Список задач")
        {
            Clear();

            Console.SetCursorPosition(0, 7);

            Console.Write("  Status ");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" - Done, ");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(" - New");
            Console.WriteLine();
            Console.WriteLine($"  {str}: ");
            Console.WriteLine();

            foreach (var item in issues.arr)
            {
                if (item.Status == Status.Done)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("    " + item.Title);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        // Добавить задачу
        public static void AddIssue()
        {
            Clear();

            Console.SetCursorPosition(2, 10);

            issues.ArrResize();

            Console.WriteLine("Новая задача добавлена");
        }

        // Отметить задачу как выполненую
        public static void DoneIssue()
        {
            PrintList("Выберите задачу для отметки");

            y = L_MENU;

            CursorPrint(y, true);

            do
            {
                if (Console.KeyAvailable)
                {
                    key = Console.ReadKey(true).Key;

                    MoveCursor(L_MENU);

                    if (key == ConsoleKey.Enter)
                    {
                        for (int i = 0; i < issues.arr.Length; i++)
                        {
                            if (y == i + L_MENU)
                            {
                                issues.arr[i].Status = Status.Done;
                                Clear();
                                Console.SetCursorPosition(2, L_MENU);
                                Console.WriteLine("Задача выполнена");
                                break;
                            }
                        }
                        break;
                    }
                }
            } while (key != ConsoleKey.Escape);

            key = ConsoleKey.J;
        }

        // Удалить задачу
        public static void DelIssue()
        {
            PrintList("Выберите задачу для удаления");            

            y = L_MENU;

            CursorPrint(y, true);

            do
            {
                if (Console.KeyAvailable)
                {
                    key = Console.ReadKey(true).Key;

                    MoveCursor(L_MENU);

                    if (key == ConsoleKey.Enter)
                    {
                        for (int i = 0; i < issues.arr.Length; i++)
                        {
                            if (y == i + L_MENU)
                            {
                                issues.DelIssue(i);
                                Clear();
                                Console.SetCursorPosition(2, L_MENU);
                                Console.WriteLine("Задача удалена");
                                break;
                            }
                        }
                        break;
                    }
                }
            } while (key != ConsoleKey.Escape);

            key = ConsoleKey.J;
        }

        // Редактировать задачу
        public static void EditIssue()
        {
            PrintList("Выберите задачу для редактирования");

            y = L_MENU;

            CursorPrint(y, true);
            do
            {
                if (Console.KeyAvailable)
                {
                    key = Console.ReadKey(true).Key;

                    MoveCursor(L_MENU);

                    if (key == ConsoleKey.Enter)
                    {
                        for (int i = 0; i < issues.arr.Length; i++)
                        {
                            if (y == i + L_MENU)
                            {
                                Clear();
                                Console.SetCursorPosition(2, L_MENU);
                                Console.WriteLine("Заголовок: " + issues.arr[i].Title);
                                Console.WriteLine("Введите новый заголовок: ");
                                Console.CursorVisible = true;
                                issues.arr[i].Title = Console.ReadLine();

                                Clear();
                                Console.SetCursorPosition(2, L_MENU);
                                Console.WriteLine("Описание: " + issues.arr[i].Description);
                                Console.WriteLine("Введите новое описание: ");
                                Console.CursorVisible = true;
                                issues.arr[i].Description = Console.ReadLine();

                                Clear();
                                Console.SetCursorPosition(2, L_MENU);
                                Console.WriteLine("Дата: " + issues.arr[i].Date);
                                Console.WriteLine("Введите новую дату: ");
                                Console.CursorVisible = true;
                                issues.arr[i].Date = DateTime.Parse(Console.ReadLine());

                                Clear();
                                Console.SetCursorPosition(2, L_MENU);
                                Console.WriteLine("Статус: " + issues.arr[i].Status);
                                Console.WriteLine("Введите новый статус(New - 0/ Done - 1): ");
                                Console.CursorVisible = true;
                                issues.arr[i].Status = (Status)int.Parse(Console.ReadLine());

                                Clear();
                                Console.SetCursorPosition(2, L_MENU);
                                Console.WriteLine("Задача исправлена");
                                Console.CursorVisible = false;
                                break;
                            }
                        }
                        break;
                    }
                }
            } while (key != ConsoleKey.Escape);

            key = ConsoleKey.J;
        }
    }
}
