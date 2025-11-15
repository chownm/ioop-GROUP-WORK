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
    public partial class ViewStatistics : Form
    {
        // depend on interface to allow polymorphic behavior
        private readonly IAdminManager adminMgr;

        // default uses adapter delegating to existing AdminManager singleton
        public ViewStatistics() : this(new AdminManagerAdapter())
        {
        }

        // DI constructor
        public ViewStatistics(IAdminManager adminMgr)
        {
            InitializeComponent();
            this.adminMgr = adminMgr;
        }

        private void ViewStatistics_Load(object sender, EventArgs e)
        {
            try
            {
                LoadStatistics();
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
                dgvStatistics.DataSource = dtStats;
                dgvStatistics.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (dtStats.Rows.Count > 0)
                {
                    DataRow row = dtStats.Rows[0];
                    lblTotalApps.Text = "Total Applications: " + row["TotalApplications"];
                    lblAccepted.Text = "Accepted: " + row["Accepted"];
                    lblRejected.Text = "Rejected: " + row["Rejected"];
                    lblPending.Text = "Pending: " + row["Pending"];
                    lblInternships.Text = "Internships: " + row["TotalInternships"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading statistics: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStatistics();
            MessageBox.Show("Statistics refreshed!");
        }

        public class AdminManagerAdapter : IAdminManager
        {
            public DataTable GeneratePlacementStatistics()
            {
                return AdminManager.Instance.GeneratePlacementStatistics();
            }

            public DataTable GetPendingApplications()
            {
                return AdminManager.Instance.GetPendingApplications();
            }

            public DataTable GetActivityLogs()
            {
                return AdminManager.Instance.GetActivityLogs();
            }

            public string ExportUsersToCSV(string filePath)
            {
                return AdminManager.Instance.ExportUsersToCSV(filePath);
            }
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "CSV Files (*.csv)|*.csv";
                
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // polymorphic call
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
