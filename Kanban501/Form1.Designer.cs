namespace Kanban501
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toDoBox = new System.Windows.Forms.ListBox();
            this.myKanbanText = new System.Windows.Forms.TextBox();
            this.workingOnBox = new System.Windows.Forms.ListBox();
            this.doneBox = new System.Windows.Forms.ListBox();
            this.workingOnText = new System.Windows.Forms.TextBox();
            this.toDoText = new System.Windows.Forms.TextBox();
            this.doneText = new System.Windows.Forms.TextBox();
            this.newButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // toDoBox
            // 
            this.toDoBox.FormattingEnabled = true;
            this.toDoBox.Location = new System.Drawing.Point(43, 100);
            this.toDoBox.Name = "toDoBox";
            this.toDoBox.Size = new System.Drawing.Size(173, 173);
            this.toDoBox.TabIndex = 0;
            // 
            // myKanbanText
            // 
            this.myKanbanText.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.myKanbanText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.myKanbanText.Enabled = false;
            this.myKanbanText.HideSelection = false;
            this.myKanbanText.Location = new System.Drawing.Point(334, 32);
            this.myKanbanText.Name = "myKanbanText";
            this.myKanbanText.Size = new System.Drawing.Size(100, 13);
            this.myKanbanText.TabIndex = 1;
            this.myKanbanText.Text = "My Kanaban";
            this.myKanbanText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.myKanbanText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // workingOnBox
            // 
            this.workingOnBox.FormattingEnabled = true;
            this.workingOnBox.Location = new System.Drawing.Point(299, 100);
            this.workingOnBox.Name = "workingOnBox";
            this.workingOnBox.Size = new System.Drawing.Size(173, 173);
            this.workingOnBox.TabIndex = 2;
            // 
            // doneBox
            // 
            this.doneBox.FormattingEnabled = true;
            this.doneBox.Location = new System.Drawing.Point(586, 100);
            this.doneBox.Name = "doneBox";
            this.doneBox.Size = new System.Drawing.Size(173, 173);
            this.doneBox.TabIndex = 3;
            // 
            // workingOnText
            // 
            this.workingOnText.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.workingOnText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.workingOnText.Enabled = false;
            this.workingOnText.HideSelection = false;
            this.workingOnText.Location = new System.Drawing.Point(334, 81);
            this.workingOnText.Name = "workingOnText";
            this.workingOnText.Size = new System.Drawing.Size(100, 13);
            this.workingOnText.TabIndex = 4;
            this.workingOnText.Text = "Working On";
            this.workingOnText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.workingOnText.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // toDoText
            // 
            this.toDoText.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toDoText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toDoText.Enabled = false;
            this.toDoText.HideSelection = false;
            this.toDoText.Location = new System.Drawing.Point(72, 81);
            this.toDoText.Name = "toDoText";
            this.toDoText.Size = new System.Drawing.Size(100, 13);
            this.toDoText.TabIndex = 5;
            this.toDoText.Text = "To Do";
            this.toDoText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // doneText
            // 
            this.doneText.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.doneText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.doneText.Enabled = false;
            this.doneText.HideSelection = false;
            this.doneText.Location = new System.Drawing.Point(625, 81);
            this.doneText.Name = "doneText";
            this.doneText.Size = new System.Drawing.Size(100, 13);
            this.doneText.TabIndex = 6;
            this.doneText.Text = "Done";
            this.doneText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.doneText.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(43, 364);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(118, 49);
            this.newButton.TabIndex = 7;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(204, 364);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(118, 49);
            this.editButton.TabIndex = 8;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(641, 364);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(118, 49);
            this.deleteButton.TabIndex = 9;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.doneText);
            this.Controls.Add(this.toDoText);
            this.Controls.Add(this.workingOnText);
            this.Controls.Add(this.doneBox);
            this.Controls.Add(this.workingOnBox);
            this.Controls.Add(this.myKanbanText);
            this.Controls.Add(this.toDoBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox myKanbanText;
        private System.Windows.Forms.ListBox toDoBox;
        private System.Windows.Forms.ListBox workingOnBox;
        private System.Windows.Forms.ListBox doneBox;
        private System.Windows.Forms.TextBox workingOnText;
        private System.Windows.Forms.TextBox toDoText;
        private System.Windows.Forms.TextBox doneText;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
    }
}

