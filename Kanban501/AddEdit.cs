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

        public Task currentTask { get; set; }

        public AddEdit()
        {
            InitializeComponent();
        }

        public AddEdit(Task task)
        {
            InitializeComponent();
            currentTask = task;
            activityBox.Text = task.Name;
            resourcesBox.Text = task.Resources;
            dueDateBox.Value = task.DueDate;
            statusSelection.SelectedItem = task.Status;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void AddEdit_Load(object sender, EventArgs e)
        {

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(activityBox.Text)) {
                MessageBox.Show("You must enter an activity name.");
                return;
            }

            if (currentTask == null) //create new task if adding.
            {
                currentTask = new Task(
                    activityBox.Text,
                    resourcesBox.Text,
                    statusSelection.SelectedItem.ToString(),
                    dueDateBox.Value
                );
            }
            else
            {
                currentTask.Name = activityBox.Text;
                currentTask.Resources = resourcesBox.Text;
                currentTask.Status = statusSelection.SelectedItem.ToString();
                currentTask.DueDate = dueDateBox.Value;
            }

            DialogResult = DialogResult.OK;
            //MessageBox.Show(currentTask.Status.ToString());
            Close();
        }
    }
}
