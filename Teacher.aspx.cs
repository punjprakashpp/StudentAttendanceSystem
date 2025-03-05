using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

public partial class Teacher : System.Web.UI.Page
{
    string connStr = WebConfigurationManager.ConnectionStrings["AttendanceDB"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null || Session["Role"].ToString() != "Teacher")
        {
            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {
            LoadStudents();
            LoadSubjects();
        }
    }

    private void LoadStudents()
    {
        ddlStudent.Items.Clear();
        ddlStudent.Items.Add(new ListItem("-- Select Student --", ""));

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            string query = "SELECT StudentID, Name FROM Students";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ddlStudent.Items.Add(new ListItem(reader["Name"].ToString(), reader["StudentID"].ToString()));
                }
            }
        }
    }

    private void LoadSubjects()
    {
        ddlSubject.Items.Clear();
        ddlSubject.Items.Add(new ListItem("-- Select Subject --", ""));

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            string query = "SELECT SubjectID, SubjectName FROM Subjects";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ddlSubject.Items.Add(new ListItem(reader["SubjectName"].ToString(), reader["SubjectID"].ToString()));
                }
            }
        }
    }

    protected void MarkAttendance_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(ddlStudent.SelectedValue) || string.IsNullOrEmpty(ddlSubject.SelectedValue))
        {
            return; // Do nothing if selections are empty
        }

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            string query = "INSERT INTO Attendance (StudentID, SubjectID, Date, Status) VALUES (@StudentID, @SubjectID, GETDATE(), @Status)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@StudentID", ddlStudent.SelectedValue);
            cmd.Parameters.AddWithValue("@SubjectID", ddlSubject.SelectedValue);
            cmd.Parameters.AddWithValue("@Status", ddlStatus.SelectedValue);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}