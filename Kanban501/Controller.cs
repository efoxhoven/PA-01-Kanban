using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kanban501
{
    public class Controller
    {
        public delegate void ObserverDel(List<Task> tasks);
        private List<ObserverDel> observers = new List<ObserverDel>();

        private List<Task> tasks = new List<Task>();

        private Form1 view;


        public Controller(Form1 view)
        {
            this.view = view;
            view.RegisterAdd(AddTask);
            view.RegisterDelete(DeleteTask);
            view.RegisterEdit(EditTask);
            view.RegisterClose(SaveTasks);

            RegisterObserver(view.RefreshDisplay);

            LoadTasks();
            NotifyObservers();
        }

        public void RegisterObserver(ObserverDel observer) {
            observers.Add(observer);
        }

        public void NotifyObservers() {
            //Sorting tasks by priority
            var sortedTasks = tasks.OrderByDescending(t => t.Priority).ToList();

            foreach (var observer in observers) {
                observer(sortedTasks);
            }
        }

        public void AddTask(string title, string resources, string status, DateTime dueDate, int priority)
        {
            Task newTask = new Task(title, resources, status, dueDate, priority);
            tasks.Add(newTask);
            NotifyObservers();
        }

        public void DeleteTask(Task task)
        {
            tasks.Remove(task);
            NotifyObservers();
        }

        public void EditTask(Task task, string title, string resources, string status, DateTime dueDate, int priority)
        {
            task.Name = title;
            task.Resources = resources;
            task.Status = status;
            task.DueDate = dueDate;
            task.Priority = priority;
            NotifyObservers();
        }


        private void LoadTasks()
        {
            string file = "GoalActivity.txt";
            if (!File.Exists(file)) { return; }

            string[] lines = File.ReadAllLines(file);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) { continue; }
                string[] parts = line.Split(',');

                Task task = new Task(parts[0], parts[1], parts[2], DateTime.Parse(parts[3]), int.Parse(parts[4]));
                tasks.Add(task);
            }
            NotifyObservers();
        }

        //Public wrapper for saving file
        public void SaveAllTasks() { SaveTasks(); }

        private void SaveTasks()
        {
            string file = "GoalActivity.txt";
            List<string> lines = new List<string>();

            foreach (Task t in tasks)
            {
                lines.Add($"{t.Name},{t.Resources},{t.Status},{t.DueDate:MM/dd/yyyy},{t.Priority}");
            }
            File.WriteAllLines(file, lines);
        }

    }
}