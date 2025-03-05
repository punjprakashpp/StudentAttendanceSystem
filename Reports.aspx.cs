using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

public partial class Reports : System.Web.UI.Page
{
    string connStr = WebConfigurationManager.ConnectionStrings["AttendanceDB"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadStudents();
        }
    }

    private void LoadStudents()
    {
        ddlStudents.Items.Clear();
        ddlStudents.Items.Add(new ListItem("-- Select a Student --", "")); // Default item

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            string query = "SELECT StudentID, Name FROM Students";
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ddlStudents.Items.Add(new ListItem(reader["Name"].ToString(), reader["StudentID"].ToString()));
                }
            }
        }
    }

    protected void GenerateReport_Click(object sender, EventArgs e)
    {
        reportTable.Rows.Clear(); // Clear previous data

        if (string.IsNullOrEmpty(ddlStudents.SelectedValue))
        {
            return; // Do nothing if no student is selected
        }

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            string query = @"
                SELECT A.Date, S.SubjectName, A.Status 
                FROM Attendance A
                JOIN Subjects S ON A.SubjectID = S.SubjectID
                WHERE A.StudentID = @StudentID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@StudentID", ddlStudents.SelectedValue);

            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    TableRow row = new TableRow();
                    row.Cells.Add(new TableCell { Text = Convert.ToDateTime(reader["Date"]).ToString("yyyy-MM-dd") });
                    row.Cells.Add(new TableCell { Text = reader["SubjectName"].ToString() });
                    row.Cells.Add(new TableCell { Text = reader["Status"].ToString() });

                    reportTable.Rows.Add(row); // Correct way to add rows
                }
            }
        }
    }
}