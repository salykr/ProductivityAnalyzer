namespace ProductivityApp.App
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView taskLogsDataGridView;

        private void InitializeComponent()
        {
            this.taskLogsDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.taskLogsDataGridView)).BeginInit();
            this.SuspendLayout();

            // taskLogsDataGridView
            this.taskLogsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.taskLogsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Task Name", Width = 150 },
            new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Start Time", Width = 150 },
            new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Finish Time", Width = 150 },
            new System.Windows.Forms.DataGridViewTextBoxColumn { HeaderText = "Duration", Width = 100 }
            });
            this.taskLogsDataGridView.Location = new System.Drawing.Point(12, 12);
            this.taskLogsDataGridView.Name = "taskLogsDataGridView";
            this.taskLogsDataGridView.Size = new System.Drawing.Size(760, 400);
            this.taskLogsDataGridView.TabIndex = 0;

            // Form2
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.taskLogsDataGridView);
            this.Name = "Form2";
            this.Text = "Task Logs";
            ((System.ComponentModel.ISupportInitialize)(this.taskLogsDataGridView)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
