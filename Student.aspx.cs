using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

public partial class Student : System.Web.UI.Page
{
    string connStr = WebConfigurationManager.ConnectionStrings["AttendanceDB"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null || Convert.ToString(Session["Role"]) != "Student")
        {
            Response.Redirect("Login.aspx");
            return;
        }

        if (!IsPostBack)
        {
            LoadAttendanceRecords();
        }
    }

    private void LoadAttendanceRecords()
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            string query = @"
                SELECT A.Date, S.SubjectName, A.Status 
                FROM Attendance A
                JOIN Subjects S ON A.SubjectID = S.SubjectID
                JOIN Students ST ON A.StudentID = ST.StudentID
                JOIN Users U ON ST.Email = U.Email
                WHERE U.UserID = @UserID";  // Corrected to match Users.UserID

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", Session["UserID"]);  // Using UserID instead of StudentID

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        TableRow noDataRow = new TableRow();
                        TableCell noDataCell = new TableCell
                        {
                            ColumnSpan = 3,
                            Text = "No attendance records found.",
                            HorizontalAlign = HorizontalAlign.Center
                        };
                        noDataRow.Cells.Add(noDataCell);
                        attendanceTable.Rows.Add(noDataRow);
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            TableRow row = new TableRow();
                            row.Cells.Add(new TableCell { Text = Convert.ToDateTime(reader["Date"]).ToString("yyyy-MM-dd") });
                            row.Cells.Add(new TableCell { Text = reader["SubjectName"].ToString() });
                            row.Cells.Add(new TableCell { Text = reader["Status"].ToString() });

                            attendanceTable.Rows.Add(row);
                        }
                    }
                }
            }
        }
    }
}
