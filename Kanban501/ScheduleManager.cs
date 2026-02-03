using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Kanban501
{
    public class ScheduleManager
    {

        private List<Task> _toDoTasks;
        private List<Task> _workingTasks;
        private List<Task> _doneTasks;

        private const int _maxToDo = 15;
        private const int _maxWorking = 3;

        public ScheduleManager()
        {
            _toDoTasks = new List<Task>();
        }
        public void AddToDo(Task task)
        {
            _toDoTasks.Add(task);
        }
        public void AddWorking(Task task)
        {
            _workingTasks.Add(task);
        }
        public void AddDone(Task task)
        {
            _doneTasks.Add(task);
        }

        public void RemoveToDo(Task task)
        {
            _toDoTasks.Remove(task);
        }
        public void RemoveWorking(Task task)
        {
            _workingTasks.Remove(task);
        }
        public void RemoveDone(Task task)
        {
            _doneTasks.Remove(task);
        }

    }
}
