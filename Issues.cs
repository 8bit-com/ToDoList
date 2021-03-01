using System;

namespace ToDoList
{
    class Issues
    {
        public Issue[] arr;

        public Issues()
        {
            arr = new Issue[1];
            arr[0] = new Issue();
            arr[0].Title = "Test";
            arr[0].Status = Status.New;
            arr[0].Date = DateTime.Now;
            arr[0].Description = "Тестовая задача";
        }

        public void ArrResize()
        {
            Issue[] newarr = new Issue[arr.Length + 1];

            for (int i = 0; i < arr.Length; i++)
            {
                newarr[i] = arr[i]; 
            }

            newarr[newarr.Length - 1] = new Issue();

            newarr[newarr.Length - 1].Title = "Новая задача";

            arr = newarr;
        }

        public void DelIssue(int x)
        {
            Issue[] newarr = new Issue[arr.Length - 1];

            for (int i = 0; i < newarr.Length; i++)
            {
                newarr[i] = arr[ ((i>=x)?i+1:i) ];
            }

            arr = newarr;
        }
    }
}