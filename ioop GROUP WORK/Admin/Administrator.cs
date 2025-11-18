using ioop_GROUP_WORK.HR;
using ioop_GROUP_WORK.Login;
using ioop_GROUP_WORK.Student;
using ioop_GROUP_WORK.UniSupervisor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ioop_GROUP_WORK.Admin
{
    [Table("Administrators")]
    internal class Administrator
    {
        [Key]
        [Column("AdminId")]
        public int AdminId { get; private set; }
        [Required]
        [Column("UserId")]
        [ForeignKey("id")]
        public int UserId
        {
            get
            {
                return UserId;
            }
            private set
            {
                UserId = value;
            }
        }
        [Required]
        [StringLength(100)]
        [Column("FullName")]
        public string FullName { get; private set; }
        [StringLength(100)]
        [Column("Department")]
        public string Department { get; private set; }
        [StringLength(20)]
        [Column("Phone")]
        public string Phone { get; private set; }
        [StringLength(20)]
        [Column("AccessLevel")]
        public string AccessLevel { get; private set; }


        // Constructor 1: Default
        public Administrator() { }
        public Administrator(int userId, string fullName, string department, string phone, string accessLevel)
        {
            UserId = userId;
            FullName = fullName;
            Department = department;
            Phone = phone;
            AccessLevel = accessLevel;
        }


        public Administrator(int adminId, int userId, string fullName, string department, string phone, string accessLevel)
        {
            AdminId = adminId;
            UserId = userId;
            FullName = fullName;
            Department = department;
            Phone = phone;
            AccessLevel = accessLevel;
        }

        // ✅ CREATE - Add new administrator
        public static string Create(int adminId, int userId, string fullName, string department, string phone, string accessLevel)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    string query = @"INSERT INTO Administrators (UserId, FullName, Department, Phone, AccessLevel, CreatedDate) 
                                   VALUES (@userId, @fullName, @department, @phone, @accessLevel, GETDATE())";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@fullName", fullName ?? "");
                        cmd.Parameters.AddWithValue("@department", department ?? "");
                        cmd.Parameters.AddWithValue("@phone", phone ?? "");
                        cmd.Parameters.AddWithValue("@accessLevel", accessLevel ?? "Full");
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "Administrator created successfully." : "Failed to create administrator.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        // ✅ READ - Get all administrators
        public static DataTable GetAll()
        {
            try
            {
                DataTable dtAdmins = new DataTable();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    string query = @"SELECT a.AdminId, a.UserId, a.FullName, a.Department, a.Phone,  
                                   a.AccessLevel, a.IsActive, u.Username, a.CreatedDate
                                   FROM Administrators a 
                                   JOIN users u ON a.UserId = u.id 
                                   ORDER BY a.FullName";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dtAdmins);
                    }
                }
                return dtAdmins;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving administrators: " + ex.Message);
            }
        }

        // ✅ READ - Get single administrator by ID
        public static Administrator GetById(int adminId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM Administrators WHERE AdminId = @adminId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@adminId", adminId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Administrator(
                                    (int)reader["AdminId"],
                                    (int)reader["UserId"],
                                    reader["FullName"].ToString(),
                                    reader["Department"].ToString(),
                                    reader["Phone"].ToString(),
                                    reader["AccessLevel"].ToString()
                                );
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving administrator: " + ex.Message);
            }
        }

        // ✅ UPDATE - Update administrator field
        public static string Update(int adminId, string field, string newValue)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    string query = $"UPDATE Administrators SET {field} = @value WHERE AdminId = @adminId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@value", newValue ?? "");
                        cmd.Parameters.AddWithValue("@adminId", adminId);
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? $"Administrator {field} updated successfully." : "Administrator not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        // ✅ UPDATE - Update multiple fields
        public static string UpdateMultiple(int adminId, string fullName, string department, string phone, string email, string accessLevel)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    string query = @"UPDATE Administrators 
                                   SET FullName = @fullName, 
                                       Department = @department, 
                                       Phone = @phone, 
                                       Email = @email, 
                                       AccessLevel = @accessLevel 
                                   WHERE AdminId = @adminId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@adminId", adminId);
                        cmd.Parameters.AddWithValue("@fullName", fullName ?? "");
                        cmd.Parameters.AddWithValue("@department", department ?? "");
                        cmd.Parameters.AddWithValue("@phone", phone ?? "");
                        cmd.Parameters.AddWithValue("@email", email ?? "");
                        cmd.Parameters.AddWithValue("@accessLevel", accessLevel ?? "Full");
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "Administrator updated successfully." : "Administrator not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        // ✅ DELETE - Delete administrator
        public static string Delete(int adminId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    string query = "DELETE FROM Administrators WHERE AdminId = @adminId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@adminId", adminId);
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "Administrator deleted successfully." : "Administrator not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        // ✅ SEARCH - Search administrators by name, email, or department
        public static DataTable Search(string searchTerm)
        {
            try
            {
                DataTable dtSearch = new DataTable();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    string query = @"SELECT a.AdminId, a.UserId, a.FullName, a.Department, a.Phone, a.Email, 
                                   a.AccessLevel, a.IsActive, u.Username
                                   FROM Administrators a 
                                   JOIN users u ON a.UserId = u.id 
                                   WHERE a.FullName LIKE @searchTerm 
                                      OR a.Email LIKE @searchTerm 
                                      OR a.Department LIKE @searchTerm 
                                   ORDER BY a.FullName";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dtSearch);
                    }
                }
                return dtSearch;
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching administrators: " + ex.Message);
            }
        }

        // ✅ COUNT - Get total administrators
        public static int Count()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Administrators WHERE IsActive = 1";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        return (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error counting administrators: " + ex.Message);
            }
        }

        // ✅ GET BY USER ID - Get administrator by User ID
        public static Administrator GetByUserId(int userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM Administrators WHERE UserId = @userId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Administrator(
                                    (int)reader["AdminId"],
                                    (int)reader["UserId"],
                                    reader["FullName"].ToString(),
                                    reader["Department"].ToString(),
                                    reader["Phone"].ToString(),
                                    reader["AccessLevel"].ToString()
                                );
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving administrator by user ID: " + ex.Message);
            }
        }
    }
}

