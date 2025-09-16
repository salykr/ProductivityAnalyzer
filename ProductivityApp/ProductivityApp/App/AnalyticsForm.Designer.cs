using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProductivityApp.App
{
    partial class AnalyticsForm
    {
        private System.ComponentModel.IContainer components = null;

        // Header components
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label todayDateLabel;
        //private System.Windows.Forms.Button refreshButton;

        // Main content panel
        private System.Windows.Forms.Panel mainContentPanel;

        // KPI Card panels
        private System.Windows.Forms.Panel kpiCardsPanel;
        private System.Windows.Forms.Panel totalTasksCard;
        private System.Windows.Forms.Panel pendingTasksCard;
        private System.Windows.Forms.Panel completedTasksCard;
        private System.Windows.Forms.Panel completionRateCard;
        private System.Windows.Forms.Panel avgTimeCard;
        private System.Windows.Forms.Panel maxTimeCard;
        private System.Windows.Forms.Panel minTimeCard;

        // KPI Labels
        private System.Windows.Forms.Label totalTasksLabel;
        private System.Windows.Forms.Label totalTasksDescLabel;
        private System.Windows.Forms.Label pendingTasksLabel;
        private System.Windows.Forms.Label pendingTasksDescLabel;
        private System.Windows.Forms.Label completedTasksLabel;
        private System.Windows.Forms.Label completedTasksDescLabel;
        private System.Windows.Forms.Label completionRateLabel;
        private System.Windows.Forms.Label completionRateDescLabel;
        private System.Windows.Forms.Label avgTimeLabel;
        private System.Windows.Forms.Label avgTimeDescLabel;
        private System.Windows.Forms.Label maxTimeLabel;
        private System.Windows.Forms.Label maxTimeDescLabel;
        private System.Windows.Forms.Label minTimeLabel;
        private System.Windows.Forms.Label minTimeDescLabel;

        // Chart components
        private System.Windows.Forms.Panel chartPanel;
        private System.Windows.Forms.Label chartTitleLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart lineChart;

        // Color palette (same as Task Manager)
        private readonly Color DarkNavy = ColorTranslator.FromHtml("#19183B");
        private readonly Color SlateBlue = ColorTranslator.FromHtml("#708993");
        private readonly Color LightTeal = ColorTranslator.FromHtml("#A1C2BD");
        private readonly Color LightMint = ColorTranslator.FromHtml("#E7F2EF");

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            InitializeComponents();
            SetupLayout();
            SetupChart();
            SetupEventHandlers();
        }

        private void InitializeComponents()
        {
            // Initialize all components
            this.headerPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.todayDateLabel = new System.Windows.Forms.Label();
            //this.refreshButton = new System.Windows.Forms.Button();

            this.mainContentPanel = new System.Windows.Forms.Panel();
            this.kpiCardsPanel = new System.Windows.Forms.Panel();

            // KPI Cards
            this.totalTasksCard = new System.Windows.Forms.Panel();
            this.pendingTasksCard = new System.Windows.Forms.Panel();
            this.completedTasksCard = new System.Windows.Forms.Panel();
            this.completionRateCard = new System.Windows.Forms.Panel();
            this.avgTimeCard = new System.Windows.Forms.Panel();
            this.maxTimeCard = new System.Windows.Forms.Panel();
            this.minTimeCard = new System.Windows.Forms.Panel();

            // KPI Labels
            this.totalTasksLabel = new System.Windows.Forms.Label();
            this.totalTasksDescLabel = new System.Windows.Forms.Label();
            this.pendingTasksLabel = new System.Windows.Forms.Label();
            this.pendingTasksDescLabel = new System.Windows.Forms.Label();
            this.completedTasksLabel = new System.Windows.Forms.Label();
            this.completedTasksDescLabel = new System.Windows.Forms.Label();
            this.completionRateLabel = new System.Windows.Forms.Label();
            this.completionRateDescLabel = new System.Windows.Forms.Label();
            this.avgTimeLabel = new System.Windows.Forms.Label();
            this.avgTimeDescLabel = new System.Windows.Forms.Label();
            this.maxTimeLabel = new System.Windows.Forms.Label();
            this.maxTimeDescLabel = new System.Windows.Forms.Label();
            this.minTimeLabel = new System.Windows.Forms.Label();
            this.minTimeDescLabel = new System.Windows.Forms.Label();

            // Chart components
            this.chartPanel = new System.Windows.Forms.Panel();
            this.chartTitleLabel = new System.Windows.Forms.Label();
            this.lineChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
        }

        private void SetupLayout()
        {
            this.SuspendLayout();

            // Main Form - Increase width for better spacing
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = LightMint;
            this.ClientSize = new System.Drawing.Size(1300, 900);  // Increase form size for more space
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AnalyticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analytics Dashboard";
            this.Load += new System.EventHandler(this.AnalyticsForm_Load);

            // Header Panel
            this.headerPanel.BackColor = DarkNavy;
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Height = 80;
            this.headerPanel.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);

            // Title Label
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = LightMint;
            this.titleLabel.Location = new System.Drawing.Point(20, 20);
            this.titleLabel.Text = "Analytics Dashboard";

            // Today Date Label
            this.todayDateLabel.AutoSize = true;
            this.todayDateLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.todayDateLabel.ForeColor = LightTeal;
            this.todayDateLabel.Location = new System.Drawing.Point(20, 50);
            this.todayDateLabel.Text = DateTime.Today.ToString("MMMM dd, yyyy");

            // Main Content Panel
            this.mainContentPanel.BackColor = LightMint;
            this.mainContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContentPanel.Padding = new System.Windows.Forms.Padding(20);

            // KPI Cards Panel
            this.kpiCardsPanel.BackColor = Color.Transparent;
            this.kpiCardsPanel.Location = new System.Drawing.Point(20, 20);
            this.kpiCardsPanel.Size = new System.Drawing.Size(1250, 250);  //KPI cards

            // Setup KPI Cards
            SetupKpiCards();

            // Chart Panel
            this.chartPanel.BackColor = Color.White;
            this.chartPanel.Location = new System.Drawing.Point(20, 280);  // Adjust the position after card resizing
            this.chartPanel.Size = new System.Drawing.Size(1240, 460);  // chart panel
            this.chartPanel.Paint += Panel_Paint;

            // Chart Title
            this.chartTitleLabel.AutoSize = true;
            this.chartTitleLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.chartTitleLabel.ForeColor = DarkNavy;
            this.chartTitleLabel.Location = new System.Drawing.Point(20, 20);
            this.chartTitleLabel.Text = "Task Completion Throughout the Day";

            // Add controls to their containers
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Controls.Add(this.todayDateLabel);

            this.mainContentPanel.Controls.Add(this.kpiCardsPanel);
            this.mainContentPanel.Controls.Add(this.chartPanel);

            this.chartPanel.Controls.Add(this.chartTitleLabel);
            this.chartPanel.Controls.Add(this.lineChart);

            this.Controls.Add(this.mainContentPanel);
            this.Controls.Add(this.headerPanel);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void SetupKpiCards()
        {
            var cards = new[]
            {
        new { Card = totalTasksCard, ValueLabel = totalTasksLabel, DescLabel = totalTasksDescLabel, Title = "Total Tasks", Icon = "📋", Color = LightTeal },
        new { Card = completedTasksCard, ValueLabel = completedTasksLabel, DescLabel = completedTasksDescLabel, Title = "Completed", Icon = "✅", Color = ColorTranslator.FromHtml("#2ECC71") },
        new { Card = pendingTasksCard, ValueLabel = pendingTasksLabel, DescLabel = pendingTasksDescLabel, Title = "Pending", Icon = "⏳", Color = ColorTranslator.FromHtml("#F39C12") },
        new { Card = completionRateCard, ValueLabel = completionRateLabel, DescLabel = completionRateDescLabel, Title = "Completion Rate", Icon = "📊", Color = SlateBlue },
        new { Card = avgTimeCard, ValueLabel = avgTimeLabel, DescLabel = avgTimeDescLabel, Title = "Avg Time", Icon = "⏱️", Color = ColorTranslator.FromHtml("#9B59B6") },
        new { Card = maxTimeCard, ValueLabel = maxTimeLabel, DescLabel = maxTimeDescLabel, Title = "Max Time", Icon = "⬆️", Color = ColorTranslator.FromHtml("#E74C3C") },
        new { Card = minTimeCard, ValueLabel = minTimeLabel, DescLabel = minTimeDescLabel, Title = "Min Time", Icon = "⬇️", Color = ColorTranslator.FromHtml("#1ABC9C") }
    };

            // Each card should occupy 1/7th of the available width, minus padding
            int cardWidth = 160;  // Slightly smaller width per card
            for (int i = 0; i < cards.Length; i++)
            {
                var card = cards[i];

                // Card setup
                card.Card.BackColor = Color.White;
                card.Card.Size = new System.Drawing.Size(cardWidth, 160);
                card.Card.Location = new Point(i * (cardWidth + 20), 20);  // Adjust location based on card width

                // Icon label (using the description label for icon)
                card.DescLabel.Text = card.Icon;
                card.DescLabel.Font = new System.Drawing.Font("Segoe UI", 18F);  // Adjusted icon font size
                card.DescLabel.ForeColor = card.Color;
                card.DescLabel.Location = new System.Drawing.Point(15, 15);
                card.DescLabel.Size = new System.Drawing.Size(50, 40);
                card.DescLabel.TextAlign = ContentAlignment.MiddleCenter;

                // Value label
                card.ValueLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);  
                card.ValueLabel.ForeColor = DarkNavy;
                card.ValueLabel.Location = new System.Drawing.Point(15, 55);
                card.ValueLabel.Size = new System.Drawing.Size(cardWidth - 30, 25); 
                card.ValueLabel.Text = "0";
                card.ValueLabel.TextAlign = ContentAlignment.MiddleCenter;

                // Title label 
                var titleLabel = new Label
                {
                    Text = card.Title,
                    Font = new System.Drawing.Font("Segoe UI", 9F),  
                    ForeColor = SlateBlue,
                    Location = new System.Drawing.Point(15, 85),
                    Size = new System.Drawing.Size(cardWidth - 30, 20),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                card.Card.Controls.Add(card.DescLabel);
                card.Card.Controls.Add(card.ValueLabel);
                card.Card.Controls.Add(titleLabel);

                this.kpiCardsPanel.Controls.Add(card.Card);
            }
        }
        private void SetupChart()
        {
            ((System.ComponentModel.ISupportInitialize)(this.lineChart)).BeginInit();

            // Chart configuration
            this.lineChart.BackColor = Color.White;
            this.lineChart.Location = new System.Drawing.Point(20, 60);
            this.lineChart.Size = new System.Drawing.Size(1250, 380);  // Same width as kpiCardsPanel
            this.lineChart.BorderSkin.SkinStyle = BorderSkinStyle.None;

            // Create and configure ChartArea
            ChartArea chartArea = new ChartArea();
            chartArea.Name = "MainArea";
            chartArea.BackColor = Color.White;
            chartArea.BorderColor = Color.Transparent;

            // X-Axis configuration for numeric hour values
            chartArea.AxisX.MajorGrid.LineColor = ColorTranslator.FromHtml("#E0E0E0");
            chartArea.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            chartArea.AxisX.LineColor = SlateBlue;
            chartArea.AxisX.LabelStyle.ForeColor = DarkNavy;
            chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 10F);
            chartArea.AxisX.Title = "Hour of the Day";
            chartArea.AxisX.TitleFont = new Font("Segoe UI", 11F, FontStyle.Bold);
            chartArea.AxisX.TitleForeColor = DarkNavy;
            chartArea.AxisX.Interval = 1;  // Interval set to 1 hour
            chartArea.AxisX.IsLabelAutoFit = true;  // Ensure the labels fit automatically

            // Setting the x-axis to show time from 8 to 14 hours (8 AM to 2 PM)
            chartArea.AxisX.Minimum = 0;  // Starting from 8 AM (Hour 8)
            //chartArea.AxisX.Maximum = 23; // Maximum time of 2 PM (Hour 14)

            // Y-Axis configuration
            chartArea.AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#E0E0E0");
            chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            chartArea.AxisY.LineColor = SlateBlue;
            chartArea.AxisY.LabelStyle.ForeColor = DarkNavy;
            chartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 10F);
            chartArea.AxisY.Title = "Tasks Completed";
            chartArea.AxisY.TitleFont = new Font("Segoe UI", 11F, FontStyle.Bold);
            chartArea.AxisY.TitleForeColor = DarkNavy;
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = 5;  // Adjust based on task count
            chartArea.AxisY.Interval = 1;

            this.lineChart.ChartAreas.Add(chartArea);

            // Create series
            var series = new Series();
            series.Name = "Completed Tasks";
            series.ChartType = SeriesChartType.Line;
            series.Color = LightTeal;
            series.BorderWidth = 4;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 8;
            series.MarkerColor = DarkNavy;
            series.MarkerBorderColor = Color.White;
            series.MarkerBorderWidth = 2;
            series.IsValueShownAsLabel = true;
            series.LabelForeColor = DarkNavy;
            series.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            this.lineChart.Series.Add(series);

            // Chart styling
            this.lineChart.BackColor = Color.White;
            this.lineChart.BackSecondaryColor = Color.Transparent;
            this.lineChart.BorderlineColor = Color.Transparent;

            ((System.ComponentModel.ISupportInitialize)(this.lineChart)).EndInit();
        }

        private void SetupChar1t()
        {
            ((System.ComponentModel.ISupportInitialize)(this.lineChart)).BeginInit();

            // Chart configuration
            this.lineChart.BackColor = Color.White;
            this.lineChart.Location = new System.Drawing.Point(20, 60);
            this.lineChart.Size = new System.Drawing.Size(1000, 380);
            this.lineChart.BorderSkin.SkinStyle = BorderSkinStyle.None;

            // Create and configure ChartArea
            ChartArea chartArea = new ChartArea();
            chartArea.Name = "MainArea";
            chartArea.BackColor = Color.White;
            chartArea.BorderColor = Color.Transparent;

            // X-Axis configuration
            chartArea.AxisX.MajorGrid.LineColor = ColorTranslator.FromHtml("#E0E0E0");
            chartArea.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            chartArea.AxisX.LineColor = SlateBlue;
            chartArea.AxisX.LabelStyle.ForeColor = DarkNavy;
            chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 10F);
            chartArea.AxisX.Title = "Time of Day";
            chartArea.AxisX.TitleFont = new Font("Segoe UI", 11F, FontStyle.Bold);
            chartArea.AxisX.TitleForeColor = DarkNavy;
            chartArea.AxisX.Interval = 1;
            //chartArea.AxisX.Minimum = 00;
            //chartArea.AxisX.Maximum = 23;

            // Y-Axis configuration
            chartArea.AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#E0E0E0");
            chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            chartArea.AxisY.LineColor = SlateBlue;
            chartArea.AxisY.LabelStyle.ForeColor = DarkNavy;
            chartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 10F);
            chartArea.AxisY.Title = "Tasks Completed";
            chartArea.AxisY.TitleFont = new Font("Segoe UI", 11F, FontStyle.Bold);
            chartArea.AxisY.TitleForeColor = DarkNavy;
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Interval = 1;

            this.lineChart.ChartAreas.Add(chartArea);

            // Create series
            var series = new Series();
            series.Name = "Completed Tasks";
            series.ChartType = SeriesChartType.Line;
            series.Color = LightTeal;
            series.BorderWidth = 4;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 8;
            series.MarkerColor = DarkNavy;
            series.MarkerBorderColor = Color.White;
            series.MarkerBorderWidth = 2;
            series.IsValueShownAsLabel = true;
            series.LabelForeColor = DarkNavy;
            series.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            //series.LabelFont = new Font("Segoe UI", 9F, FontStyle.Bold);

            this.lineChart.Series.Add(series);

            // Chart styling
            this.lineChart.BackColor = Color.White;
            this.lineChart.BackSecondaryColor = Color.Transparent;
            this.lineChart.BorderlineColor = Color.Transparent;

            ((System.ComponentModel.ISupportInitialize)(this.lineChart)).EndInit();
        }

        private void SetupEventHandlers()
        {
            //this.refreshButton.Click += (s, e) => {
            //    this.refreshButton.Text = "🔄 Refreshing...";
            //    this.refreshButton.Enabled = false;

            //    try
            //    {
            //        LoadAnalytics();
            //    }
            //    finally
            //    {
            //        this.refreshButton.Text = "🔄 Refresh";
            //        this.refreshButton.Enabled = true;
            //    }
            //};

            // Add hover effects to cards
            AddCardHoverEffects();
        }

        private void AddCardHoverEffects()
        {
            var cards = new[] { totalTasksCard, pendingTasksCard, completedTasksCard,
                              completionRateCard, avgTimeCard, maxTimeCard, minTimeCard };

            foreach (var card in cards)
            {
                card.MouseEnter += (s, e) => {
                    card.BackColor = ColorTranslator.FromHtml("#F8F9FA");
                };

                card.MouseLeave += (s, e) => {
                    card.BackColor = Color.White;
                };
            }
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            var panel = sender as Panel;
            using (var pen = new Pen(ColorTranslator.FromHtml("#E0E0E0"), 1))
            {
                var rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        private void AnalyticsForm_Load(object sender, EventArgs e)
        {
            LoadAnalytics();
        }

        #endregion
    }
}