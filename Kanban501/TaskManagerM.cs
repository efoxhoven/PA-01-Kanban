using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kanban501
{
    public class TaskManagerM
    {

        private List<Task> toDoTasks = new List<Task>();
        private List<Task> workingTasks = new List<Task>();
        private List<Task> doneTasks = new List<Task>();

        public TaskManagerM()
        {
            tasks = new List<Task>();
        }

        public void Update()
        {

        }

        public String GetData()
        {
            String data = "";



            return data;
        }

        public void ReadInPreviousTasks()
        {
            string file = "GoalActivity.txt";
            if (!File.Exists(file)) { return; }

            string[] lines = File.ReadAllLines(file);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) { continue; }
                string[] parts = line.Split(',');

                Task task = new Task(parts[0], parts[1], parts[2], DateTime.Parse(parts[3]));
                changeTaskColumn(task);
            }
            //RefreshListBox(); UPDATE UI HERE
        }

        private void changeTaskColumn(Task task)
        {
            toDoTasks.Remove(task);
            workingTasks.Remove(task);
            doneTasks.Remove(task);
            if (task.Status == "To Do" && toDoTasks.Count < 15)
            {
                toDoTasks.Add(task);
            }
            else if (task.Status == "Working On" && workingTasks.Count < 3)
            {
                workingTasks.Add(task);
            }
            else if (task.Status == "Done")
            {
                doneTasks.Add(task);
            }
        }
    }
}
