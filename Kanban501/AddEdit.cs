using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kanban501
{
    public partial class AddEdit : Form
    {
        private Task currentTask;

        // Expose updated values for Controller
        public string TaskName => activityBox.Text;
        public string TaskResources => resourcesBox.Text;
        public string TaskStatus => statusSelection.SelectedItem?.ToString();
        public DateTime TaskDueDate => dueDateBox.Value;
        public int TaskPriority => int.TryParse(priorityBox.Text, out int p) ? p : 0;

        // Constructor for Add
        public AddEdit()
        {
            InitializeComponent();
        }

        // Constructor for Edit
        public AddEdit(Task task) : this()
        {
            currentTask = task;
            if (task != null)
            {
                activityBox.Text = task.Name;
                resourcesBox.Text = task.Resources;
                statusSelection.SelectedItem = task.Status;
                dueDateBox.Value = task.DueDate;
                priorityBox.Text = task.Priority.ToString();
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(activityBox.Text))
            {
                MessageBox.Show("Activity name is required");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void AddEdit_Load(object sender, EventArgs e)
        {

        }

    }
}
    
