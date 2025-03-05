using System;
using System.Text;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Security.Cryptography;

public partial class AddUser : System.Web.UI.Page
{
    string connStr = WebConfigurationManager.ConnectionStrings["AttendanceDB"].ConnectionString;

    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        string name = txtName.Text.Trim();
        string email = txtEmail.Text.Trim();
        string password = txtPassword.Text.Trim();
        string role = ddlRole.SelectedValue;

        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            lblMessage.Text = "All fields are required.";
            return;
        }


        // Add user to the database
        if (AddUserToDatabase(name, email, password, role))
        {
            lblMessage.Text = "User added successfully!";
            txtName.Text = txtEmail.Text = txtPassword.Text = "";
        }
        else
        {
            lblMessage.Text = "Error adding user. Email may already exist.";
        }
    }

    // Inserts user into the database securely
    private bool AddUserToDatabase(string name, string email, string password, string role)
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            string query = "INSERT INTO Users (Name, Email, Password, Role) VALUES (@Name, @Email, @Password, @Role)";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@Role", role);

            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException ex)
            {
                lblMessage.Text = "Database error: " + ex.Message;
                return false;
            }
        }
    }
}