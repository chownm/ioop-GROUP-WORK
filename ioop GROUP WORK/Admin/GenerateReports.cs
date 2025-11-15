using System;
using System.Collections.Generic;
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
    public partial class GenerateReports : Form
    {
        // use interface for polymorphism; adapter supplied by default
        private readonly IAdminManager adminMgr;

        // default constructor uses adapter that delegates to AdminManager.Instance
        public GenerateReports() : this(new AdminManagerAdapter())
        {
        }

        // DI constructor - allows swapping implementations without altering AdminManager
        public GenerateReports(IAdminManager adminMgr)
        {
            InitializeComponent();
            this.adminMgr = adminMgr;
        }

        private void GenerateReports_Load(object sender, EventArgs e)
        {
            try
            {
                LoadStatistics();
                LoadPendingApplications();
                LoadActivityLogs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadStatistics()
        {
            try
            {
                DataTable dtStats = adminMgr.GeneratePlacementStatistics();
                if (dtStats.Rows.Count > 0)
                {
                    DataRow row = dtStats.Rows[0];
                    lblTotalApps.Text = "Total Applications: " + row["TotalApplications"];
                    lblAccepted.Text = "Accepted: " + row["Accepted"];
                    lblRejected.Text = "Rejected: " + row["Rejected"];
                    lblPending.Text = "Pending: " + row["Pending"];
                    lblCompanies.Text = "Companies: " + row["CompaniesInvolved"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading statistics: " + ex.Message);
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
                DataTable dtLogs = adminMgr.GetActivityLogs();
                dgvActivityLogs.DataSource = dtLogs;
                dgvActivityLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadStatistics();
            LoadPendingApplications();
            LoadActivityLogs();
            MessageBox.Show("Reports refreshed successfully!");
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "CSV Files (*.csv)|*.csv";
                
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // polymorphic call into adapter (which can change behavior)
                    string result = adminMgr.ExportUsersToCSV(saveDialog.FileName);
                    MessageBox.Show(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
