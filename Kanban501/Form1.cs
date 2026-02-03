using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Kanban501
{
    public partial class Form1 : Form
    {

        private List<Task> toDoTasks = new List<Task>();
        private List<Task> workingTasks = new List<Task>();
        private List<Task> doneTasks = new List<Task>();


        public Form1()
        {
            InitializeComponent();
            LoadTasks();
            this.FormClosing += Form1_Closing; //subscribe method after it closes.
        }
        #region
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        private void LoadTasks()
        {
            string file = "GoalActivity.txt";
            if (!File.Exists(file)) { return; }

            string[] lines = File.ReadAllLines(file);
            foreach(string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) { continue; }
                string[] parts = line.Split(',');

                Task task = new Task(parts[0], parts[1], parts[2], DateTime.Parse(parts[3]));
                changeTaskColumn(task);
            }
            RefreshListBox();
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e) { SaveTasks(); }

        private void SaveTasks()
        {
            string file = "GoalActivity.txt";
            List<Task> allTasks = new List<Task>();
            List<string> lines = new List<string>();
            allTasks.AddRange(toDoTasks);
            allTasks.AddRange(workingTasks);
            allTasks.AddRange(doneTasks);
            foreach (Task t in allTasks)
            {
                lines.Add($"{t.Name},{t.Resources},{t.Status},{t.DueDate:MM/dd/yyyy}");
            }
            File.WriteAllLines(file, lines);
        }

        private void RefreshListBox()
        {
            toDoBox.Items.Clear();
            workingOnBox.Items.Clear();
            doneBox.Items.Clear();
            if (toDoBox.Items.Count >= 15 && workingOnBox.Items.Count >=3) {
                newButton.Enabled = false; // Disable add button if limits are reached
            }
            else { newButton.Enabled = true; }

            foreach (Task task in toDoTasks)
            {
                toDoBox.Items.Add(task);
            }
            foreach (Task task in workingTasks)
            {
                workingOnBox.Items.Add(task);
            }
            foreach (Task task in doneTasks)
            {
                doneBox.Items.Add(task);
            }
        }


        private void toDoBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void workingOnBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void doneBox_SelectedIndexChanged(object sender, EventArgs e)
        {

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
        
        /// <summary>
        /// Handles case where add button is clicked to build a new task.
        /// </summary>
        /// <param name="sender">s</param>
        /// <param name="e">e</param>
        private void addButton_Click(object sender, EventArgs e)
        {
            using (AddEdit form = new AddEdit())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.currentTask.Status == "To Do" && toDoTasks.Count < 15)
                    {
                        toDoTasks.Add(form.currentTask);
                    }
                    else if (form.currentTask.Status == "Working On" && workingTasks.Count < 3)
                    {
                        workingTasks.Add(form.currentTask);
                    }
                    else if (form.currentTask.Status == "Done")
                    {
                        doneTasks.Add(form.currentTask);
                    }
                    RefreshListBox();
                }
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            Task selected = null;
            if (toDoBox.SelectedItem == null && workingOnBox.SelectedItem == null && doneBox.SelectedItem == null) { return; } //If nothing is selected
            else if (toDoBox.SelectedItem != null)
            {
                selected = (Task)toDoBox.SelectedItem;
            }
            else if (workingOnBox.SelectedItem != null)
            {
                selected = (Task)workingOnBox.SelectedItem;
            }
            else if (doneBox.SelectedItem != null)
            {
                selected = (Task)doneBox.SelectedItem;
            }

            using (AddEdit form = new AddEdit(selected))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    changeTaskColumn(selected);
                    RefreshListBox();
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Task selected = null;
            if (toDoBox.SelectedItem == null && workingOnBox.SelectedItem == null && doneBox.SelectedItem == null) { return; } //If nothing is selected
            else if (toDoBox.SelectedItem != null)
            {
                selected = (Task)toDoBox.SelectedItem;
                toDoTasks.Remove(selected);
                toDoBox.SelectedItem = null;
            }
            else if (workingOnBox.SelectedItem != null)
            {
                selected = (Task)workingOnBox.SelectedItem;
                workingTasks.Remove(selected);
                workingOnBox.SelectedItem = null;
            }
            else if (doneBox.SelectedItem != null)
            {
                selected = (Task)doneBox.SelectedItem;
                doneTasks.Remove(selected);
                doneBox.SelectedItem = null;
            }
            RefreshListBox();
        }
    }
}
