using System;
using System.Text;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Security.Cryptography;

public partial class Login : System.Web.UI.Page
{
    string connStr = WebConfigurationManager.ConnectionStrings["AttendanceDB"].ConnectionString;

    protected void Login_Click(object sender, EventArgs e)
    {
        string email = txtEmail.Text.Trim();
        string password = txtPassword.Text.Trim();

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            string query = "SELECT UserID, Role, Password FROM Users WHERE Email = @Email";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Email", email);

            conn.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    string storedPassword = reader["Password"].ToString();

                    if (storedPassword == password)
                    {
                        Session["UserID"] = reader["UserID"];
                        Session["Role"] = reader["Role"].ToString();

                        string role = reader["Role"].ToString();

                        if (role == "Admin")
                            Response.Redirect("Admin.aspx");
                        else if (role == "Teacher")
                            Response.Redirect("Teacher.aspx");
                        else if (role == "Student")
                            Response.Redirect("Student.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "Invalid credentials. Please try again!";
                    }
                }
                else
                {
                    lblMessage.Text = "Invalid credentials. Please try again!";
                }
            }
        }
    }
}