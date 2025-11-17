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
}