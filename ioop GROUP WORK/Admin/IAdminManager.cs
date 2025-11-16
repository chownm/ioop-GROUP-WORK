using System;
using System.Data;
using System.IO;
using System.Linq;
using ioop_GROUP_WORK.Admin;
using ioop_GROUP_WORK.Login;

namespace ioop_GROUP_WORK.Admin
{
    // Adapter interface for polymorphism without modifying AdminManager
    public interface IAdminManager
    {
        DataTable GeneratePlacementStatistics();
        DataTable GetPendingApplications();
        DataTable GetActivityLogs();
        string ExportUsersToCSV(string filePath);
    }

    // Adapter that delegates to the existing AdminManager singleton and implements ExportUsersToCSV
    public class AdminManagerAdapter : IAdminManager
    {
        private readonly AdminManager impl;

        public AdminManagerAdapter()
        {
            impl = AdminManager.Instance;
        }

        public DataTable GeneratePlacementStatistics() => impl.GeneratePlacementStatistics();
        public DataTable GetPendingApplications() => impl.GetPendingApplications();
        public DataTable GetActivityLogs() => impl.GetActivityLogs();

        // Export implementation lives in the adapter so AdminManager file is not altered
        public string ExportUsersToCSV(string filePath)
        {
            try
            {
                var dt = impl.GetAllUsers();
                if (dt == null || dt.Rows.Count == 0)
                    return "No users to export.";

                using (var sw = new System.IO.StreamWriter(filePath, false, System.Text.Encoding.UTF8))
                {
                    var columnNames = dt.Columns.Cast<System.Data.DataColumn>().Select(c => c.ColumnName);
                    sw.WriteLine(string.Join(",", columnNames));

                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        var fields = dt.Columns.Cast<System.Data.DataColumn>()
                            .Select(col => EscapeCsvField(row[col]));
                        sw.WriteLine(string.Join(",", fields));
                    }
                }

                return "Export completed: " + filePath;
            }
            catch (System.Exception ex)
            {
                return "Error exporting users: " + ex.Message;
            }
        }

        private string EscapeCsvField(object value)
        {
            if (value == null) return "";
            var s = value.ToString();
            if (s.Contains("\"")) s = s.Replace("\"", "\"\"");
            if (s.Contains(",") || s.Contains("\"") || s.Contains("\n") || s.Contains("\r"))
                return "\"" + s + "\"";
            return s;
        }
    }
}