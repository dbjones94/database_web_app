using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace HSALeadershipWebApp.Pages.Leadership
{
    [Authorize]
    public class CreateModel : PageModel
    {
        public LeadershipInfo leadershipInfo = new LeadershipInfo();
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
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
                errorMessage = "All fields except Office phone and Cell phone are required";
                    return;
                }

            //save the new leader info to HSA_Leadership table
            try
            {
                string connectionString = "Data Source=******;Initial Catalog=******;Persist Security Info=True;User ID=******;Password=******";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "insert into ****** " +
                                 "(employee_id, first_name, last_name, mobile_phone, email_address, title, company_name, company_id, office_id, office_address, office_phone, is_active) values " +
                                 "(@Employee_id, @First_name, @Last_name, @Mobile_phone, @Email_address, @Title, @Company_name, @Company_id, @Office_id, @Office_address, @Office_phone, @Is_active);";

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

            leadershipInfo.Employee_id = ""; leadershipInfo.First_name = ""; leadershipInfo.Last_name = ""; leadershipInfo.Mobile_phone = ""; leadershipInfo.Email_address = ""; leadershipInfo.Title = "";
            leadershipInfo.Company_name = ""; leadershipInfo.Company_id = ""; leadershipInfo.Office_id = ""; leadershipInfo.Office_address = ""; leadershipInfo.Office_phone = ""; leadershipInfo.Is_active = "";
            successMessage = "New Leader Saved Correctly!";

            Response.Redirect("/Leadership/Index");

        }
    }
}
