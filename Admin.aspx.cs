using System;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class Admin : System.Web.UI.Page
{
    string connStr = WebConfigurationManager.ConnectionStrings["AttendanceDB"].ConnectionString;

    protected void AddStudent_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "INSERT INTO Students (Name, Email, EnrollmentNo) VALUES (@Name, @Email, @EnrollmentNo)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@EnrollmentNo", txtEnrollment.Text);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    lblStudentMsg.Text = "Student added successfully!";
                }
                else
                {
                    lblStudentMsg.Text = "Failed to add student.";
                }
            }
        }
        catch (Exception ex)
        {
            lblStudentMsg.Text = "Error: " + ex.Message;
        }
    }

    protected void AddSubject_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "INSERT INTO Subjects (SubjectName) VALUES (@SubjectName)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SubjectName", txtSubject.Text);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    lblSubjectMsg.Text = "Subject added successfully!";
                }
                else
                {
                    lblSubjectMsg.Text = "Failed to add subject.";
                }
            }
        }
        catch (Exception ex)
        {
            lblSubjectMsg.Text = "Error: " + ex.Message;
        }
    }
}