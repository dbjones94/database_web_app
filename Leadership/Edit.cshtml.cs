using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace HSALeadershipWebApp.Pages.Leadership
{
    [Authorize]
    public class EditModel : PageModel
    {
        public LeadershipInfo leadershipInfo = new LeadershipInfo();
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
            string id = Request.Query["id"];

            try
            {
                string connectionString = "Data Source=******;Initial Catalog=******;Persist Security Info=True;User ID=******;Password=******";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "select employee_id, first_name, last_name, isnull(mobile_phone,'') as mobile_phone, email_address, title, company_name, " +
                                 "company_id, office_id, office_address, isnull(office_phone,'') as office_phone, is_active from ****** where employee_id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                leadershipInfo.Employee_id = "" + reader.GetInt32(0);
                                leadershipInfo.First_name = reader.GetString(1);
                                leadershipInfo.Last_name = reader.GetString(2);
                                leadershipInfo.Mobile_phone = "" + reader.GetString(3);
                                leadershipInfo.Email_address = reader.GetString(4);
                                leadershipInfo.Title = reader.GetString(5);
                                leadershipInfo.Company_name = reader.GetString(6);
                                leadershipInfo.Company_id = reader.GetString(7);
                                leadershipInfo.Office_id = reader.GetString(8);
                                leadershipInfo.Office_address = reader.GetString(9);
                                leadershipInfo.Office_phone = reader.GetString(10);
                                leadershipInfo.Is_active = reader.GetString(11);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                errorMessage = ex.Message;
            }
        }

        public void OnPost()
        {
            leadershipInfo.Employee_id = Request.Form["employee_id"];
            leadershipInfo.First_name = Request.Form["first_name"];
            leadershipInfo.Last_name = Request.Form["last_name"];
            leadershipInfo.Mobile_phone = Request.Form["mobile_phone"];
            leadershipInfo.Email_address = Request.Form["email_address"];
            leadershipInfo.Title = Request.Form["title"];
            leadershipInfo.Company_name = Request.Form["company_name"];
            leadershipInfo.Company_id = Request.Form["company_id"];
            leadershipInfo.Office_id = Request.Form["office_id"];
            leadershipInfo.Office_address = Request.Form["office_address"];
            leadershipInfo.Office_phone = Request.Form["office_phone"];
            leadershipInfo.Is_active = Request.Form["is_active"];

            if (leadershipInfo.Employee_id.Length == 0 || leadershipInfo.First_name.Length == 0 || leadershipInfo.Last_name.Length == 0 || leadershipInfo.Email_address.Length == 0 ||
                leadershipInfo.Title.Length == 0 || leadershipInfo.Company_name.Length == 0 || leadershipInfo.Company_id.Length == 0 || leadershipInfo.Office_id.Length == 0 ||
                leadershipInfo.Office_address.Length == 0 || leadershipInfo.Is_active.Length == 0)
            {
                errorMessage = "All fields except Mobile phone and Cell phone are required";
                return;
            }

            try
            {
                string connectionString = "Data Source=******;Initial Catalog=******;Persist Security Info=True;User ID=******;Password=******";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "update ****** " +
                                 "set employee_id=@Employee_id, first_name=@First_name, last_name=@Last_name, mobile_phone=@Mobile_phone, email_address=@Email_address, title=@Title, " +
                                 "company_name=@Company_name, company_id=@Company_id, office_id=@Office_id, office_address=@Office_address, office_phone=@Office_phone, is_active=@Is_active " +
                                 "where employee_id=@Employee_id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Employee_id", leadershipInfo.Employee_id);
                        command.Parameters.AddWithValue("@First_name", leadershipInfo.First_name);
                        command.Parameters.AddWithValue("@Last_name", leadershipInfo.Last_name);
                        command.Parameters.AddWithValue("@Mobile_phone", leadershipInfo.Mobile_phone);
                        command.Parameters.AddWithValue("@Email_address", leadershipInfo.Email_address);
                        command.Parameters.AddWithValue("@Title", leadershipInfo.Title);
                        command.Parameters.AddWithValue("@Company_name", leadershipInfo.Company_name);
                        command.Parameters.AddWithValue("@Company_id", leadershipInfo.Company_id);
                        command.Parameters.AddWithValue("@Office_id", leadershipInfo.Office_id);
                        command.Parameters.AddWithValue("@Office_address", leadershipInfo.Office_address);
                        command.Parameters.AddWithValue("@Office_phone", leadershipInfo.Office_phone);
                        command.Parameters.AddWithValue("@Is_active", leadershipInfo.Is_active);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                errorMessage = ex.Message;
                return;
            }

            Response.Redirect("/Leadership/Index");
        }
    }
}
