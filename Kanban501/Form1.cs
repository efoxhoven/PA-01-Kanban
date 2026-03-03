using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Kanban501.Form1;

namespace Kanban501
{
    public partial class Form1 : Form
    {
        public delegate void InputHandler(string title, string resources, string status, DateTime dueDate, int priority);
        private InputHandler inputHandler;

        public delegate void DeleteHandler(Task task);
        private DeleteHandler deleteHandler;

        public delegate void EditHandler(Task task, string title, string resources, string status, DateTime dueDate, int priority);
        private EditHandler editHandler;

        public delegate void CloseHandler();
        private CloseHandler closeHandler;

        //Registering handlers for the three main actions of the program: add, delete, and edit.
        public void RegisterAdd(InputHandler handler)
        {
            inputHandler += handler;
        }
        public void RegisterDelete(DeleteHandler handler)
        {
            deleteHandler += handler;
        }
        public void RegisterEdit(EditHandler handler)
        {
            editHandler += handler;
        }
        public void RegisterClose(CloseHandler handler)
        {
                closeHandler += handler;
        }

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeHandler?.Invoke();
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


        public void RefreshDisplay(List<Task> tasks)
        {
            toDoBox.Items.Clear();
            workingOnBox.Items.Clear();
            doneBox.Items.Clear();

            foreach(Task t in tasks)
            {
                if (t.Status == "To Do")
                {
                    toDoBox.Items.Add(t);
                }
                else if (t.Status == "Working On")
                {
                    workingOnBox.Items.Add(t);
                }
                else if (t.Status == "Done")
                {
                    doneBox.Items.Add(t);
                }
            }
            if (toDoBox.Items.Count >= 15 || workingOnBox.Items.Count >= 3)
            {
                newButton.Enabled = false; // Disable add button if limits are reached
            }
            else { newButton.Enabled = true; }
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
                    inputHandler?.Invoke(form.TaskName, form.TaskResources, form.TaskStatus, form.TaskDueDate, form.TaskPriority);
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
                    editHandler?.Invoke(selected, form.TaskName, form.TaskResources, form.TaskStatus, form.TaskDueDate, form.TaskPriority);
                    
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
                deleteHandler?.Invoke(selected);
            }
            else if (workingOnBox.SelectedItem != null)
            {
                selected = (Task)workingOnBox.SelectedItem;
                deleteHandler?.Invoke(selected);
                workingOnBox.SelectedItem = null;
            }
            else if (doneBox.SelectedItem != null)
            {
                selected = (Task)doneBox.SelectedItem;
                deleteHandler?.Invoke(selected);
                doneBox.SelectedItem = null;
            }
            
        }
    }
}
