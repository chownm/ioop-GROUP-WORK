using ioop_GROUP_WORK.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.Admin
{
    public partial class GenerateReports : Form
    {
        private AdminManager adminMgr = AdminManager.Instance;

        public GenerateReports()
        {
            InitializeComponent();
        }

        private void GenerateReports_Load(object sender, EventArgs e)
        {
            try
            {
                // Don't test connection here - it causes issues
                LoadStatistics();
                LoadPendingApplications();
                LoadActivityLogs();
                cbActivityStatus.SelectedIndex = 0; 
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Database Connection Error: " + sqlEx.Number + " - " + sqlEx.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ConfigurationErrorsException configEx)
            {
                MessageBox.Show("Configuration Error: " + configEx.Message, "Config Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPendingApplications()
        {
            try
            {
                DataTable dtPending = adminMgr.GetPendingApplications();
                dgvPendingApps.DataSource = dtPending;
                dgvPendingApps.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadActivityLogs()
        {
            try
            {
                string selectedStatus = cbActivityStatus.SelectedItem?.ToString() ?? "All";
                DataTable dtLogs = adminMgr.GetActivityLogs(selectedStatus);
                dgvActivityLogs.DataSource = dtLogs;
                dgvActivityLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading activity logs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CbActivityStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadActivityLogs();
        }


        private void LoadStatistics()
        {
            try
            {
                DataTable dtTables = adminMgr.GetAllTables();
                if (dtTables.Rows.Count == 0)
                {
                    MessageBox.Show("No tables found in database.");
                    return;
                }

                string tableList = "";
                for (int i = 0; i < dtTables.Rows.Count; i++)
                    tableList += dtTables.Rows[i][0].ToString() + "\n";

                string selectedTable = PromptForInput("Calculate statistics for:\n" + tableList, "Statistics", "StudentApplication");

                if (string.IsNullOrWhiteSpace(selectedTable))
                {
                    MessageBox.Show("Statistics cancelled.");
                    return;
                }

                // Get aggregate statistics for selected table
                DataTable dtStats = adminMgr.CalculateAggregateStatistics(selectedTable);

                if (dtStats == null || dtStats.Rows.Count == 0)
                {
                    MessageBox.Show($"No statistics available for '{selectedTable}'");
                    return;
                }

                // Clear existing labels
                lblTotalApps.Text = "";
                lblAccepted.Text = "";
                lblRejected.Text = "";
                lblPending.Text = "";
                lblCompanies.Text = "";

                // Dynamically display statistics in available labels
                int labelIndex = 0;
                Label[] labels = { lblTotalApps, lblAccepted, lblRejected, lblPending, lblCompanies };

                for (int i = 0; i < dtStats.Rows.Count && labelIndex < labels.Length; i++)
                {
                    string metric = dtStats.Rows[i][0].ToString();
                    string value = dtStats.Rows[i][1].ToString();

                    if (!string.IsNullOrWhiteSpace(metric) && !string.IsNullOrWhiteSpace(value))
                    {
                        labels[labelIndex].Text = $"{metric}: {value}";
                        labelIndex++;
                    }
                }

                // Show full statistics in messagebox
                string statsMsg = $"✓ Statistics calculated for '{selectedTable}'\n\n";
                for (int i = 0; i < dtStats.Rows.Count; i++)
                {
                    string metric = dtStats.Rows[i][0].ToString();
                    string value = dtStats.Rows[i][1].ToString();
                    if (!string.IsNullOrWhiteSpace(metric))
                        statsMsg += $"{metric}: {value}\n";
                }
                MessageBox.Show(statsMsg, "Table Statistics");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading statistics: " + ex.Message);
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                DataTable dtTables = adminMgr.GetAllTables();
                if (dtTables == null || dtTables.Rows.Count == 0)
                {
                    MessageBox.Show("No tables found in database.");
                    return;
                }

                string tableList = "";
                for (int i = 0; i < dtTables.Rows.Count; i++)
                    tableList += dtTables.Rows[i][0].ToString() + "\n";

                string tableName = PromptForInput("Select table to export:\n" + tableList, "Export Table", "StudentApplication");

                if (string.IsNullOrWhiteSpace(tableName))
                {
                    MessageBox.Show("Export cancelled.");
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = tableName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string result = adminMgr.ExportToCSVExcludingSensitive(tableName, sfd.FileName);
                    MessageBox.Show(result, "Export");

                    if (MessageBox.Show("Open export folder?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("explorer.exe", "/select, " + sfd.FileName);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("SQL Error: " + sqlEx.Number + " - " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Export Error");
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    con.Dispose();
                }
            }
        }


        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadStatistics();
            LoadPendingApplications();
            LoadActivityLogs();
            MessageBox.Show("Reports refreshed successfully!");
        }

    

        private string PromptForInput(string prompt, string title, string Value)
        {
            Form promptForm = new Form()
            {
                Text = title,
                Width = 400,
                Height = 250,
                StartPosition = FormStartPosition.CenterParent
            };

            Label label = new Label() { Left = 20, Top = 20, Text = prompt, Width = 350, Height = 80, AutoSize = false };
            TextBox textBox = new TextBox() { Left = 20, Top = 110, Width = 350, Text = Value };
            Button okButton = new Button() { Text = "OK", Left = 200, Width = 80, Top = 150, DialogResult = DialogResult.OK };
            Button cancelButton = new Button() { Text = "Cancel", Left = 290, Width = 80, Top = 150, DialogResult = DialogResult.Cancel };

            promptForm.Controls.Add(label);
            promptForm.Controls.Add(textBox);
            promptForm.Controls.Add(okButton);
            promptForm.Controls.Add(cancelButton);
            promptForm.AcceptButton = okButton;
            promptForm.CancelButton = cancelButton;

            return promptForm.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        private void btn_Tables_Select_Click(object sender, EventArgs e)
        {
            DataTable dtTables = adminMgr.GetAllTables();
            string tableList = "";
            for (int i = 0; i < dtTables.Rows.Count; i++)
                tableList += dtTables.Rows[i][0].ToString() + "\n";

            string tableName = PromptForInput("Select table to export:\n" + tableList, "Export Table", "");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
