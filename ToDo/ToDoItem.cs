using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo
{
    public class ToDoItem
    {
        public ToDoItem(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public bool Completed { get; set; }

        public static IEnumerable<ToDoItem> GetToDoItems()
        {
            return new List<ToDoItem>
            {
                new ToDoItem("Go to work"),
                new ToDoItem("Stand-up meeting, with my stand-up colleagues"),
                new ToDoItem("Lunch time"),
                new ToDoItem("Go to gym"),
                new ToDoItem("Family time")
            };
        }
    }
}
