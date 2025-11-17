using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ioop_GROUP_WORK.Admin;

namespace ioop_GROUP_WORK.Admin
{
    // Calculate the Table Values and Give in Calculations. Calculate Totals, Averages, Maximums, Minimums of Relevant Aggregate Columns
    public partial class ViewStatistics : Form
    {
        private AdminManager adminMgr = AdminManager.Instance;
        private ComboBox cmbTables;
        private DataGridView dgvData;
        private Label lblStatsDisplay;
        private Timer rotationTimer;
        private DataTable currentStats;
        private int currentRowIndex = 0;

        public ViewStatistics()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            // ComboBox for table selection
            cmbTables = new ComboBox();
            cmbTables.Name = "cmbTables";
            cmbTables.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTables.Location = new System.Drawing.Point(10, 10);
            cmbTables.Size = new System.Drawing.Size(200, 25);
            cmbTables.Font = new Font("Arial", 10);
            cmbTables.BackColor = Color.White;
            this.Controls.Add(cmbTables);

            // Calculate Button - Blue
            Button btnCalculate = new Button();
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Text = "Calculate";
            btnCalculate.Location = new System.Drawing.Point(220, 10);
            btnCalculate.Size = new System.Drawing.Size(100, 25);
            btnCalculate.BackColor = Color.CornflowerBlue;
            btnCalculate.ForeColor = Color.White;
            btnCalculate.Font = new Font("Arial", 10, FontStyle.Bold);
            btnCalculate.FlatStyle = FlatStyle.Flat;
            btnCalculate.Click += btnCalculate_Click;
            this.Controls.Add(btnCalculate);

            // Close Button - Gray
            Button btnClose = new Button();
            btnClose.Name = "btnClose";
            btnClose.Text = "Close";
            btnClose.Location = new System.Drawing.Point(330, 10);
            btnClose.Size = new System.Drawing.Size(100, 25);
            btnClose.BackColor = Color.DimGray;
            btnClose.ForeColor = Color.White;
            btnClose.Font = new Font("Arial", 10, FontStyle.Bold);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Click += btnClose_Click;
            this.Controls.Add(btnClose);

            // Rotating Statistics Display Label - Aesthetic
            lblStatsDisplay = new Label();
            lblStatsDisplay.Name = "lblStatsDisplay";
            lblStatsDisplay.Location = new System.Drawing.Point(10, 50);
            lblStatsDisplay.Size = new System.Drawing.Size(750, 100);
            lblStatsDisplay.BackColor = Color.AliceBlue;
            lblStatsDisplay.BorderStyle = BorderStyle.FixedSingle;
            lblStatsDisplay.Font = new Font("Arial", 14, FontStyle.Bold);
            lblStatsDisplay.Padding = new Padding(15);
            lblStatsDisplay.Text = "Select a table and click Calculate to view statistics";
            lblStatsDisplay.TextAlign = ContentAlignment.MiddleCenter;
            lblStatsDisplay.ForeColor = Color.Navy;
            this.Controls.Add(lblStatsDisplay);

            // DataGridView for full statistics
            dgvData = new DataGridView();
            dgvData.Name = "dgvData";
            dgvData.Location = new System.Drawing.Point(10, 160);
            dgvData.Size = new System.Drawing.Size(750, 280);
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvData.BackgroundColor = Color.White;
            dgvData.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvData.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(dgvData);

            // Timer for rotating display (4 seconds)
            rotationTimer = new Timer();
            rotationTimer.Interval = 4000; // 4 seconds
            rotationTimer.Tick += RotationTimer_Tick;
        }

        private void ViewStatistics_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "View Statistics - Admin";
                this.ClientSize = new System.Drawing.Size(770, 460);
                this.StartPosition = FormStartPosition.CenterScreen;
                LoadTableNames();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadTableNames()
        {
            try
            {
                DataTable dtTables = adminMgr.GetAllTables();
                cmbTables.Items.Clear();
                for (int i = 0; i < dtTables.Rows.Count; i++)
                {
                    string tableName = dtTables.Rows[i][0].ToString();
                    cmbTables.Items.Add(tableName);
                }
                if (cmbTables.Items.Count > 0)
                    cmbTables.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tables: " + ex.Message);
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTables.SelectedItem == null)
                {
                    MessageBox.Show("Please select a table.");
                    return;
                }

                string selectedTable = cmbTables.SelectedItem.ToString();
                currentStats = adminMgr.CalculateAggregateStatistics(selectedTable);

                if (currentStats == null || currentStats.Rows.Count == 0)
                {
                    MessageBox.Show($"No data in table '{selectedTable}'");
                    return;
                }

                // Display full statistics in grid
                dgvData.DataSource = currentStats;

                // Start rotation timer
                currentRowIndex = 0;
                rotationTimer.Stop();
                rotationTimer.Start();

                // Display first statistic
                DisplayCurrentStatistic();

                MessageBox.Show($"✓ Statistics calculated for '{selectedTable}'\n\nStatistics rotate every 4 seconds", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void RotationTimer_Tick(object sender, EventArgs e)
        {
            if (currentStats == null || currentStats.Rows.Count == 0)
            {
                rotationTimer.Stop();
                return;
            }

            currentRowIndex++;
            if (currentRowIndex >= currentStats.Rows.Count)
            {
                currentRowIndex = 0;
            }

            DisplayCurrentStatistic();
        }

        private void DisplayCurrentStatistic()
        {
            if (currentStats == null || currentRowIndex >= currentStats.Rows.Count)
                return;

            string metric = currentStats.Rows[currentRowIndex][0].ToString();
            string value = currentStats.Rows[currentRowIndex][1].ToString();

            if (string.IsNullOrWhiteSpace(metric))
            {
                currentRowIndex++;
                if (currentRowIndex >= currentStats.Rows.Count)
                    currentRowIndex = 0;
                DisplayCurrentStatistic();
                return;
            }

            lblStatsDisplay.Text = $"{metric}\n\n{value}";
            lblStatsDisplay.ForeColor = GetColorForMetric(metric);
        }

        private Color GetColorForMetric(string metric)
        {
            metric = metric.ToLower();
            if (metric.Contains("total")) return Color.DarkBlue;
            if (metric.Contains("average")) return Color.DarkGreen;
            if (metric.Contains("maximum")) return Color.DarkRed;
            if (metric.Contains("minimum")) return Color.DarkOrange;
            return Color.Navy;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            rotationTimer.Stop();
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                if (rotationTimer != null)
                {
                    rotationTimer.Stop();
                    rotationTimer.Dispose();
                    rotationTimer = null;
                }
            }
            catch { }
            finally
            {
                base.OnFormClosing(e);
            }
        }
    }
}

