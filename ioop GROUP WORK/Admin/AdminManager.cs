using ioop_GROUP_WORK.Admin;
using ioop_GROUP_WORK.Login;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

//Sync AdminManager as per my plans for the forms No Alterations
namespace ioop_GROUP_WORK.Admin
{
    /// <summary>
    /// AdminManager - Business Logic Layer for Administrator operations
    /// Implements Singleton pattern for database operations
    /// Provides centralized management of admin functions with validation
    /// </summary>
    internal class AdminManager
    {
        private static AdminManager instance = null;
        private static readonly object lockObject = new object();
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString;

        private AdminManager() { }

        public static AdminManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new AdminManager();
                        }
                    }
                }
                return instance;
            }
        }

        // ============================================
        // ADMINISTRATOR TABLE - CRUD (Delegated to Administrator class)
        // ============================================

        public DataTable GetAllAdministrators()
        {
            return Administrator.GetAll();
        }

        public Administrator GetAdministratorById(int adminId)
        {
            return Administrator.GetById(adminId);
        }

        public Administrator GetAdministratorByUserId(int userId)
        {
            return Administrator.GetByUserId(userId);
        }

        public string CreateAdministrator(int userId, string fullName, string department, string phone, string accessLevel)
        {
            return Administrator.Create(0, userId, fullName, department, phone, accessLevel);
        }

        public string UpdateAdministrator(int adminId, string field, string newValue)
        {
            return Administrator.Update(adminId, field, newValue);
        }

        public string UpdateAdministratorMultiple(int adminId, string fullName, string department, string phone, string accessLevel)
        {
            return Administrator.UpdateMultiple(adminId, fullName, department, phone, "", accessLevel);
        }

        public string DeleteAdministrator(int adminId)
        {
            return Administrator.Delete(adminId);
        }

        public DataTable SearchAdministrators(string searchTerm)
        {
            return Administrator.Search(searchTerm);
        }

        public int GetAdministratorCount()
        {
            return Administrator.Count();
        }

        // ============================================
        // USERS TABLE - CRUD OPERATIONS
        // ============================================

        public DataTable GetAllUsers()
        {
            try
            {
                DataTable dtUsers = new DataTable();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT id, Username, Email, role FROM users ORDER BY Username";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dtUsers);
                    }
                }
                return dtUsers;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving users: " + ex.Message);
            }
        }

        public string CreateUser(string userId, string username, string email, string password, string role)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO users (Username, Email, password, role) VALUES (@username, @email, @password, @role)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", username ?? "");
                        cmd.Parameters.AddWithValue("@email", email ?? "");
                        cmd.Parameters.AddWithValue("@password", password ?? "");
                        cmd.Parameters.AddWithValue("@role", role ?? "Student");
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "User created successfully." : "Failed to create user.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string UpdateUser(int userId, string field, string newValue)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = $"UPDATE users SET {field} = @value WHERE id = @userId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@value", newValue ?? "");
                        cmd.Parameters.AddWithValue("@userId", userId);
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "User updated successfully." : "User not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string DeleteUser(int userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "DELETE FROM users WHERE id = @userId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "User deleted successfully." : "User not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public DataTable SearchUsers(string searchTerm)
        {
            try
            {
                DataTable dtSearch = new DataTable();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT id, Username, Email, role FROM users WHERE Username LIKE @searchTerm OR Email LIKE @searchTerm ORDER BY Username";
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
                throw new Exception("Error searching users: " + ex.Message);
            }
        }

        // ============================================
        // STUDENTS TABLE - CRUD OPERATIONS
        // ============================================

        public DataTable GetAllStudents()
        {
            try
            {
                DataTable dtStudents = new DataTable();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT studentID, studentName, email, phoneNumber, course FROM Students ORDER BY studentName";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dtStudents);
                    }
                }
                return dtStudents;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving students: " + ex.Message);
            }
        }

        public string CreateStudent(string studentID, string studentName, string email, string phoneNumber, string course)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO Students (studentID, studentName, email, phoneNumber, course) VALUES (@studentID, @studentName, @email, @phoneNumber, @course)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@studentID", studentID ?? "");
                        cmd.Parameters.AddWithValue("@studentName", studentName ?? "");
                        cmd.Parameters.AddWithValue("@email", email ?? "");
                        cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber ?? "");
                        cmd.Parameters.AddWithValue("@course", course ?? "");
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "Student created successfully." : "Failed to create student.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string UpdateStudent(string studentID, string field, string newValue)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = $"UPDATE Students SET {field} = @value WHERE studentID = @studentID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@value", newValue ?? "");
                        cmd.Parameters.AddWithValue("@studentID", studentID);
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "Student updated successfully." : "Student not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string DeleteStudent(string studentID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "DELETE FROM Students WHERE studentID = @studentID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@studentID", studentID);
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "Student deleted successfully." : "Student not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        // ============================================
        // SUPERVISORS TABLE - CRUD OPERATIONS
        // ============================================

        public DataTable GetAllSupervisors()
        {
            try
            {
                DataTable dtSupervisors = new DataTable();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"SELECT s.SupervisorId, s.FullName, s.Department, s.Phone, s.Email, 
                                   u.Username, s.IsActive, s.CreatedDate 
                                   FROM Supervisors s 
                                   JOIN users u ON s.UserId = u.id 
                                   ORDER BY s.FullName";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dtSupervisors);
                    }
                }
                return dtSupervisors;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving supervisors: " + ex.Message);
            }
        }

        public string CreateSupervisor(int userId, string fullName, string department, string phone, string email)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"INSERT INTO Supervisors (UserId, FullName, Department, Phone, Email, IsActive) 
                                   VALUES (@userId, @fullName, @department, @phone, @email, 1)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@fullName", fullName ?? "");
                        cmd.Parameters.AddWithValue("@department", department ?? "");
                        cmd.Parameters.AddWithValue("@phone", phone ?? "");
                        cmd.Parameters.AddWithValue("@email", email ?? "");
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "Supervisor created successfully." : "Failed to create supervisor.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string UpdateSupervisor(int supervisorId, string field, string newValue)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = $"UPDATE Supervisors SET {field} = @value WHERE SupervisorId = @supervisorId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@value", newValue ?? "");
                        cmd.Parameters.AddWithValue("@supervisorId", supervisorId);
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "Supervisor updated successfully." : "Supervisor not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string DeleteSupervisor(int supervisorId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "DELETE FROM Supervisors WHERE SupervisorId = @supervisorId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@supervisorId", supervisorId);
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "Supervisor deleted successfully." : "Supervisor not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        // ============================================
        // RECRUITERS TABLE - CRUD OPERATIONS
        // ============================================

        public DataTable GetAllRecruiters()
        {
            try
            {
                DataTable dtRecruiters = new DataTable();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"SELECT r.RecruiterId, r.FullName, r.Position, r.Phone, r.Email, 
                                   u.Username, c.CompanyName, r.IsActive, r.CreatedDate 
                                   FROM Recruiters r 
                                   JOIN users u ON r.UserId = u.id 
                                   JOIN CompanyProfile c ON r.CompanyId = c.Id 
                                   ORDER BY r.FullName";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dtRecruiters);
                    }
                }
                return dtRecruiters;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving recruiters: " + ex.Message);
            }
        }

        public DataTable GetRecruitersByCompany(int companyId)
        {
            try
            {
                DataTable dtRecruiters = new DataTable();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"SELECT r.RecruiterId, r.FullName, r.Position, r.Phone, r.Email, 
                                   u.Username, c.CompanyName 
                                   FROM Recruiters r 
                                   JOIN users u ON r.UserId = u.id 
                                   JOIN CompanyProfile c ON r.CompanyId = c.Id 
                                   WHERE r.CompanyId = @companyId 
                                   ORDER BY r.FullName";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@companyId", companyId);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dtRecruiters);
                    }
                }
                return dtRecruiters;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving recruiters: " + ex.Message);
            }
        }

        public string CreateRecruiter(string username, string email, string password, int companyId, string fullName, string position, string phone)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlTransaction transaction = con.BeginTransaction();
                    try
                    {
                        string userQuery = @"INSERT INTO users (Username, Email, password, role) OUTPUT INSERTED.id 
                                           VALUES (@username, @email, @password, 'Recruiter')";
                        int userId;
                        using (SqlCommand userCmd = new SqlCommand(userQuery, con, transaction))
                        {
                            userCmd.Parameters.AddWithValue("@username", username);
                            userCmd.Parameters.AddWithValue("@email", email);
                            userCmd.Parameters.AddWithValue("@password", password);
                            userId = (int)userCmd.ExecuteScalar();
                        }

                        string recruiterQuery = @"INSERT INTO Recruiters (UserId, CompanyId, FullName, Position, Phone, Email, IsActive) 
                                                VALUES (@userId, @companyId, @fullName, @position, @phone, @email, 1)";
                        using (SqlCommand recruiterCmd = new SqlCommand(recruiterQuery, con, transaction))
                        {
                            recruiterCmd.Parameters.AddWithValue("@userId", userId);
                            recruiterCmd.Parameters.AddWithValue("@companyId", companyId);
                            recruiterCmd.Parameters.AddWithValue("@fullName", fullName ?? "");
                            recruiterCmd.Parameters.AddWithValue("@position", position ?? "");
                            recruiterCmd.Parameters.AddWithValue("@phone", phone ?? "");
                            recruiterCmd.Parameters.AddWithValue("@email", email ?? "");
                            recruiterCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return "Recruiter created successfully.";
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string UpdateRecruiter(int recruiterId, string field, string newValue)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = $"UPDATE Recruiters SET {field} = @value WHERE RecruiterId = @recruiterId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@value", newValue ?? "");
                        cmd.Parameters.AddWithValue("@recruiterId", recruiterId);
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "Recruiter updated successfully." : "Recruiter not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string DeleteRecruiter(int recruiterId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "DELETE FROM Recruiters WHERE RecruiterId = @recruiterId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@recruiterId", recruiterId);
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "Recruiter deleted successfully." : "Recruiter not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        // ============================================
        // COMPANIES TABLE - CRUD OPERATIONS
        // ============================================

        public DataTable GetAllCompanies()
        {
            try
            {
                DataTable dtCompanies = new DataTable();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"SELECT Id, CompanyName, ContactPerson, Email, ContactNumber, Address, CompanyDescription 
                                   FROM CompanyProfile ORDER BY CompanyName";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dtCompanies);
                    }
                }
                return dtCompanies;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving companies: " + ex.Message);
            }
        }

        public string CreateCompany(string companyName, string contactPerson, string email, string contactNumber, string address, string description)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"INSERT INTO CompanyProfile (CompanyName, ContactPerson, Email, ContactNumber, Address, CompanyDescription) 
                                   VALUES (@companyName, @contactPerson, @email, @contactNumber, @address, @description)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@companyName", companyName ?? "");
                        cmd.Parameters.AddWithValue("@contactPerson", contactPerson ?? "");
                        cmd.Parameters.AddWithValue("@email", email ?? "");
                        cmd.Parameters.AddWithValue("@contactNumber", contactNumber ?? "");
                        cmd.Parameters.AddWithValue("@address", address ?? "");
                        cmd.Parameters.AddWithValue("@description", description ?? "");
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "Company created successfully." : "Failed to create company.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string UpdateCompany(int companyId, string field, string newValue)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = $"UPDATE CompanyProfile SET {field} = @value WHERE Id = @companyId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@value", newValue ?? "");
                        cmd.Parameters.AddWithValue("@companyId", companyId);
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "Company updated successfully." : "Company not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string DeleteCompany(int companyId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "DELETE FROM CompanyProfile WHERE Id = @companyId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@companyId", companyId);
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "Company deleted successfully." : "Company not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        // ============================================
        // APPLICATIONS TABLE - CRUD OPERATIONS
        // ============================================

        public DataTable GetAllApplications()
        {
            try
            {
                DataTable dtApplications = new DataTable();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"SELECT StudentID, StudentName, Position, CompanyName, DateApplied, Status 
                                   FROM StudentApplication ORDER BY DateApplied DESC";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dtApplications);
                    }
                }
                return dtApplications;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving applications: " + ex.Message);
            }
        }

        public DataTable GetApplicationsByStatus(string status)
        {
            try
            {
                DataTable dtApplications = new DataTable();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"SELECT StudentID, StudentName, CompanyName, Position, DateApplied, Status 
                                   FROM StudentApplication 
                                   WHERE (@status = 'All' OR Status = @status) 
                                   ORDER BY DateApplied DESC";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@status", status);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dtApplications);
                    }
                }
                return dtApplications;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving applications: " + ex.Message);
            }
        }

        public string UpdateApplicationStatus(string studentID, string newStatus)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "UPDATE StudentApplication SET Status = @status WHERE StudentID = @studentID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@status", newStatus);
                        cmd.Parameters.AddWithValue("@studentID", studentID);
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "Application status updated successfully." : "Application not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        // ============================================
        // INTERNSHIP OFFERS TABLE - CRUD OPERATIONS
        // ============================================

        public DataTable GetAllInternshipOffers()
        {
            try
            {
                DataTable dtOffers = new DataTable();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"SELECT Id, JobTitle, Position, StartDate, EndDate, Salary, CompanyName, DateOffered 
                                   FROM InternshipOffer ORDER BY DateOffered DESC";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dtOffers);
                    }
                }
                return dtOffers;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving internship offers: " + ex.Message);
            }
        }

        public string CreateInternshipOffer(string jobTitle, string position, DateTime startDate, DateTime endDate, decimal salary, string description, string companyName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"INSERT INTO InternshipOffer (JobTitle, Position, StartDate, EndDate, Salary, Description, CompanyName, DateOffered) 
                                   VALUES (@jobTitle, @position, @startDate, @endDate, @salary, @description, @companyName, GETDATE())";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@jobTitle", jobTitle ?? "");
                        cmd.Parameters.AddWithValue("@position", position ?? "");
                        cmd.Parameters.AddWithValue("@startDate", startDate);
                        cmd.Parameters.AddWithValue("@endDate", endDate);
                        cmd.Parameters.AddWithValue("@salary", salary);
                        cmd.Parameters.AddWithValue("@description", description ?? "");
                        cmd.Parameters.AddWithValue("@companyName", companyName ?? "");
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "Internship offer created successfully." : "Failed to create offer.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string DeleteInternshipOffer(int offerId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "DELETE FROM InternshipOffer WHERE Id = @offerId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@offerId", offerId);
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "Internship offer deleted successfully." : "Offer not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        // ============================================
        // COURSES TABLE - CRUD OPERATIONS
        // ============================================

        public DataTable GetAllCourses()
        {
            try
            {
                DataTable dtCourses = new DataTable();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT CourseId, SubjectName FROM Courses ORDER BY SubjectName";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dtCourses);
                    }
                }
                return dtCourses;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving courses: " + ex.Message);
            }
        }

        public string CreateCourse(string subjectName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO Courses (SubjectName) VALUES (@subjectName)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@subjectName", subjectName ?? "");
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "Course created successfully." : "Failed to create course.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string UpdateCourse(int courseId, string field, string newValue)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = $"UPDATE Courses SET {field} = @value WHERE CourseId = @courseId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@value", newValue ?? "");
                        cmd.Parameters.AddWithValue("@courseId", courseId);
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "Course updated successfully." : "Course not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string DeleteCourse(int courseId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "DELETE FROM Courses WHERE CourseId = @courseId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@courseId", courseId);
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "Course deleted successfully." : "Course not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        // ============================================
        // CHAPTERS TABLE - CRUD OPERATIONS
        // ============================================

        public DataTable GetAllChapters()
        {
            try
            {
                DataTable dtChapters = new DataTable();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"SELECT c.ChapterId, c.ChapterName, c.ChapterOrder, c.Description, co.SubjectName 
                                   FROM Chapters c 
                                   JOIN Courses co ON c.CourseId = co.CourseId 
                                   ORDER BY c.ChapterOrder";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dtChapters);
                    }
                }
                return dtChapters;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving chapters: " + ex.Message);
            }
        }

        public string CreateChapter(int courseId, string chapterName, int chapterOrder, string description)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"INSERT INTO Chapters (CourseId, ChapterName, ChapterOrder, Description) 
                                   VALUES (@courseId, @chapterName, @chapterOrder, @description)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@courseId", courseId);
                        cmd.Parameters.AddWithValue("@chapterName", chapterName ?? "");
                        cmd.Parameters.AddWithValue("@chapterOrder", chapterOrder);
                        cmd.Parameters.AddWithValue("@description", description ?? "");
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "Chapter created successfully." : "Failed to create chapter.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string UpdateChapter(int chapterId, string field, string newValue)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = $"UPDATE Chapters SET {field} = @value WHERE ChapterId = @chapterId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@value", newValue ?? "");
                        cmd.Parameters.AddWithValue("@chapterId", chapterId);
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "Chapter updated successfully." : "Chapter not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string DeleteChapter(int chapterId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "DELETE FROM Chapters WHERE ChapterId = @chapterId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@chapterId", chapterId);
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "Chapter deleted successfully." : "Chapter not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        // ============================================
        // CHECK-IN RECORDS TABLE - CRUD OPERATIONS
        // ============================================

        public DataTable GetAllCheckInRecords()
        {
            try
            {
                DataTable dtCheckIn = new DataTable();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"SELECT CheckInID, studentID, studentName, checkInDate 
                                   FROM CheckInRecord 
                                   ORDER BY checkInDate DESC";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dtCheckIn);
                    }
                }
                return dtCheckIn;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving check-in records: " + ex.Message);
            }
        }

        public string CreateCheckInRecord(string studentId, string studentName, DateTime checkInDate)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"INSERT INTO CheckInRecord (studentID, studentName, checkInDate) 
                                   VALUES (@studentId, @studentName, @checkInDate)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId ?? "");
                        cmd.Parameters.AddWithValue("@studentName", studentName ?? "");
                        cmd.Parameters.AddWithValue("@checkInDate", checkInDate);
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "Check-in record created successfully." : "Failed to create check-in record.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string DeleteCheckInRecord(int checkInId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "DELETE FROM CheckInRecord WHERE CheckInID = @checkInId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@checkInId", checkInId);
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "Check-in record deleted successfully." : "Record not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        // ============================================
        // STUDENT PROGRESS TABLE - CRUD OPERATIONS
        // ============================================

        public DataTable GetAllStudentProgress()
        {
            try
            {
                DataTable dtProgress = new DataTable();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"SELECT sp.SubjectId, sp.ChapterId, sp.ProgressPercentage, sp.studentID, 
                                   s.studentName, c.SubjectName 
                                   FROM StudentProgress sp 
                                   JOIN Students s ON sp.studentID = s.studentID 
                                   JOIN Courses c ON sp.SubjectId = c.CourseId 
                                   ORDER BY sp.studentID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dtProgress);
                    }
                }
                return dtProgress;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving student progress: " + ex.Message);
            }
        }

        public string UpdateStudentProgress(string studentId, int subjectId, int chapterId, decimal progressPercentage)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"UPDATE StudentProgress 
                                   SET ProgressPercentage = @progress 
                                   WHERE studentID = @studentId AND SubjectId = @subjectId AND ChapterId = @chapterId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@progress", progressPercentage);
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        cmd.Parameters.AddWithValue("@subjectId", subjectId);
                        cmd.Parameters.AddWithValue("@chapterId", chapterId);
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "Student progress updated successfully." : "Progress record not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        // ============================================
        // STUDENT EVALUATION REPORT TABLE - CRUD OPERATIONS
        // ============================================

        public DataTable GetAllEvaluationReports()
        {
            try
            {
                DataTable dtReports = new DataTable();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"SELECT ReportID, studentID, studentName, Position, EvaluationDate, 
                                   Performance, CommunicationSkills, Punctuality 
                                   FROM StudentEvaluationReport 
                                   ORDER BY EvaluationDate DESC";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dtReports);
                    }
                }
                return dtReports;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving evaluation reports: " + ex.Message);
            }
        }

        public string CreateEvaluationReport(string studentId, string studentName, string position,
            DateTime evaluationDate, float performance, float communicationSkills, float punctuality, string description)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"INSERT INTO StudentEvaluationReport 
                                   (studentID, studentName, Position, EvaluationDate, Performance, CommunicationSkills, Punctuality, Description) 
                                   VALUES (@studentId, @studentName, @position, @evaluationDate, @performance, @communication, @punctuality, @description)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId ?? "");
                        cmd.Parameters.AddWithValue("@studentName", studentName ?? "");
                        cmd.Parameters.AddWithValue("@position", position ?? "");
                        cmd.Parameters.AddWithValue("@evaluationDate", evaluationDate);
                        cmd.Parameters.AddWithValue("@performance", performance);
                        cmd.Parameters.AddWithValue("@communication", communicationSkills);
                        cmd.Parameters.AddWithValue("@punctuality", punctuality);
                        cmd.Parameters.AddWithValue("@description", description ?? "");
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "Evaluation report created successfully." : "Failed to create report.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string DeleteEvaluationReport(int reportId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "DELETE FROM StudentEvaluationReport WHERE ReportID = @reportId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@reportId", reportId);
                        int result = cmd.ExecuteNonQuery();
                        return result > 0 ? "Evaluation report deleted successfully." : "Report not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        // ============================================
        // UTILITY METHODS
        // ============================================

        public DataTable GetAllTables()
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES 
                                   WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_NAME";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting tables: " + ex.Message);
            }
        }

        public DataTable GetTableData(string tableName)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = $"SELECT * FROM {tableName}";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandTimeout = 120;
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting table data: " + ex.Message);
            }
        }

        //=============================
        // Supervisor Assignment
        //=============================

        /// <summary>
        /// Assign supervisor to student
        /// Creates many-to-one relationship for student monitoring
        /// </summary>
        public string AssignSupervisor(string studentId, int supervisorId) // Supervisor Assign to Student Implement in AssignSupervisor Form
        {
            try
            {
                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();

                    // Attempt to update Students table if it has SupervisorId column
                    string query = @"
                        UPDATE Students 
                        SET SupervisorId = @supervisorId
                        WHERE studentID = @studentId;";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@supervisorId", supervisorId);
                        cmd.Parameters.AddWithValue("@studentId", studentId);

                        try
                        {
                            int result = cmd.ExecuteNonQuery();
                            return (result > 0) ? "Supervisor assigned successfully" : "Failed to assign (no matching student)";
                        }
                        catch (SqlException sqlEx)
                        {
                            // Likely the Students table doesn't have SupervisorId column in the schema
                            return "Cannot assign supervisor: database schema does not contain a SupervisorId column on Students. " + sqlEx.Message;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        //=============================
        // Dashboard Statistics
        //=============================

        /// <summary>
        /// Get total count of active users
        /// </summary>
        public int GetTotalUsersCount() // Make Dynamic for Totals for all Relevant Columns
        {
            try
            {
                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM users;";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Get count of students
        /// </summary>
        public int GetTotalStudentsCount() // Make Dynamic for Averages of All Relevant columns
        {
            try
            {
                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Students;";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Get count of companies
        /// </summary>
        public int GetTotalCompaniesCount() // Make Dynamic for Max Values of Relevant Columns
        {
            try
            {
                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM CompanyProfile;";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Get count of recruiters
        /// </summary>
        public int GetTotalRecruitersCount() // Make Dynamic for Min Values of Relevant Columns
        {
            try
            {
                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Recruiters;";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Get count of pending applications
        /// </summary>
        public int GetPendingApplicationsCount()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM StudentApplication WHERE Status = 'Pending';";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //=============================
        // Reports and Analytics
        //=============================

        /// <summary>
        /// Generate comprehensive placement statistics
        /// </summary>

        /// <summary>
        /// Get pending applications for dashboard
        /// </summary>
        public DataTable GetPendingApplications()
        {
            try
            {
                DataTable dtPending = new DataTable();

                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    string query = @"
                        SELECT StudentID, StudentName, Position, CompanyName, DateApplied, Status
                        FROM StudentApplication
                        WHERE Status = 'Pending'
                        ORDER BY DateApplied DESC;";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dtPending);
                    }
                }

                return dtPending;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Get activity logs showing recruiter decisions
        /// Maintains audit trail for system transparency
        /// </summary>
        public DataTable GetActivityLogs(string status)
        {
            DataTable dtLogs = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
            {
                con.Open();
                string query = @"
            SELECT StudentID, StudentName, CompanyName, Position, DateApplied, Status
            FROM StudentApplication
            WHERE (@status = 'All' OR Status = @status)
            ORDER BY DateApplied DESC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dtLogs);
                }
            }
            return dtLogs;
        }


        /// <summary>
        /// Export all users to CSV file
        /// </summary>

        /// <summary>
        /// Get table data (SQL)
        /// </summary>


        /// <summary>
        /// Export to CSV excluding IDs and Passwords
        /// </summary>

        /// <summary>
        /// Remove sensitive columns like IDs and Passwords for export
        /// </summary>
        /// <summary>
        /// Calculate relevant aggregate statistics for any table
        /// Based on database schema - extracts meaningful metrics
        /// Examples: TotalStudents, AverageSalary, TotalPendingApplications
        /// </summary>
        /// <summary>
        /// Calculate relevant aggregate statistics for any table
        /// Excludes IDs and sensitive columns
        /// </summary>
                
        public DataTable CalculateAggregateStatistics(string tableName)
        {
            try
            {
                DataTable dt = GetTableData(tableName);
                if (dt == null || dt.Rows.Count == 0)
                    return null;

                DataTable stats = new DataTable();
                stats.Columns.Add("Metric", typeof(string));
                stats.Columns.Add("Value", typeof(string));

                // Basic Info
                stats.Rows.Add("Table", tableName);
                stats.Rows.Add("Total Records", dt.Rows.Count.ToString());
                stats.Rows.Add("", "");

                // Sensitive patterns to exclude
                var sensitivePatterns = new[] { "id", "password", "passwordhash", "salt", "token", "secret", "key", "credential" };

                // Relevant aggregates based on table schema
                switch (tableName.ToLower())
                {
                    case "students":
                        stats.Rows.Add("Total Students", dt.Rows.Count.ToString());
                        break;

                    case "studentapplication":
                        int totalApps = dt.Rows.Count;
                        int accepted = 0, rejected = 0, pending = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["Status"] != DBNull.Value)
                            {
                                string status = row["Status"].ToString().Trim().ToLower();
                                if (status == "accepted") accepted++;
                                else if (status == "rejected") rejected++;
                                else if (status == "pending") pending++;
                            }
                        }
                        stats.Rows.Add("Total Applications", totalApps.ToString());
                        stats.Rows.Add("Accepted", accepted.ToString());
                        stats.Rows.Add("Rejected", rejected.ToString());
                        stats.Rows.Add("Pending", pending.ToString());
                        break;

                    case "internshipoffer":
                        stats.Rows.Add("Total Internship Offers", dt.Rows.Count.ToString());
                        // Calculate average salary if exists
                        try
                        {
                            if (dt.Columns.Contains("Salary"))
                            {
                                decimal totalSalary = 0;
                                int salaryCount = 0;
                                foreach (DataRow row in dt.Rows)
                                {
                                    if (row["Salary"] != DBNull.Value)
                                    {
                                        totalSalary += Convert.ToDecimal(row["Salary"]);
                                        salaryCount++;
                                    }
                                }
                                if (salaryCount > 0)
                                    stats.Rows.Add("Average Salary", (totalSalary / salaryCount).ToString("N2"));
                            }
                        }
                        catch { }
                        break;

                    case "users":
                        stats.Rows.Add("Total Users", dt.Rows.Count.ToString());
                        break;

                    case "recruiters":
                        stats.Rows.Add("Total Recruiters", dt.Rows.Count.ToString());
                        break;

                    case "supervisors":
                        stats.Rows.Add("Total Supervisors", dt.Rows.Count.ToString());
                        break;

                    case "companyprofile":
                        stats.Rows.Add("Total Companies", dt.Rows.Count.ToString());
                        break;

                    default:
                        // Generic numeric column aggregates (excluding IDs and sensitive columns)
                        foreach (DataColumn col in dt.Columns)
                        {
                            // Skip sensitive columns
                            bool isSensitive = false;
                            foreach (var pattern in sensitivePatterns)
                            {
                                if (col.ColumnName.ToLower().Contains(pattern))
                                {
                                    isSensitive = true;
                                    break;
                                }
                            }

                            if (isSensitive)
                                continue;

                            // Only calculate for numeric columns
                            if (col.DataType == typeof(int) || col.DataType == typeof(decimal) ||
                                col.DataType == typeof(double) || col.DataType == typeof(float))
                            {
                                try
                                {
                                    decimal sum = 0, max = decimal.MinValue, min = decimal.MaxValue;
                                    int count = 0;

                                    foreach (DataRow row in dt.Rows)
                                    {
                                        if (row[col] != DBNull.Value)
                                        {
                                            decimal val = Convert.ToDecimal(row[col]);
                                            sum += val;
                                            if (val > max) max = val;
                                            if (val < min) min = val;
                                            count++;
                                        }
                                    }

                                    if (count > 0)
                                    {
                                        stats.Rows.Add($"{col.ColumnName} - Total", sum.ToString("N2"));
                                        stats.Rows.Add($"{col.ColumnName} - Average", (sum / count).ToString("N2"));
                                        stats.Rows.Add($"{col.ColumnName} - Maximum", max.ToString("N2"));
                                        stats.Rows.Add($"{col.ColumnName} - Minimum", min.ToString("N2"));
                                    }
                                }
                                catch { }
                            }
                        }
                        break;
                }

                stats.Rows.Add("", "");
                stats.Rows.Add("Last Updated", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                return stats;
            }
            catch (Exception ex)
            {
                throw new Exception("Error calculating statistics: " + ex.Message);
            }
        }

        /// <summary>
        /// Export to CSV with both data AND statistics (Excludes IDs and Passwords)
        /// </summary>
        /// <summary>
        /// Export to CSV with both data AND statistics (Excludes IDs and Passwords)
        /// </summary>
        public string ExportToCSVExcludingSensitive(string tableName, string filePath)
        {
            try
            {
                DataTable dt = GetTableData(tableName);
                if (dt == null || dt.Rows.Count == 0)
                    return "No data to export.";

                // Create a copy to preserve original
                DataTable dtCopy = dt.Copy();

                // Remove sensitive columns
                RemoveSensitiveColumnsForExport(dtCopy);

                if (dtCopy.Columns.Count == 0)
                    return "No columns available after removing sensitive data.";

                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, false, System.Text.Encoding.UTF8))
                {
                    // ===== DATA SECTION =====
                    sw.WriteLine($"TABLE: {tableName}");
                    sw.WriteLine($"Export Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    sw.WriteLine($"Total Records: {dtCopy.Rows.Count}");
                    sw.WriteLine();

                    // Column headers
                    for (int i = 0; i < dtCopy.Columns.Count; i++)
                    {
                        sw.Write(dtCopy.Columns[i].ColumnName);
                        if (i < dtCopy.Columns.Count - 1) sw.Write(",");
                    }
                    sw.WriteLine();

                    // Data rows
                    for (int i = 0; i < dtCopy.Rows.Count; i++)
                    {
                        for (int j = 0; j < dtCopy.Columns.Count; j++)
                        {
                            object val = dtCopy.Rows[i][j];
                            string strVal = (val == null || val == DBNull.Value) ? "" : val.ToString();

                            if (strVal.Contains(",") || strVal.Contains("\""))
                                strVal = "\"" + strVal.Replace("\"", "\"\"") + "\"";

                            sw.Write(strVal);
                            if (j < dtCopy.Columns.Count - 1) sw.Write(",");
                        }
                        sw.WriteLine();
                    }

                    // ===== AGGREGATE STATISTICS SECTION =====
                    sw.WriteLine();
                    sw.WriteLine("═════════════════════════════════════════");
                    sw.WriteLine("AGGREGATE STATISTICS");
                    sw.WriteLine("═════════════════════════════════════════");
                    sw.WriteLine();

                    try
                    {
                        DataTable dtStats = CalculateAggregateStatistics(tableName);
                        if (dtStats != null && dtStats.Rows.Count > 0)
                        {
                            foreach (DataRow statRow in dtStats.Rows)
                            {
                                string metric = statRow[0].ToString();
                                string value = statRow[1].ToString();
                                if (!string.IsNullOrWhiteSpace(metric))
                                    sw.WriteLine($"{metric},{value}");
                            }
                        }
                    }
                    catch { }
                }

                return "Export OK: " + System.IO.Path.GetFileName(filePath);
            }
            catch (System.IO.IOException ioEx)
            {
                return "File Error: " + ioEx.Message;
            }
            catch (SqlException sqlEx)
            {
                return "SQL Error: " + sqlEx.Message;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        /// <summary>
        /// Remove sensitive columns like IDs and Passwords for export
        /// </summary>
        private void RemoveSensitiveColumnsForExport(DataTable dt)
        {
            var sensitivePatterns = new[] { "id", "password", "passwordhash", "salt", "token", "secret", "key", "credential" };
            var columnsToRemove = new List<string>();

            foreach (DataColumn col in dt.Columns)
            {
                foreach (var pattern in sensitivePatterns)
                {
                    if (col.ColumnName.ToLower().Contains(pattern))
                    {
                        columnsToRemove.Add(col.ColumnName);
                        break;
                    }
                }
            }

            foreach (var colName in columnsToRemove)
            {
                dt.Columns.Remove(colName);
            }
        }
    }
}
