using System;
using static ToDoList.Operations;

namespace ToDoList
{
    class Program
    {
        delegate void Delegate();
        
        static void Main(string[] args)
        {
            Delegate[] delegs = new Delegate[] { Print, AddIssue, DelIssue, EditIssue, DoneIssue};

            Console.WriteLine("    Вывести список задач");
            Console.WriteLine("    Добавить задачу");
            Console.WriteLine("    Удалить задачу");
            Console.WriteLine("    Редактировать задачу");
            Console.WriteLine("    Отметить задачу как выполненую");
            Console.WriteLine("    Escape - Выход");

            CursorPrint(y, true);

            do
            {
                if (Console.KeyAvailable)
                {
                    key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.DownArrow && y < 5)
                    {
                        CursorPrint(y, print: false);
                        y++;
                        CursorPrint(y, print: true);
                    }
                    if (key == ConsoleKey.UpArrow && y > 0)
                    {
                        CursorPrint(y, print: false);
                        y--;
                        CursorPrint(y, print: true);
                    }

                    if (key == ConsoleKey.Enter)
                    {
                        for (int i = 0; i < delegs.Length; i++)
                        {
                            if (y == i)
                            {
                                delegs[i]();
                                y = i;
                                CursorPrint(y, true);
                            }
                        }
                        if (y == 5) break;
                    }
                }
            } while (key != ConsoleKey.Escape);
        }
    }
}