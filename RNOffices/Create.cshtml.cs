using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace HSALeadershipWebApp.Pages.RNOffices
{
    [Authorize]
    public class CreateModel : PageModel
    {
        public RNofficeInfo rnofficeInfo = new RNofficeInfo();
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            rnofficeInfo.Company_name = Request.Form["company_name"];
            rnofficeInfo.Company_id = Request.Form["company_id"];
            rnofficeInfo.Office_name = Request.Form["office_name"];
            rnofficeInfo.Office_id = Request.Form["office_id"];
            rnofficeInfo.Agent_count = Request.Form["agent_count"];
            rnofficeInfo.Is_open = Request.Form["is_open"];
            rnofficeInfo.Formatted_address = Request.Form["formatted_address"];
            rnofficeInfo.Office_phone_number = Request.Form["office_phone_number"];
            rnofficeInfo.Mb_first_name = Request.Form["mb_first_name"];
            rnofficeInfo.Mb_last_name = Request.Form["mb_last_name"];
            rnofficeInfo.Mb_email_address = Request.Form["mb_email_address"];
            rnofficeInfo.Mb_mobile_phone = Request.Form["mb_mobile_phone"];
            rnofficeInfo.Mb_id = Request.Form["mb_id"];
            rnofficeInfo.Admin_first_name = Request.Form["admin_first_name"];
            rnofficeInfo.Admin_last_name = Request.Form["admin_last_name"];
            rnofficeInfo.Admin_email_address = Request.Form["admin_email_address"];
            rnofficeInfo.Admin_mobile_phone = Request.Form["admin_mobile_phone"];
            rnofficeInfo.Admin_id = Request.Form["admin_id"];

            if (rnofficeInfo.Company_name.Length == 0 || rnofficeInfo.Company_id.Length == 0 || rnofficeInfo.Office_name.Length == 0 || rnofficeInfo.Office_id.Length == 0 ||
                rnofficeInfo.Agent_count.Length == 0 || rnofficeInfo.Is_open.Length == 0 || rnofficeInfo.Formatted_address.Length == 0 || rnofficeInfo.Office_phone_number.Length == 0 ||
                rnofficeInfo.Mb_first_name.Length == 0 || rnofficeInfo.Mb_last_name.Length == 0 || rnofficeInfo.Mb_email_address.Length == 0 || rnofficeInfo.Mb_id.Length == 0)
            {
                errorMessage = "All fields except 'admin' fields are required";
                return;
            }

            //save the new RN office info to HSA_RN_Office_Roster table
            try
            {
                string connectionString = "Data Source=******;Initial Catalog=******;Persist Security Info=True;User ID=******;Password=******";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "insert into ****** " +
                                 "(Company_name, Company_id, Office_name, Office_id, Agent_count, Is_open, Formatted_address, Office_phone_number, Mb_first_name, Mb_last_name, Mb_email_address, " +
                                 "Mb_mobile_phone, Mb_id, Admin_first_name, Admin_last_name, Admin_email_address, Admin_mobile_phone, Admin_id) values " +
                                 "(@Company_name, @Company_id, @Office_name, @Office_id, @Agent_count, @Is_open, @Formatted_address, @Office_phone_number, @Mb_first_name, @Mb_last_name, @Mb_email_address, " +
                                 "@Mb_mobile_phone, @Mb_id, @Admin_first_name, @Admin_last_name, @Admin_email_address, @Admin_mobile_phone, @Admin_id);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Company_name", rnofficeInfo.Company_name);
                        command.Parameters.AddWithValue("@Company_id", rnofficeInfo.Company_id);
                        command.Parameters.AddWithValue("@Office_name", rnofficeInfo.Office_name);
                        command.Parameters.AddWithValue("@Office_id", rnofficeInfo.Office_id);
                        command.Parameters.AddWithValue("@Agent_count", rnofficeInfo.Agent_count);
                        command.Parameters.AddWithValue("@Is_open", rnofficeInfo.Is_open);
                        command.Parameters.AddWithValue("@Formatted_address", rnofficeInfo.Formatted_address);
                        command.Parameters.AddWithValue("@Office_phone_number", rnofficeInfo.Office_phone_number);
                        command.Parameters.AddWithValue("@Mb_first_name", rnofficeInfo.Mb_first_name);
                        command.Parameters.AddWithValue("@Mb_last_name", rnofficeInfo.Mb_last_name);
                        command.Parameters.AddWithValue("@Mb_email_address", rnofficeInfo.Mb_email_address);
                        command.Parameters.AddWithValue("@Mb_mobile_phone", rnofficeInfo.Mb_mobile_phone);
                        command.Parameters.AddWithValue("@Mb_id", rnofficeInfo.Mb_id);
                        command.Parameters.AddWithValue("@Admin_first_name", rnofficeInfo.Admin_first_name);
                        command.Parameters.AddWithValue("@Admin_last_name", rnofficeInfo.Admin_last_name);
                        command.Parameters.AddWithValue("@Admin_email_address", rnofficeInfo.Admin_email_address);
                        command.Parameters.AddWithValue("@Admin_mobile_phone", rnofficeInfo.Admin_mobile_phone);
                        command.Parameters.AddWithValue("@Admin_id", rnofficeInfo.Admin_id);

                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {

                errorMessage = ex.Message;
                return;
            }

            rnofficeInfo.Company_name = ""; rnofficeInfo.Company_id = ""; rnofficeInfo.Office_name = ""; rnofficeInfo.Office_id = ""; rnofficeInfo.Agent_count = ""; rnofficeInfo.Is_open = "";
            rnofficeInfo.Formatted_address = ""; rnofficeInfo.Office_phone_number = ""; rnofficeInfo.Mb_first_name = ""; rnofficeInfo.Mb_last_name = ""; rnofficeInfo.Mb_email_address = "";
            rnofficeInfo.Mb_mobile_phone = ""; rnofficeInfo.Mb_id = ""; rnofficeInfo.Admin_first_name = ""; rnofficeInfo.Admin_last_name = ""; rnofficeInfo.Admin_email_address = ""; 
            rnofficeInfo.Admin_id = "";
            successMessage = "New Office Saved Correctly!";

            Response.Redirect("/RNOffices/Index");

        }
    }
}
