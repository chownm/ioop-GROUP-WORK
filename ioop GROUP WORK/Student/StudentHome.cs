namespace ioop_GROUP_WORK.Student
{
    public class StudentHome
    {
        // Attributes
        public string StudentID { get; private set; }
        public string StudentName { get; private set; }



        // Constructor
        public StudentHome(string id, string name)
        {
            StudentID = id;
            StudentName = name;
        }



        // Methods
        public string GetWelcomeMessage()
        {
            return $"Welcome, {StudentName}";
        }



        public void OpenProfileForm()
        {
            var profileForm = new StudentProfileForm(StudentID);
            profileForm.ShowDialog();
        }



        public void OpenInternshipForm()
        {
            var internshipForm = new InternshipListForm(StudentID);
            internshipForm.ShowDialog();
        }



        public void OpenApplicationsForm()
        {
            var applicationForm = new ViewApplicationStatusForm(StudentID);
            applicationForm.ShowDialog();
        }



        public void OpenReportUploadForm()
        {
            var reportForm = new StudentReportUploadForm(StudentID);
            reportForm.ShowDialog();
        }



        public void OpenFeedbackForm()
        {
            var feedbackForm = new ViewFeedbackForm(StudentID);
            feedbackForm.ShowDialog();
        }



        public void OpenCheckInForm()
        {
            var checkInForm = new StudentCheckInForm(StudentID, StudentName);
            checkInForm.ShowDialog();
        }



        public void OpenProgressForm()
        {
            var progressForm = new ViewCheckInRecordForm(StudentID);
            progressForm.ShowDialog();
        }



        public void OpenChangePasswordForm()
        {
            var changePassForm = new ChangePasswordForm(StudentID);
            changePassForm.ShowDialog();
        }
    }
}

