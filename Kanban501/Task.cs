using Kanban501;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kanban501
{
    public class Task
    {
        public string Name { get; set; }

        public string Resources { get; set; }

        public string Status { get; set; }

        public DateTime DueDate { get; set; }

        public int Priority { get; set; }


        public override string ToString()
        {
            if (Status != "Done" && DueDate < DateTime.Now)
            {
                return "⚠ OVERDUE - " + Name;
            }
            return Name;
        }

        public Task(string name, string resources, string status, DateTime dueDate, int priority)
        {
            Name = name;
            Resources = resources;
            Status = status;
            DueDate = dueDate;
            Priority = priority;
        }
    }
}
