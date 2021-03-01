using System;

namespace ToDoList
{
    class Issue
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }
    }
}